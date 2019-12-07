# find the maximum number in a given list
# def max(mylist):
#     m = 0
#     for e in mylist:
#         if e > m:
#             m = e
#     return m;

# print(max([10,20,30,40,50]))

# return elements at odd positions
# def oddElements(mylist):
#     r = []
#     for i in range(1,len(mylist)):
#         if (i%2 != 0):
#             print(mylist[i])
#             r.append(mylist[i])
#     return r

# assert oddElements([0,1,2,3,4,5]) == [1,3,5]

# return digits as list
def digitsList(n):
    m = n
    r = []

    while m != 0:
        r.append(m % 10)
        m = m // 10

    print (r[::-1])

digitsList(123)