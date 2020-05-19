import turtle

tim = turtle.Turtle()

tim.shape('turtle')

num_sides = 6
side_len = 69
angle = 360/num_sides

for i in range (num_sides):
    tim.speed(55555555)
    tim.forward(side_len)
    tim.right(angle)

turtle.done()