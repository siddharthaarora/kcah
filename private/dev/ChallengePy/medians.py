# Given two sorted arrays of same length, find the median pair

def findMedians(a, b):
    i = 0
    j = 0
    k = 0
    n = len(a)
    c = [0] * (2 * n)

    while (k < (2 * n)-1):
        if (a[i] < b[j]):
            c[k] = a[i]
            i = i+1
        else:
            c[k] = b[j]
            j = j+1
        k = k+1

    return [c[n-1], c[n]]

def findMediansP(a, b):
    i=0
    j=0
    k=0
    m1=0
    m2=0
    n = len(a)
    t = 0

    while (k < 2 * n - 1):
        if ((i < n) and a[i] < b[j]):
            t = a[i]
            i = i+1
        else:
            t = b[j]
            j = j+1
    
        if (k == n - 1):
            m1 = t
        elif (k == n):
            m2 = t
            break
        k = k+1
    
    return [m1, m2]

# m = findMedians([1,2,3], [4,5,6])
# print(m)

m = findMediansP([1,2,4], [2,3,6])
print(m)