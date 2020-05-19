# 1. Write a function that takes a list of numbers as input
# 2. Find the numbers that are repeated more than once
# 3. Return the list of repeated numbers
#
# For example, if input is [4,5,6,7,4,9, 6, 1]
# then, output should be [4,6]

#sample input
a = [1,7,7,6,5,9,7,9,6,5,0,0,6]
y = []

#comparing each number in the list to each other.
#comnplexity - O(n!)
for i in range(0,len(a)):
    for j in range(i+1,len(a)):
        if a[i] == a[j]:
            y.append(a[i])

print(y)
    