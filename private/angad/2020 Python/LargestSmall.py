a = [10, 50, 60, 83268, 23129, 15]

print(max(a))
print(min(a))

big = a[0]

for item in a:
    if item > big:
        big = item

print(big)


small = a[0]

for item in a:
    if item < small:
        small = item

print(small)