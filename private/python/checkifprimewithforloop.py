import sys

def checkifprimewithforloop(n):
    is_prime = 0
    divisor = 2
    
    if (n == 1):
        print (n, "is not a prime number")
        sys.exit()
        
    for d in range(divisor, n):
        if (n % d == 0):
            is_prime = 1
            break
        print(d)

    if (is_prime == 0):
        print(n, " is a prime number")
    else:
        print(n, " is not a prime number")

checkifprimewithforloop(17)
