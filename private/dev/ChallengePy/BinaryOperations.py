def bin(n):
    if n > 1:
        return bin(n >> 1) + str(n & 1)
    else:
        return str(n)

def bin2(n):
    if (n <=1):
        print(str(n))
    s = ''
    while(n > 0):
        s += str(n & 1)
        n = n >> 1
    print (s[::-1])

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

# n = input('enter a number - ')
# ConvertInt32ToByteString(n)

# ConvertInt32ToByteString(1 << 4)
# ConvertInt32ToByteString((1 << 4) - 1)