heightft = input("Enter your height (feet): ")    
heightin = input("Enter your height (inches): ")
weight = input("Enter your weight (pounds): ")

if heightft == "" or heightin =="":
    print ("Please enter your height.")
    exit()
    
if weight == "":
    print ("Please enter your weight.")
    exit()

if heightft or heightin or weight == int or float:
    
    
    heightft = float(heightft)
    heightin = float(heightin)
    weight = float(weight)

    if heightft <0 or heightin <0:
        print ("You cannot possibly have a negative height!")
        exit()
    if heightft < 3:
        print ("Standing " + str(heightft) + " feet tall you must be a child; this is an adult BMI calcuator!")
        exit()
    if heightft > 10:
        print ("Are you really " + str(heightft) + " feet tall ?!")
        exit()
    if heightin > 12:
        print ("Your height in inches shouldn't exceed 12!")
        exit()
    if weight < 0:
        print ("Your weight can only be negative in Theoretical Physics..., NOT in real life.")
    if weight  < 30:
        print ("Weighing " + str(weight) + " lbs, you must be a child; this is an adult BMI calcuator!")
        exit()
    if weight > 1500:
        print ("Do you really weigh " + str(weight) + " pounds?!")
        exit()


    height = heightft*12 + heightin  
    

    thisBMI =  round((weight /(height*height)) * 703.06957964,2)

    if thisBMI < 18.5: 
        print ("Your BMI is ", thisBMI, " Underweight - eat a pizza!")
    elif  18.5 <= thisBMI <= 24.99:
        print ("Your BMI is ", thisBMI, " - Normal, keep it up!")
    elif  25 <= thisBMI <= 29.99:
        print ("Your BMI is ", thisBMI, " - Overweight, exercise more!")
    elif 30 <= thisBMI <=  39.99:
        print ("Your BMI is ", thisBMI, " - Obese, get off the couch!")
    elif thisBMI >=40:
        print ("Your BMI is ", thisBMI, " - Morbidly Obese - take action!")
    else:  
        print("Please check your input values, BMI cannot be calculated.")
else:
    print("We don't want your information in hexadecimal only in decimal form please!")
    exit()