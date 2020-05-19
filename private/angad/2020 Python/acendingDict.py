import operator
d = {19:500, 10:700, 5:600, 1:200, 9:300, 2:500, 20:1000}
print('Original dictionary : ',d)
sorted_d = sorted(d.items(), key=operator.itemgetter(0))
print('Dictionary in ascending order by value : ',sorted_d)
sorted_d = dict( sorted(d.items(), key=operator.itemgetter(0),reverse=True))
print('Dictionary in descending order by value : ',sorted_d)    