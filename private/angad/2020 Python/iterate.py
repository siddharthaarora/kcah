# EXAMPLE CLASS
class Student:
    # This method is called a constructor! It is the way you
    # create (or "initialize") an object. You have to tell the
    # constructor all the pieces of info it asks for in the
    # function signature (name, age, etc).
    def __init__(self, name, age, fav_color, fav_team):

        # You then have to save these values to the property  fields
        # for your class. Remember, when accessing something that
        # belongs to your class, you have to say "self" first.
        self.name = name
        self.age = age
        self.fav_color = fav_color
        self.fav_team = fav_team

    # Every method that belongs to your class has to take at least
    # one value in its signature: itself! Below, this function
    # needs "self". See main() (Line 49) how to use the function.
    def say_introduction(self):
        print("Hello, my name is", self.name, "!")
        print("My favorite color is", self.fav_color, ".")
        print("My favorite team is the", self.fav_team, ".")


''' HERE'S YOUR BONUS HOMEWORK'''
#PART 0: Read in the main() function what the student class is
#         expected to do! (Lines 54+)
#
#Class Student:
#
#    # PART 1: which values go in the signature??    
#    def __init__(self, ???):
#        # PART 2: assign those values!
#        
#    def say_introduction(self):
#        # PART 3: write this function!


def main():
    
    # Here we create a new Teacher object using the constructor we 
    # wrote above. We gave it all the things it said it needs to know
    # and it spits out an "instance" of our class.
    student_angad = student("angad", 12, "Blue", "Seattle Seahawks")

    # To call a method for a specific "instance", we use the following
    # "dot" notation ("teacher kabir dot say introduction"):
    student_angad.say_introduction()

    # You can also access the properties with the same dot notation!
    print("Angad is", student_angad.age, "years old!")

    ''' HERE'S YOUR BONUS HOMEWORK '''
    #PART 1: make your student with the right values! 
    # (You have to figure out what these are!)
    #your_student = Student(???)

    # PART 2: call the say_introduction() method 
    #your_student.say_introduction()
    # I want the output to be:
    # Hello, my name is [YOUR NAME]
    # I am [YOUR AGE] years old!

    # PART 3: Do something else fun :) 


if __name__ == "__main__":
    main()
