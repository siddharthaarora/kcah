# Program that keeps asking user to enter a string
# And, then prints out the string that user entered
# If, the user entered ">", then the program exits

def EchoUserInput():
    str = input("please enter a string: ")
    while(str != ">"):
        print(str)
        str = input("please enter a string: ")

EchoUserInput()