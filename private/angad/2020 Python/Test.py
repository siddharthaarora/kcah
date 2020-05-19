#alphabet='abcdefghijklmnopqrstuvwxyz'
#cipherText='''odmhxf dmzqa, ljqruh wkrvh iluvw wzr zrugv wkhb duh mxvw wkhuh wr 
#frqixvh d fudfnhu. dqbzdb wkh vhfuhw phvvdjh lv,
#qrergb hashfwv wkh vsdqlvk lqtxlvlwlrq'''
#position = 7
#for i in range (1,26): #loop through i
plaintext='' #set plaintext to blank
#for letter in cipherText: #for each letter in cypherText

    if letter !=alphabet: #if the letter is not in the alphabet
        shiftedLetter=letter #set the shiftedletter to the letter
    else:
        position=alphabet.index(letter) 
    shiftedIndex= position + i
    shiftedLetter = alphabet[shiftedIndex]
    plainText+=shiftedLetter
    print('With a shift of',i,' the message is \n\n', plainText,'\n')



def encrypt(text,s):
    result = ""
        # transverse the plain text
   for i in range(len(text)):
      char = text[i]
      # Encrypt uppercase characters in plain text
      
      if (char.isupper()):
         result += chr((ord(char) + s-65) % 26 + 65)
      # Encrypt lowercase characters in plain text
      else:
         result += chr((ord(char) + s - 97) % 26 + 97)
      return result
#check the above function
text = "CEASER CIPHER DEMO"
s = 4

print "Plain Text : " + text
print "Shift pattern : " + str(s)
print "Cipher: " + encrypt(text,s)