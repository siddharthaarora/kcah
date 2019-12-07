answer = input("has power?")
if (answer == "yes"):
    print("seek other help")
else:
    answer = input("is plugged in?")
    if (answer == "no"):
        print("plug it in")
    else:
        answer = input("is the switch on?")
        if (answer == "no"):
            print("turn it on")
        else:
            answer = input("fuse ok?")
            if (answer == "no"):
                print("check fuse")
            else:
                print("seek other help")

        
    