def sum(num):
    total = 0

    for x in num:
        total = total + x
    return total

print(sum((1, 2, 3, 1, 7)))