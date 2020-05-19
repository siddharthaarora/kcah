import hANGMAN
import snake
import race

user_choice = input("Which application would you like to open? Snake Game, Hangman Game, Car Game, or EZVote?")

if user_choice != "Hangman Game" or "Snake Game" or "Car Game" or "EZVote":
    print("Enter a valid choice.") 

if user_choice == "Hangman Game":
    print() 