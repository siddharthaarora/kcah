import turtle 

painter = turtle.Turtle()

painter.pencolor("blue")

for i in range(50):
    painter.forward(50)
    painter.left(123) 
    
painter.pencolor("red")
for i in range(50):
    painter.forward(100)
    painter.left(123)
    
painter.pencolor("green")
for i in range(50):
    painter.forward(150)
    painter.left(123)
painter.pencolor("navy")
for i in range(50):
    painter.forward(200)
    painter.left(123)
painter.pencolor("yellow")
for i in range(50):
    painter.forward(250)
    painter.left(123)
painter.pencolor("red")
for i in range(50):
    painter.forward(300)
    painter.left(123)
painter.pencolor("Hot Pink")
for i in range(50):
    painter.forward(350)
    painter.left(123)


turtle.done()