def ConvertInt32ToByteString(num):
    i = 0
    while (i < 32):
        num = num << 1
        print(num)
        print(num & 0xF)
        i+=1

def bin(s):
   return str(s) if s<=1 else bin(s>>1) + str(s&1)

print(bin(5))