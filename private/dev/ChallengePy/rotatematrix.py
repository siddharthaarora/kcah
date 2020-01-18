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
#                                  (2,0) -> (0,0)
#                                  (2,1) -> (1,0)
#                                  (2,2) -> (2,0)
# (0,0) -> (0,2) -> (2,2) -> (2,0) -> (0,0)
# Algo
# for i = 0, n:
#     temp = top[i]
#     top[i] = left[i]
#     left[i] = bottom[i]
#     bottom[i] = right[i]
#     right[i] = temp



def RotateMatrix(m):
    n = len(m)
    for layer in range (0, int(n/2)):
        first = layer
        last = n - 1 - layer
        for i in range (first, last):
            offset = i - first
            top = m[first][i] # save top
            m[first][i] = m[last - offset][first] # left -> top
            m[last - offset][first] = m[last][last - offset] # bottom -> left
            m[last][last - offset] = m[i][last] # right -> bottom
            m[i][last] = top # right -> left

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




