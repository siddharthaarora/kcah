def fileoperation(filename):
    try:
        fhand = open(filename, "r")
        fhand.seek(949)
        print(fhand.readline())
    except:
        print("something went wrong!")
        
fileoperation("files_exercise4.txt")
    
