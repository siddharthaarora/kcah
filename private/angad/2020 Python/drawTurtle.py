import turtle
class Square:
    def __init__(self,color,x,y):
        self.color = color
        self.x = self.y = y
        self.t = turtle.Turtle()
    def draw(self):
        self.t.speed(500)
        self.t.color(self.color)
        self.t.penup()
        self.t.goto(self.x,self.y)
        self.t.pendown()
        self.t.begin_fill()
        for i in range(4):
            self.t.forward(30)
            self.t.right(90)
        self.t.end_fill

import turtle
class Hexagon(Turtle):

    def __init__(self,x,y,color):
        
