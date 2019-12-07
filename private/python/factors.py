def factors():
    for k in range(1, 21):
        print(k, ':', end = '')
        for a in range(1, k+1):        #nested for loops
            if k % a == 0:
                print(a,',', end ='')
        print()

factors()

