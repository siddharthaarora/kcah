import sys, pygame, time, random


def move_ball():

    global ballrect
    global ballspeed

    ballrect = ballrect.move(ball_speed)

    if ballrect.left < 0 or ballrect.right > width:
        ball_speed[0] = -ball_speed[0]
    if ballrect.top < 0 or ballrect.bottom > height:
        ball_speed[1] = -ball_speed[1]



speed_x = random_number(-2, 2)
speed_y = random_number(-2, 2)
ball_speed = [speed_x, speed_y]

WHILE 1:

    ## LOOKING FOR EVENTS ##
    for event in pygame.event.get():
        # QUIT
        if event.type == pygame.QUIT: 
            sys.exit()
        # PAUSE BALL
        elif event.type == pygame.KEYDOWN:
            if event.key == pygame.K_SPACE:
                if ball_paused:
                    ball_speed = [random_number(-2, 2), random_number(-2, 2)]
                    ball_paused = False
                else:
                    ball_speed = [0,0]
                    ball_paused = True