import sys

def checkifprimewithwhileloop(n):
    is_prime = 0
    divisor = 2
    
    if (n == 1):
        print (n, "is not a prime number")
        sys.exit()
        
    while(n > divisor):
        if (n % divisor == 0):
            is_prime = 1
            break
        print(divisor)
        divisor += 1
    
    if (is_prime == 0):
        print(n, " is a prime number")
    else:
        print(n, " is not a prime number")

checkifprimewithwhileloop(1)
