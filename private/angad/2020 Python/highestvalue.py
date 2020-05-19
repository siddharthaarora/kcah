my_dict= {'a':500, 'b':5874, 'c': 560,'d':400, 'e':5874, 'f': 20}
mem =sorted(my_dict.values(),reverse=True)[:3]
l=[i for i in my_dict if my_dict[i] in mem]
print(l)