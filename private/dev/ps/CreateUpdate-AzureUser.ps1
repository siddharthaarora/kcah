<# 
.SYNOPSIS 
This script can be used for creating users in Azure AD and on-premise AD.

.DESCRIPTION 
This script can be used for creating users in Azure AD and on-premise AD.
This scripts require input csv file to be prepared with required details.

.PARAMETER Credential
Alternate credential can be provided to run the script, otherwise logged in credetial will be used to run the script.

 .PARAMETER Path
CSV file path containing user details

.PARAMETER AccountSkuid
O365 Account SKUID. One or more account skuid can be privided to assign license to user

.PARAMETER MFA
Provide MFA $True is you want to enable MFa for user

.EXAMPLE 
Create/Update users from csv file located at c:\scripts\AzureUsers.csv without enabling license and MFA

.\Create-AzureUser.ps1 -Path c:\scripts\AzureUsers.csv

.EXAMPLE
Create/Update users from csv file and provisioing AAD_Premium license

.\Create-AzureUser.ps1 -Path c:\scripts\AzureUsers.csv -AccountSkuid AAD_Premium

.Example
Create/Update users from csv file and provisioning more than one license

.\Create-AzureUser.ps1 -Path c:\scripts\AzureUsers.csv -AccountSkuid AAD_Premium, contoso:ENTERPRISEPACK

.Example
Create/Update users from csv file, provision license and enable MFA

.\Create-AzureUser.ps1 -Path c:\scripts\AzureUsers.csv -AccountSkuid AAD_Premium -MFA:$True 

.Example
Create/Update users from csv file with provision license and enable MFA using alternate credentia

.\Create-AzureUser.ps1 -Path c:\scripts\AzureUsers.csv -AccountSkuid AAD_Premium -MFA:$True -Credential (Get-Credential)

.Link 
If you have any feedback\question, you can post to
https://gallery.technet.microsoft.com/PowerShell-O365-Bulk-User-a4df3db2

.Notes
CSV file must have following column
    FirstName
    LastName
    UserPrincipalName
    UsageLocation

Author - Vikram Athare
Version 1.0

