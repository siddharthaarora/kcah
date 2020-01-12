# Print nth Fibonacci number

def printnthfibonacci(n):
    fib = 0
    if n == 1:
        fib = 1
        print(fib)
        return
    cf = 1
    pf = cf - 1
    for i in range (1, n):
        t = cf + pf
        pf = cf
        cf = t
        print (t, cf, pf)

    print (t)

def printnthfibonaccirecursive(n):
    if n == 0: return 0
    if n == 1: return 1
    return printnthfibonaccirecursive (n-1) + printnthfibonaccirecursive(n-2)

printnthfibonacci(9)
printnthfibonaccirecursive(9)