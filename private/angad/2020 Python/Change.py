#this function takes a string and encrypts ONLY letters by k shifts
def CaeserCipher(string, k):
    #setting up variables to move through
    upper = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
    lower = 'abcdefghijklmnopqrstuvwxyz'

    newCipher = ''
k=7
    #looping each letter and moving it k times
for letter in string:
    if letter in upper:
        if upper.index(letter) + k > 25:
            IndexPosition = (upper.index(letter) + k) 
            newCipher = newCipher + upper[indexPosition]
        else:
            indexPosition = upper.index(letter) + k
            newCipher = newCipher + upper[indexPosition]
elif letter in lower:
            if lower.index(letter) + k > 25:

                indexPosition = (lower.index(letter) + k)  
                newCipher = newCipher + lower[indexPosition]
            else:
                indexPosition = lower.index(letter) + k
                newCipher = newCipher + lower[indexPosition]
        else:
            newCipher = newCipher + letter


    return newCipher

f = open('encrypted.txt', "r")
dictionary = set()
for line in f:
    word = line.strip()
    dictionary.add(word)
print(dictionary)

#main file
#reading file and encrypting text

f = open('encrypted.txt')
string = ''
out = open("decoded.txt", "w")
myList = []
for line in f:
    myList.append(line)

for sentence in myList:
    for k in range(26):
        updatedSentence = CaeserCipher(sentence, k)
        for word in updatedSentence.split():
            if word in dictionary:
                out.write(updatedSentence)
                break
print(myList)
f.close()
out.close()        