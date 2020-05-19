import turtle
from Square import square
screen = turtle.Screen()
screen.bg("light green")
screen.setup(600,500)
screen.tracer(0)


x = 0
y = 0
color = 'red'

while True:
    square = Square(x, y, color)
    square.draw()
    square.clear()
    del square 


turtle.done()
