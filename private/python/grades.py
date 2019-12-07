def grades(n):
    grade = "invalid"
    if (n < 35):
        grade = "F"
    elif(n < 50):
        grade = "D"
    elif(n < 80):
        grade = "C"
    elif(n<95):
        grade = "B"
    else:
        grade = "A"
    print(grade)
    