# Allow the user to enter a sequence of non-negative numbers. 
# The user ends the list with a negative number. At the end the 
# sum of the non-negative numbers entered is displayed. 
# The program prints zero if the user provides no non-negative numbers.

def sumofpositivenumbers():
    number = 0
    sum = 0
    while 5 == 5:
        sum = sum + number
        print('sum: ', sum, 'number: ', number)
        number = eval(input('enter a number'))
    
    print('sum of non-negative numbers is: ', sum)
        

sumofpositivenumbers()
