#    ____
#   |    |      
#   |    o      
#   |   /|\     
#   |    | 
#   |  _/ \_
#  _|_
# |   |______
# |          |
# |_________|

import time
import random
import sys
import numpy

def Hangman():
    #initialize hangman skeleton array
    rows, cols = (10,15)
    arr = numpy.empty([rows,cols],dtype=str) 
    arr[9][0] = '|'
    arr[9][1] = '_'
    arr[9][2] = '_'
    arr[9][3] = '_'
    arr[9][4] = '_'
    arr[9][5] = '_'
    arr[9][6] = '_'
    arr[9][7] = '_'
    arr[9][8] = '_'
    arr[9][9] = '_'
    arr[9][10] = '_'
    arr[9][11] = '_'
    arr[9][12] = '|'
    arr[8][0] = '|'
    arr[8][1] = ' '
    arr[8][2] = ' '
    arr[8][3] = ' '
    arr[8][4] = ' '
    arr[8][5] = ' '
    arr[8][6] = ' '
    arr[8][7] = ' '
    arr[8][8] = ' '
    arr[8][9] = ' '
    arr[8][10] = ' '
    arr[8][11] = ' '
    arr[8][12] = ' '
    arr[8][13] = '|'
    arr[7][0] = '|'
    arr[7][1] = ' '
    arr[7][2] = ' '
    arr[7][3] = ' '
    arr[7][4] = ' '
    arr[7][5] = ' '
    arr[7][6] = '|'
    arr[7][7] = '_'
    arr[7][8] = '_'
    arr[7][9] = '_'
    arr[7][10] = '_'
    arr[7][11] = '_'
    arr[7][12] = '_'
    arr[6][0] = ' '
    arr[6][1] = '_ '
    arr[6][2] = '_'
    arr[6][3] = '|'
    arr[6][4] = '_'
    arr[6][5] = '_'
    arr[5][0] = ' '
    arr[5][1] = ' '
    arr[5][2] = ' '
    arr[5][3] = '|'
    arr[4][0] = ' '
    arr[4][1] = ' '
    arr[4][2] = ' '
    arr[4][3] = '|'
    arr[3][0] = ' '
    arr[3][1] = ' '
    arr[3][2] = ' '
    arr[3][3] = '|'
    arr[2][0] = ' '
    arr[2][1] = ' '
    arr[2][2] = ' '
    arr[2][3] = '|'
    arr[1][0] = ' '
    arr[1][1] = ' '
    arr[1][2] = ' '
    arr[1][3] = '|'
    arr[1][4] = ' '
    arr[1][5] = ' '
    arr[1][6] = ' '
    arr[1][7] = ' '
    arr[1][8] = ' '
    arr[1][9] = ' '
    arr[0][0] = ' '
    arr[0][1] = ' '
    arr[0][2] = ' '
    arr[0][3] = ' '
    arr[0][4] = '_'
    arr[0][5] = '_'
    arr[0][6] = '_'
    arr[0][7] = '_'
    arr[0][8] = '_'
   

    word_list = ["alphabet","crowded","eating","candy","how","zombie","mutant","giraffe","clausterphobic","joking","watch","wrapper","can","supercalifragilisticexpialidocious",'loopy',"wisdom","teeth","runner","gaming","mobile","city","big","data","challenge"]
    
    name = input("What is your name? ")

    print("Hello, " + name, "time to play hangman!")

    print("")


    time.sleep(1)

    print("Start guessing...")
    time.sleep(0.5)

    
    x = random.randint(0,len(word_list))
    word = word_list[x]

    
    guesses = ''

    
    turns = 10

   
    while turns > 0:         


        failed = 0             

  
        for char in word:      

      
            if char in guesses:    
        
                print(char,end = ' '),    

            else:
        
                print("_",end = ' ')
        
                failed += 1    


        if failed == 0:        
            print("You won")  

            break              

        guess = input("guess a letter: ") 
        if guess == word:
                    print("You got it! You WON! Nice job!")
                    sys.exit()
        if len(guess)>1:
            print("Exiting now, you didnt enter an appropriate letter.")
            time.sleep(0.5)
            sys.exit()
        guesses += guess                    

        if guess not in word:  
    
            turns -= 1        
            if guess == word:
                    print("You got it! You WON! Nice job!")
    
            print("Wrong")
            if turns == 9:
                arr[1][4] = ' '
                arr[1][5] = ' '
                arr[1][6] = ' '
                arr[1][7] = ' '
                arr[1][8] = ' '
                arr[1][9] = '|'
                PrintHangmanSkeleton(arr)     
            elif turns == 8:
                    arr[2][4] = ' '
                    arr[2][5] = ' '
                    arr[2][6] = ' '
                    arr[2][7] = ' '
                    arr[2][8] = ' '
                    arr[2][9] = 'O'
                    PrintHangmanSkeleton(arr)
            elif turns == 7:
                    arr[3][4] = ' '
                    arr[3][5] = ' '
                    arr[3][6] = ' '
                    arr[3][7] = ' '
                    arr[3][8] = '/'
                    arr[3][9] = ' '
                    arr[3][10] = ' '
                    PrintHangmanSkeleton(arr)
            elif turns == 6:
                    arr[3][4] = ' '
                    arr[3][5] = ' '
                    arr[3][6] = ' '
                    arr[3][7] = ' '
                    arr[3][8] = '/'
                    arr[3][9] = '|'
                    arr[3][10] = ' '
                    PrintHangmanSkeleton(arr)
            elif turns == 5:
                    arr[3][4] = ' '
                    arr[3][5] = ' '
                    arr[3][6] = ' '
                    arr[3][7] = ' '
                    arr[3][8] = '/'
                    arr[3][9] = '|'
                    arr[3][10] = '\\'
                    PrintHangmanSkeleton(arr)       
            elif turns == 4:
                    arr[4][4] = ' '
                    arr[4][5] = ' '
                    arr[4][6] = ' '
                    arr[4][7] = ' '
                    arr[4][8] = ' '
                    arr[4][9] = '|'
                    PrintHangmanSkeleton(arr)
            elif turns == 3:
                    arr[5][4] = ' '
                    arr[5][5] = ' '
                    arr[5][6] = ' '
                    arr[5][7] = '__'
                    arr[5][8] = ' '
                    arr[5][9] = ' '
                    PrintHangmanSkeleton(arr)
            elif turns == 2:
                    arr[5][4] = ' '
                    arr[5][5] = ' '
                    arr[5][6] = ' '
                    arr[5][7] = '__'
                    arr[5][8] = '/'
                    arr[5][9] = ' '
                    PrintHangmanSkeleton(arr)
            elif turns == 1:
                    arr[5][4] = ' '
                    arr[5][5] = ' '
                    arr[5][6] = ' '
                    arr[5][7] = '__'
                    arr[5][8] = '/'
                    arr[5][9] = ' '
                    arr[5][10] = '\\ '
                    arr[5][11] = ' '
                    PrintHangmanSkeleton(arr)
            elif turns == 0:
                    arr[5][4] = ' '
                    arr[5][5] = ' '
                    arr[5][6] = ' '
                    arr[5][7] = '__'
                    arr[5][8] = '/'
                    arr[5][9] = ' '
                    arr[5][10] = '\\'
                    arr[5][11] = '__'
                    arr[5][12] = ' '
                    PrintHangmanSkeleton(arr)
         
    
            print( "You have", + turns, 'more guesses') 
    
            if turns == 0:           
        
                arr[2][9] = '0'
                PrintHangmanSkeleton(arr)
                print("You lose and you shall be hanged!")

def PrintHangmanSkeleton(arr):
    for r in arr:
        for c in r:
            print(c,end = "")
        print()

Hangman()