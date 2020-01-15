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

def PalindromePermutation(s)
    v = [0] * 26
    for i in range(0, len(s)):
        idx = ord(s[i]) - 97
        if (v[idx] == 0):
            v[idx] = 1
        else:
            v[idx] = 0
    
     
