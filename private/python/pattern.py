str = "X-DSPAM-Confidence:0.439"
# newStr = str.replace("X-DSPAM-Confidence:","")
# print(newStr)
i = 0
while (i < len(str)):
    if (i >= 19):
        print(str[i], end="")
    i = i + 1