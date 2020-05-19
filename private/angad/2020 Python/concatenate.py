mydic1={1:10, 2:20}
mydic2={3:30, 4:40}
mydic3 = {}
for x in (mydic1, mydic2): 
    mydic3.update(x)
print(mydic3)