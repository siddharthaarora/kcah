<# 
.SYNOPSIS 
This script can be used for creating users in Azure AD and on-premise AD.

.DESCRIPTION 
This script can be used for creating users in Azure AD and on-premise AD.
This scripts require input csv file to be prepared with required details.

.Notes
CSV file must have following column
    UserPrincipalName
    FirstName
    LastName
    DisplayName
    Country or Region
#>

param(
    [Parameter(Mandatory=$true)][ValidateScript({Test-Path $_})][String]$Path
)

Function Install-AzureAD {
    Set-PSRepository -Name PSGallery -Installation Trusted -Verbose:$false
    Install-Module -Name AzureAD -AllowClobber -Verbose:$false
}

Write-Verbose "Starting import of users..."
Try {
    $users = @(Import-CSV -Path $Path -ErrorAction Stop)
    Write-Verbose "Successfully imported entries from $Path"
    Write-Verbose "Total no. of entries in CSV are : $($users.count)"
} 
Catch {
    Write-Verbose "Failed to read from the CSV file $Path Exiting!"
    Break
}

Try {
    Import-Module -Name AzureAD -ErrorAction Stop -Verbose:$false | Out-Null 
}
Catch {
    Write-Verbose "Azure AD PowerShell Module not found..."
    Write-Verbose "Installing Azure AD PowerShell Module..."
    Install-AzureAD
}

Try {
    Write-Verbose "Connecting to Azure AD..."
    Connect-AzureAD -ErrorAction Stop | Out-Null
}
Catch {
    Write-Verbose "Cannot connect to Azure AD. Please check your credentials. Exiting!"
    Break
}

$PasswordProfile = New-Object -TypeName Microsoft.Open.AzureAD.Model.PasswordProfile
$PasswordProfile.Password = "Learn234"
$PasswordProfile.EnforceChangePasswordPolicy = $false
$PasswordProfile.ForceChangePasswordNextLogin = $false

Foreach ($user in $users) {
    $UserPrincipalName = $user.UserPrincipalName
    $FirstName = $user.FirstName
    $LastName = $user.LastName
    $DisplayName = $user.DisplayName
    $Country = $user.Country

    Try {    
        New-AzureADUser -GivenName $FirstName `
            -Surname $LastName `
            -DisplayName $DisplayName `
            -MailNickName "Student" `
            -AccountEnabled $true `
            -UserPrincipalName $UserPrincipalName `
            -Country $Country `
            -PasswordProfile $PasswordProfile `
            -PasswordPolicies "DisablePasswordExpiration"

        Write-Verbose "$DisplayName : AAD Account is created successfully!"
    } 
    Catch {
        Write-Error "$DisplayName : Error occurred while creating Azure AD Account. $_"
    }
}
