def findmaxmin(a,b,c,d,e):
    max = 0
    min = 0
    
    if (max < a):
        max = a
    if (max < b):
        max = b
    if (max < c):
        max = c
    if (max < d):
        max = d
    if (max < e):
        max = e
        
    if (min > a):
        min = a
    if (min > b):
        min = b
    if (min > c):
        min = c
    if (min > d):
        min = d
    if (min > e):
        min = e

    print('max - ', max)
    print('min - ', min)
    
findmaxmin(4,7,3,0,9)    
findmaxmin(34,99,-1,45,8)