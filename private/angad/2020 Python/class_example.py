import random

def function1():
  print("hola, mi amigos!")

def function2():
  print("swiper, no swiping!")

def function3(a):
  if function5(a):
    return True
  else:
    return False

def function4():
  print("jackpot!")

def function5(b):
  if b == function6(b):
    return True
  else:
    return False

def function6(c):
  return c * c == c

def main():
  print("hello, world!")
  
  arr = [-2,-1,0,1,2]
  #for i in range(0, 100):
  # arr.append(random.randint(1, 200) - 100)

  for x in arr:
    print(x, end = " ")
    if x % 2 == 0 and x != 0:
      function1()
    elif x % 3 == 0 and x != 0:
      function2()
    elif function3(x):
      function4()


if __name__ == "__main__":
  main()
