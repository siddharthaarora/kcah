import sys, time, pygame, random

black = 0, 0, 0
red = 1, 0, 0
green = 0, 1, 0
blue = 0, 0, 1
white = 1, 1, 1

pygame.init()

size = width, height = 400, 400
screen = pygame.display.set_mode(size)

ball = pygame.image.load("intro_ball.gif")
ballrect = ball.get_rect()

ball_paused = False
ballspeed = True

## RANDOM NUMBER GEN
def random_number(min_num, max_num):
    num_range = max_num - min_num

    random_number = (random.random() - 0.5) * 2 * num_range
    random_number + min_num

    return random_number

# EXAMPLE REFACTORED FUNCTION
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


while 1:

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

        # CLICKING
        elif event.type == pygame.MOUSEBUTTONDOWN:
            print("You clicked!")

            mouseX, mouseY = pygame.mouse.get_pos()

            if mouseX > ballrect.left and mouseX < ballrect.right and \
               mouseY > ballrect.top  and mouseY < ballrect.bottom:
                print("You win!")
                ball_speed = [0, 0]
            else:
                ball_speed[0] = min(ball_speed[0] * 1.1, 5.0)
                ball_speed[1] = min(ball_speed[1] * 1.1, 5.0)
                print("You missed! Increasing speed to: ", ball_speed)


    move_ball()

    ## SCREEN UPDATE
    screen.fill(black)
    screen.blit(ball, ballrect)
    pygame.display.flip()

    ## NOTE READ ME ##
    ## If your ball is moving around your screen way too fast, 
    ## try uncommenting the line of code below.

    # time.sleep(0.005)

