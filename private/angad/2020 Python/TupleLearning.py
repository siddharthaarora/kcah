def last(a): return a[-1]  
  
def sort_list(myTuple):  
  return sorted(myTuple, key=last)  
  
print(sort_list([(2, 5), (1, 2), (4, 4), (2, 3), (2, 1)]))  