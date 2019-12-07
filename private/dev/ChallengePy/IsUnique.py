# Is Unique: Implement an algorithm to determine 
# if a string has all unique characters. What if 
# you cannot use additional data structures?

import BinaryOperations

def IsUnique(s):
    if s is None or len(s) == 0:
        return True
    
    chars = {}

    for c in s:
        if chars.get(c) == 1:
            return False
        else:
            chars[c] = 1

    return True

# Use a number (32-bit int) as bit vector to keep track of which characters we have seen
# So, least 26 bits represent a-z
# Initially, each bit is set to 0. 
# For each char, first check if the bit is set to 1. 
# If bit is already set to 1, then we have found the duplicate char
# Else, set the bit corresponding to that char to 1
def IsUniqueSpaceOptimized(s):
    bitvector = 0
    for c in s:
        idx = (ord(c) % 32) - 1
        print ("c: ", c, "idx: ", idx)
        print ("check: ", (1 << idx) & bitvector)
        if ((1 << idx) & bitvector) > 1:
            return False
        else:
            bitvector = (1 << idx) | bitvector
        print("bitvector: ", end='')
        BinaryOperations.ConvertInt32ToByteString(bitvector)
        print("idx      : ", end='')
        BinaryOperations.ConvertInt32ToByteString(idx)

    return True

print(IsUniqueSpaceOptimized(input("enter a string: ")))