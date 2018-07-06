# This function takes a parameter n and prints n levels of Pascal Triangle
def PascalsTriangle(n):
    if n <= 0:
        print("Invalid input:" + n)
    
    print("[")

    if n == 1:
        print("\t[1]")
    elif n >= 2:
        print("\t[1]")
        r = [1,1]
        PrintRow(r)
        for i in range(2, n):
            nr = []
            nr.append(1)
            for j in range(0,len(r)-1):
                nr.append(r[j] + r[j+1])
            nr.append(1)
            PrintRow(nr)
            r = nr
    print("]")

def PrintRow(r):
    print("\t", end="")
    print(r)

def main():
    n = eval(input("Enter number of rows to print of Pacal's Triange: "))
    PascalsTriangle(n)

main()