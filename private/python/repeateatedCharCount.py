# find the character in a string that is repeated the most

def repeatedCharCount(s):
    #ord('a') = 97, ord('z') = 122, ord('A') = 65, ord('Z') = 90
    a = [0] * 122
    max = 0
    r = ''

    for c in s:
        a[ord(c)] += 1
        if (a[ord(c)] > max):
            max = a[ord(c)]
            r = c

    print(r)

repeatedCharCount("cof breac")