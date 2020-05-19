file_name = open('encrypted.txt','r')
count = len(open('encrypted.txt').readlines())
print(count)

import os
k = os.path.getsize('encrypted.txt')
print(k)

num_words = 0
 
with open('encrypted.txt', 'r') as f:
    for line in f:
        words = line.split()
        num_words += len(words)
print("Number of words:")
print(num_words)

def longest_word('encrypted.txt'):
    with open('encrypted.txt', 'r') as infile:
              words = infile.read().split()
    max_len = len(max(words, key=len))
    return [word for word in words if len(word) == max_len]

print(longest_word('test.txt'))