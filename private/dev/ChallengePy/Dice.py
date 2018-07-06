import random
while True:
    n = input("Do you want to roll the die? YES or NO? ")
    if n == "YES":
        randomnumber = random.randint(1, 6)
        print("You rolled a", randomnumber)
    else:
        print("That's cool.")
        break