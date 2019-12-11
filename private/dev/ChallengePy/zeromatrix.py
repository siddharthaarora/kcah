# Zero Matrix: An algorithm such that if an element in an
# MxN matrix 0, its entire row and column are set to 0.

def ZeroMatrix(m, r, c):
    if m is None:
        return
    
    printMatrix(m, r, c)

    for i in range(0, r):
        for j in range(0, c):
            if (m[i][j] == 0):
                print("making it -1")
                m[i][j] = -1
    
    printMatrix(m, r, c)

    for i in range(0, r):
        for j in range(0, c):
            if (m[i][j] == -1):
                makeRowColumnZero(m, i, j)
                m[i][j] = 0

    printMatrix(m, r, c)

def makeRowColumnZero(m, r, c):
    i = 0
    while (i < c):
        m[r][i] = 0
        i+=1
    while (i < r):
        m[i][c] = 0
        i+=1

def printMatrix(m, r, c):
    for i in range(0, r):
        for j in range(0, c):
            print(m[i][j], end = " ") 
        print()
    print("-----------")


m = ( [ 2, 5, 7 ],
      [ 4, 7, 9 ],
      [ 0, 3, 6 ],
      [ 1, 0, 8] )

ZeroMatrix(m, 4, 3)