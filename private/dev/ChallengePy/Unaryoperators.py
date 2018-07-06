val = eval(input())

if val<10:
    if val !=5:
        print("awesome ")
    else: val +=1
else:
    if val == 17:
        val+=10
    else:
        print("great ", end='')
print(val)