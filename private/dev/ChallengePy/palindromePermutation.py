# Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
# A palindrome is a word or phrase that is the same forwards and backwards. A permutation
# is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.
# EXAMPLE
# Input: Tact Coa
# Output: True (permutations: "taco cat", "atco e t a " , etc.)

# if len(s) is even, then each char should appear twice. Else, one char should appear once.
# Sol 1 - use hash table to store the chars and counts, then check if each char has count of 2 and only char has count of 1; Time - O(n); Space - O(2n)
# Sol 2 - use a bit vector to basically implement Sol 1 with less space
# Sol 3 - Sol 1 and 2 are crap. The most elegant solution is to have a bit vector of length 26 (a-z) and then set the bit for each char. 
# At the end, check that there is one bit that is set or all zeros depending on length of the input.

import BinaryOperations

def PalindromePermutation(s):
    v = [0] * 26
    for i in range(0, len(s)):
        if (s[i] == " "):
            continue
        idx = ord(s[i]) - 97
        if (v[idx] == 0):
            v[idx] = 1
        else:
            v[idx] = 0
    count1s = 0
    print(v)
    for i in range(0, 26):
        if (v[i] == 1):
            count1s = count1s + 1
    if (count1s == 0 or count1s == 1):
        print(s, "is a permutation of a palindrome!")
    else:
        print(s, "is NOT a permutation of a palindrome!")

def PalindromePermutationUsingBitManipulation(s):
    v = 0
    for i in range(0, len(s)):
        if s[i] == " ":
            continue
        v = v ^ (1 << ord(s[i]) - 97)

    count1s = 0
    for i in range (0, 26):
        count1s = count1s + (1 & (v >> 1))
        v = v >> 1

    if (count1s == 0 or count1s == 1):
        print(s, "is a permutation of a palindrome!")
    else:
        print(s, "is NOT a permutation of a palindrome!")

PalindromePermutationUsingBitManipulation("tacz cat")
PalindromePermutationUsingBitManipulation("sss x sss")
PalindromePermutationUsingBitManipulation("atco c t a")
PalindromePermutationUsingBitManipulation("atco e t a")
