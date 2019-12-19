# A simple implementation of a stack
# using a array

class stack:
    __s = [None] * 10
    __len = 0
    
    def __init__(self):
        __s = []
        __len = 0

    def push(self, data):
        self.__s[self.__len] = data
        self.__len += 1
    
    def pop(self):
         data = self.__s[self.__len-1]
         self.__len -= 1
         self.__s[self.__len] = None
         return data
    
    def isEmpty(self):
        return not (self.__len > 0)
    
    def peek(self):
        return self.__s[self.__len-1]

    def __str__(self):
        return(str(self.__s))

s = stack()
s.push(10)
s.push(20)
s.push(60)
s.push(40)
s.push(50)
print(s)

print(s.pop())
print(s)
print(s.pop())
print(s)
print(s.pop())
print(s)
print(s.pop())
print(s)
print(s.peek())
print(s)
