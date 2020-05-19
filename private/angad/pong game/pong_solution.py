import sys, time, pygame, random

black = 0, 0, 0
white = 255, 255, 255
red = 255, 0, 0
blue = 0, 255, 0
green = 0, 0, 255

SCREEN = None
SCREEN_SIZE = WIDTH, HEIGHT = 600, 400

IS_PAUSED = False

BALL = None
BALL_RECT = None
BALL_SPEED = None

PADDLE_W = 10
PADDLE_H = 100

LEFT_PADDLE_X = 25
LEFT_PADDLE_Y = HEIGHT / 2 - PADDLE_H / 2

RIGHT_PADDLE_X = WIDTH - 25
RIGHT_PADDLE_Y = LEFT_PADDLE_Y

def random_number(min_num, max_num):
    num_range = max_num - min_num

    random_number = (random.random() - 0.5) * 2 * num_range
    random_number + min_num

    return random_number


def init_game_window():
    global SCREEN

    SCREEN = pygame.display.set_mode(SCREEN_SIZE) 


def load_ball_image():
    global BALL
    global BALL_RECT
    global BALL_SPEED

    BALL = pygame.image.load("intro_ball.gif")
    BALL_RECT = BALL.get_rect()

    BALL_RECT.left = WIDTH / 2
    BALL_RECT.top = HEIGHT / 2

    BALL_SPEED = [random_number(-3, 3), random_number(-3, 3)]

def listen_for_events():
    global IS_PAUSED
    global LEFT_PADDLE_Y
    global RIGHT_PADDLE_Y
    global BALL_SPEED

    for event in pygame.event.get():
        if event.type == pygame.QUIT: 
            sys.exit()
        elif event.type == pygame.KEYDOWN:

            if event.key == pygame.K_SPACE:
                if IS_PAUSED:
                    BALL_SPEED = [random_number(-2, 2), random_number(-2, 2)]
                    IS_PAUSED = False 
                else:
                    BALL_SPEED = [0,0]
                    IS_PAUSED = True 

            if event.key == pygame.K_w:
                LEFT_PADDLE_Y = max(LEFT_PADDLE_Y - 10, 0)
            elif event.key == pygame.K_s:
                LEFT_PADDLE_Y = min(LEFT_PADDLE_Y + 10, HEIGHT)

            if event.key == pygame.K_u:
                RIGHT_PADDLE_Y = max(RIGHT_PADDLE_Y - 10, 0)
            elif event.key == pygame.K_j:
                RIGHT_PADDLE_Y = min(RIGHT_PADDLE_Y + 10, HEIGHT)


def move_ball():
    global BALL
    global BALL_RECT
    global BALL_SPEED

    BALL_RECT = BALL_RECT.move(BALL_SPEED)

    ball_center_x = BALL_RECT.left + BALL_RECT.right / 2
    ball_center_y = BALL_RECT.top + BALL_RECT.bottom / 2
    
    l_paddle_rect = pygame.Rect(LEFT_PADDLE_X, LEFT_PADDLE_Y, PADDLE_W, PADDLE_H)
    if BALL_RECT.colliderect(l_paddle_rect):
        BALL_SPEED[0] *= -1

    r_paddle_rect = pygame.Rect(RIGHT_PADDLE_X, RIGHT_PADDLE_Y, PADDLE_W, PADDLE_H)
    if BALL_RECT.colliderect(r_paddle_rect):
        BALL_SPEED[0] *= -1
       
    if BALL_RECT.top < 0 or BALL_RECT.bottom > HEIGHT:
        BALL_SPEED[1] *= -1

        
def update_screen():
    global SCREEN

    SCREEN.fill(green)
    SCREEN.blit(BALL, BALL_RECT)

    paddle_left = pygame.draw.rect(
        SCREEN, 
        white, 
        (LEFT_PADDLE_X, LEFT_PADDLE_Y, PADDLE_W, PADDLE_H)
    )

    paddle_right = pygame.draw.rect(
        SCREEN, 
        white, 
        (RIGHT_PADDLE_X, RIGHT_PADDLE_Y, PADDLE_W, PADDLE_H)
    )

    pygame.display.update()

def main():

    pygame.init()
    init_game_window()
    load_ball_image()

    while 1:
        listen_for_events()
        move_ball()
  :q
  :q
  exit
        update_screen()


if __name__ == "__main__":
    main()
