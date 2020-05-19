x=int(input("enter an integer "))

def square(x):
    my_dict = {}
    for i in range (1,x+1):    
        my_dict[i] = i*i
    print(my_dict)
    
print(square(x))