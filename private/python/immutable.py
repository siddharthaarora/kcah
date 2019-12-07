def demoimmutable():
    n = 5
    print(n)
    n = 10
    print(n)
    print(type(n))

    s = 'hello, world!'
  
    print(s)
    print(type(s))

    p = 'j' + s[1:13]
    print(p)



demoimmutable()