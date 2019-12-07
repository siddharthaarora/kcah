def bin(s):
    if s > 1:
        return bin(s >> 1) + str(s & 1)
    else:
        return str(s)

def printSetBits(n):
    i = 1
    while (n > 0):
        if (n & 0x1 == 1):
            print (i, "th bit is set!")
        n = n >> 1
        i+=1

def ConvertInt32ToByteString(num):
    n = int(num)
    bitstr = bin(n)
    bitstr = bitstr.zfill(64)
    i = 0
    for b in bitstr:
        if i == 8:
            print('  ', end = '')
            i = 0
        print(b, end = '')
        i+=1
    print()

    #printSetBits(n)

#ConvertInt32ToByteString(input('enter a number - '))