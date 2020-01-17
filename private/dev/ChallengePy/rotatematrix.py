# Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
# bytes, write a method to rotate the image by 90 degrees. Can you do this in place?

# Example

#     0   1   2
#     ---------
# 0   A   B   C             
# -
# 1   D   E   F 
# -
# 2   G   H   I

#        ||
#        ||
#        ||
#        \/

#     0   1   2                 <-- Bascially:
#     ---------                     i k      k j
# 0   G   D   A                    (0,0) -> (0,2)
# -                                (0,1) -> (1,2) 
# 1   H   E   B                    (0,2) -> (2,2)
# -                                (1,0) -> (0,1)
# 2   I   F   C                    (1,1) -> (1,1)
#                                  (1,2) -> (2,1)
#                                  you get the idea

def RotateMatrix(m):
    n = len(m)
    i = 0
    j = n -1
    k = 0
    while i < n:
        while k < n:
            print(i,j,k)
            t = m[k][j]
            m[k][j] = m[i][k]
            m[i][k] = t
            k = k + 1
        i = i + 1
        j = j - 1
        k = 0

def PrintMatrix(m):
    for i in range (0, len(m)):
        print(m[i])
        # for j in range(0,len(m)):
        #     print(i,j, ':', m[i][j])


# driver code
m = [['A', 'B', 'C'], ['D', 'E', 'F'], ['G', 'H', 'I']]
PrintMatrix(m)
RotateMatrix(m)
PrintMatrix(m)




