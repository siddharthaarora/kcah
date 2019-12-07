def ConvertCelciusToFar(c):
     try:
          temperature_in_fahrenheit = c * 9/5 +32
          print("Temperature in Fahrenheit is: ", temperature_in_fahrenheit)
     except:
          print("something went wrong!")


ConvertCelciusToFar(32)
ConvertCelciusToFar(56)
ConvertCelciusToFar(45)
ConvertCelciusToFar(0)
ConvertCelciusToFar(67)