#>
[CmdletBinding(SupportsShouldProcess=$True,ConfirmImpact='High')] 
param(
    [Parameter(Mandatory=$true)][ValidateScript({Test-Path $_})][String]$Path,
    [Parameter()][ValidateNotNull()][System.Management.Automation.PSCredential][System.Management.Automation.Credential()]$Credential = [System.Management.Automation.PSCredential]::Empty,
    [Parameter(Mandatory=$false)][String[]]$AccountSkuid = $null,
    [Parameter(Mandatory=$false)][bool]$MFA = $false,
    [Parameter(Mandatory=$false)][int]$PasswordLength = 12
)
Write-Host "Script execution has started" -ForegroundColor Magenta 
# Define Log file
[String]$LogFile = (Get-Location).Path + "\Result_" + (Get-Date -Format MM-dd-yyyy) + ".csv"
[String]$ErrorLogFile = (Get-Location).Path + "\Error_" + (Get-Date -Format MM-dd-yyyy) + ".log"
# Importing csv file
$Users = Import-Csv -Path $Path
# Import O365 module
Import-Module MSOnline
If ( ! (Get-module MSOnline )) {
 Throw "O365 module is not installed. Install O365 module in order to run this script"
}
Write-Verbose "Connecting to O365..." 
Connect-MsolService -Credential $Credential -ErrorAction Stop
# Creating MFA Object
if ($MFA -eq $True) {
    $mf= New-Object -TypeName Microsoft.Online.Administration.StrongAuthenticationRequirement
    $mf.RelyingParty = "*"
    $mf.State = "Enabled"
    $mf.RememberDevicesNotIssuedBefore = (Get-Date)
    $mfauthenabled = @($mf)
}
# Random Password function
Function New-RandomPassword() {
    param(
        [int]$length
    )
    $ascii=$NULL;For ($a=33;$a –le 126;$a++) {$ascii+=,[char][byte]$a }
    For ($loop=1; $loop –le $length; $loop++) {
        $RandomPassword+=($ascii | GET-RANDOM)
    }
    return $RandomPassword
}
# Define array to store result
$Result = @()
# Processing each user
foreach ($Object in $Users) {             
	try {
        $Verify = $null
        $DateTime = Get-Date -Format ddMMyyyyHHmm
        $FirstName = $Object.FirstName
        $LastName = $Object.LastName
        $DisplayName = $FirstName + " " + $LastName
        $UserPrincipalName = $Object.UserPrincipalName
        $UsageLocation = $Object.UsageLocation
        $Password = New-RandomPassword -length $PasswordLength
# Saving info into object
        $item = @{}
        $item.UserPrincipalName = $UserPrincipalName
        $item.Password = $Password

        Write-Host "Processing $UserPrincipalName" -ForegroundColor Magenta
# Create user in O365
        $Verify = Get-MsolUser -UserPrincipalName $UserPrincipalName -ErrorAction SilentlyContinue
        if ($Verify -eq $null) {
            Write-Verbose "Creating $UserPrincipalName in Azure AD..."
            New-MsolUser -DisplayName $DisplayName -FirstName $FirstName -LastName $LastName -UserPrincipalName $UserPrincipalName -UsageLocation $UsageLocation -Password $Password -ErrorAction Stop
            $item.UserProvision = 'Success'
        }
        else {
            $item.Password = 'NA'
            $item.UserProvision = 'User already exist'
        }
        # Catch error
    }
	catch {
        Write-Error "Script execution has failed while creating user, check $ErrorLogFile for more details"
        $item.UserProvision = 'Failed'
        "===============================================================" | Out-File $ErrorLogFile -Append -Force
		"Caught in exception while provisioning user in O365: $UserPrincipalName" | Out-File $ErrorLogFile -Append -Force
		"Exception Type: $($_.Exception.GetType().FullName)" | Out-File $ErrorLogFile -Append -Force
        "Exception Message: $($_.Exception.Message)" | Out-File $ErrorLogFile -Append -Force
	}
    try {
# Enable MFA
        if ($MFA -eq $True) {
            if ($Verify.StrongAuthenticationRequirements.State -ne 'Enabled' -and $Verify.StrongAuthenticationRequirements.State -ne 'Enforced') {
                Write-Verbose "Enabling MFA..."
                Set-MsolUser -UserPrincipalName $UserPrincipalName -StrongAuthenticationRequirements $mfauthenabled -ErrorAction Stop
                $item.EnableMFA = 'Success'
            }
            else {
                $item.EnableMFA = 'AlreadyEnabled'
            }
        }
        else {
            $item.EnableMFA = 'NA'
        }
    }
    # Catch error
	catch {
        Write-Error "Script execution has failed while enabling MFA for $UserPrincipalName, check $ErrorLogFile for more details"
        $item.EnableMFA = 'Failed'
        "===============================================================" | Out-File $ErrorLogFile -Append -Force
		"Caught in exception while O365 MFA enable: $UserPrincipalName" | Out-File $ErrorLogFile -Append -Force
		"Exception Type: $($_.Exception.GetType().FullName)" | Out-File $ErrorLogFile -Append -Force
        "Exception Message: $($_.Exception.Message)" | Out-File $ErrorLogFile -Append -Force
	}
# Assigning  license
    if ($AccountSkuid -eq $null) {
       $item.LicenseProvision = 'NA' 
    }
    if ($AccountSkuid -ne $null) {
        foreach ($Object in $AccountSkuid) {
            try {
                if ($Verify.Licenses.Accountskuid -ne $Object ) {
                    Write-Verbose "Assigning $Object license..."                    
                    Set-MsolUserLicense -UserPrincipalName $UserPrincipalName -AddLicenses $Object -ErrorAction Stop
                }
            }
# Catch error
	        catch {
                Write-Error "Script execution has failed, check $ErrorLogFile for more details"
                $item.LicenseProvision = 'One or more licese provision has failed'
                "===============================================================" | Out-File $ErrorLogFile -Append -Force
		        "Caught in exception while provisioning license $Object in O365 for $UserPrincipalName" | Out-File $ErrorLogFile -Append -Force
		        "Exception Type: $($_.Exception.GetType().FullName)" | Out-File $ErrorLogFile -Append -Force
                "Exception Message: $($_.Exception.Message)" | Out-File $ErrorLogFile -Append -Force
	        }
        }
    }
    if ($item.LicenseProvision -ne 'One or more licese provision has failed') {
        $item.LicenseProvision = 'Success'
    }
# Preparing to store result
        $PsObject = New-Object -TypeName PSObject -Property $item
        $Result += $PsObject
    }
$Result | Select-Object UserPrincipalName,UserProvision,Password,LicenseProvision,EnableMFA  |Export-Csv $LogFile -NoTypeInformation -Encoding ASCII -Force
Write-Host "Script execution completed, check $LogFile for result and check $ErrorLogFile for script error if any" -ForegroundColor Magenta