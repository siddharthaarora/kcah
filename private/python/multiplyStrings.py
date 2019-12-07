# multiply numbers as strings without converting them to ints
# a = "123456"
# b = "345"

#  123
# x 78
# ----
#  984
# 8610
# ----
# 9594

def multiplyStrings(a, b):
    product = 0
    counter = 0
    print("a = ", a, "b = ", b)
    for i in range(len(a)-1, -1, -1):
        p = 0
        c = 0
        k = 0
        for j in range(len(b)-1, -1, -1):
            sp = (int(b[j]) * int(a[i])) + c
            p += ((sp % 10) * (10**k))
            c = (sp // 10)
            k += 1
            print("i = ", i, "j = ", j, "int(b[j]) = ", int(b[j]), "int(a[i]) = ", int(a[i]), "sp = ", sp, "c = ", c, "p = ", p)
        product += p * 10**counter
        print("product = ", product)
        counter += 1
    return product

assert (multiplyStrings("78", "123") == 9594)