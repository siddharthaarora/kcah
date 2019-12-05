#Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
#cannot use additional data structures?

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


print(IsUnique("helo"))