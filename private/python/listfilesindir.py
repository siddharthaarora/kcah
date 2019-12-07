import os

def listfiles(path):  
    for file in os.listdir(path):
        os.remove("newtemp.py")

listfiles(".")