u = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"]
x = open("encrypted.txt", "r")
x = x.read()
new = ""
x.lower()
for i in x:
    if i in u:
        x = u.index(i)
        x = x + 19
        if x > 25:
            x = x - 26
        x = u[x]
        new = new + str(x)
    else:
        new = new + i
print(new)