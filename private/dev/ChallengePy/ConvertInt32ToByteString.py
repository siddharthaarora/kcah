def ConvertInt32ToByteString(num):
    bitstr = bin(int(num))
    print(len(bitstr))
    bitstr = bitstr.zfill(32 - len(str(bitstr)))
    print(bitstr)
    i = 0
    for b in bitstr:
        if i == 4:
            print(' ', end = '')
        elif i == 8:
            print('  ', end = '')
            i = 0
        print(b, end = '')
        i+=1

def bin(s):
    print(s)
    if s > 1:
        return bin(s >> 1) + str(s & 1)
    else:
        return str(s)

ConvertInt32ToByteString(input('enter a number - '))