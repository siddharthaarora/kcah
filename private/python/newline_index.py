def newline_index(x):
    print(len(x))
    for a in range(len(x)-1, -1, -1):
        print(a, ":", x[a])

newline_index("hello world")