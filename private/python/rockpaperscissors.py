p1 = input("enter player 1 pick: ")
p2 = input("enter player 2 pick: ")

if not (p1 == "rock" or p1 == "paper" or p1 == "scissors"):
    print("p1 entered invalid pick")
if not (p2 == "rock" or p2 == "paper" or p2 == "scissors"):
    print("p2 entered invalid pick")

if (p1 == p2):
    print("TIE")

if (p1 == "rock"):
    if (p2 == "paper"):
        print("p2 wins")
    else:
        print("p1 wins")

if (p1 == "paper"):
    if (p2 == "scissors"):
        print("p2 wins")
    else:
        print("p1 wins")

if (p1 == "scissors"):
    if (p2 == "rock"):
        print("p2 wins")
    else:
        print("p1 wins")