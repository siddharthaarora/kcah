# URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
# has sufficient space at the end to hold the additional characters, and that you are given the "true"
# length of the string. (Note: If implementing in Java, please use a character array so that you can
# perform this operation in place.)
# EXAMPLE
# Input: "Mr 3ohn Smith 13
# Output: "Mr%203ohn%20Smith"

def urlfy(u):
    url = list(u)
    n = len(url)
    i = n - 1
    j = n - 1
    while (url[i] == ' '):
        i = i - 1

    while (j >= 0):
        url[j] = url[i]
        if (url[i] == ' '):
            url[j] = '0'
            j = j - 1
            url[j] = '2'
            j = j - 1
            url[j] = '%'
        i = i - 1
        j = j - 1
    return url

u = "Mr 3ohn Smith 13         "
#print(url, " --> ", end='')
url = urlfy(u)
print(url, '!')
