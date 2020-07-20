import sys, time, pygame, random

# GAME MANAGER OBJECT
GM = None
GAME_STARTED = False
GAME_ENDED = False

# TEXT VARIABLES
FONT = None
START_FONT_SIZE = 40
START_TEXT = None
START_TEXT_RECT = None

SCORE_FONT_SIZE = 20
SCORE_TEXT = None
SCORE_TEXT_RECT = None

# COLORS
black = 0, 0, 0
white = 255, 255, 255
red = 255, 0, 0
blue = 0, 255, 0
green = 0, 0, 255

# SCREEN
SCREEN = None
SCREEN_SIZE = WIDTH, HEIGHT = 600, 400

IS_PAUSED = False

# BALL
BALL = None
BALL_RECT = None
BALL_SPEED = None

# PADDLE
PADDLE_W = 10
PADDLE_H = 100

LEFT_PADDLE_X = 25
LEFT_PADDLE_Y = HEIGHT / 2 - PADDLE_H / 2

RIGHT_PADDLE_X = WIDTH - 25
RIGHT_PADDLE_Y = LEFT_PADDLE_Y

####################################################################################################

def random_number(min_num, max_num):
    num_range = max_num - min_num

    random_number = (random.random() - 0.5) * 2 * num_range
    random_number + min_num

    return random_number

####################################################################################################

# create the pygame window and set title
def init_game_window():
    global SCREEN
    SCREEN = pygame.display.set_mode(SCREEN_SIZE) 
    pygame.display.set_caption('KGS Pong')

# initialize the text objects
def init_text():
  global FONT

  global START_TEXT
  global START_TEXT_RECT

  global SCORE_TEXT
  global SCORE_TEXT_RECT

  # initialize the font
  FONT = pygame.font.Font('freesansbold.ttf', SCORE_FONT_SIZE) 

  # create the text object 
  START_TEXT = FONT.render("Welcome to Pong! Press 'G' to GO!", True, white, black)
  # get its rectangle and set to center of screen
  START_TEXT_RECT = START_TEXT.get_rect()
  START_TEXT_RECT.center = (WIDTH // 2, HEIGHT // 2)

  # create score text object 
  SCORE_TEXT = FONT.render('0 - 0', True, white, black)
  # get its rectangle and set to bottom of screen
  SCORE_TEXT_RECT = SCORE_TEXT.get_rect()
  SCORE_TEXT_RECT.center = (WIDTH // 2, HEIGHT - SCORE_FONT_SIZE)


# initialize the ball image
def load_ball_image():
    global BALL
    global BALL_RECT
    global BALL_SPEED

    BALL = pygame.image.load("intro_ball.gif")
    BALL_RECT = BALL.get_rect()

    BALL_RECT.left = WIDTH / 2
    BALL_RECT.top = HEIGHT / 2

    BALL_SPEED = [random_number(-3, 3), random_number(-3, 3)]

####################################################################################################

def listen_for_events():
    global IS_PAUSED
    global LEFT_PADDLE_Y
    global RIGHT_PADDLE_Y
    global BALL_SPEED
    global GAME_STARTED
    global GAME_ENDED

    for event in pygame.event.get():
        if event.type == pygame.QUIT: 
            sys.exit()
        elif event.type == pygame.KEYDOWN:
            
            # if game hasn't started + press 'g' --> start game
            if event.key == pygame.K_g and not GAME_STARTED:
              GAME_STARTED = True
              load_ball_image()
              GM.play_game()

            # if press 'q' and game has ended, quit
            if event.key == pygame.K_q and GAME_ENDED:
              sys.exit() 

            # if press 'r' and game has ended, reset
            if event.key == pygame.K_r and GAME_ENDED:
              GAME_ENDED = False
              GAME_STARTED = True
              GM.reset_game()

            # FOR DEBUGGING, press 'space' to pause and reset ball direction
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

    ball_center_x = BALL_RECT.left + BALL_RECT.right / 2
    ball_center_y = BALL_RECT.top + BALL_RECT.bottom / 2
    BALL_RECT = BALL_RECT.move_ball(ball_center_x, ball_center_y)
    
    # Left paddle collision
    l_paddle_rect = pygame.Rect(LEFT_PADDLE_X, LEFT_PADDLE_Y, PADDLE_W, PADDLE_H)
    if BALL_RECT.colliderect(l_paddle_rect):
        BALL_SPEED[0] *= -1.1

    # Right paddle collision
    r_paddle_rect = pygame.Rect(RIGHT_PADDLE_X, RIGHT_PADDLE_Y, PADDLE_W, PADDLE_H)
    if BALL_RECT.colliderect(r_paddle_rect):
        BALL_SPEED[0] *= -1.1
       
    # Top/Bottom of screen collision
    if BALL_RECT.top < 0 or BALL_RECT.bottom > HEIGHT:
        BALL_SPEED[1] *= -1.1

    # RIGHT SCORES
    if BALL_RECT.left < 0:
      GM.score_point("LEFT")
      
    # LEFT SCORES
    if BALL_RECT.right > WIDTH:
      GM.score_point("RIGHT") 
      # HANDLE THE BALL HITTING THE RIGHT SIDE OF SCREEN
        

def update_screen():
    global SCREEN

    SCREEN.fill(green)

    # if the game has started or ended, display start/end information text only
    if not GAME_STARTED or GAME_ENDED:
      SCREEN.blit(START_TEXT, START_TEXT_RECT)
    # if the game is playing, show the score and ball only
    else:
      SCREEN.blit(BALL, BALL_RECT)
      SCREEN.blit(SCORE_TEXT, SCORE_TEXT_RECT)

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

####################################################################################################

class GameManager():
  
  def __init__(self):
    self.left_score = 0
    self.right_score = 0
    self.winning_score = 5
    
  def initial_setup(self):
    pygame.init()
    init_game_window()
    init_text()
    load_ball_image()

  def play_game(self):
    while 1:
        listen_for_events()
        move_ball()
        update_screen()

  def score_point(self, scorer):   
    global SCORE_TEXTS
    if scorer == "LEFT":
      # increment score
      self.left_score += 1

      # update the score string
      score_string = '{} - {}'.format(self.left_score, self.right_score)
      SCORE_TEXT = FONT.render(score_string, True, white, black)

      # HANDLE IF REACHING WINNING SCORE
      if self.left_score == 5:
        
        print("YOU WON!")
        GAME_ENDED == True
        

    if scorer == "RIGHT":
      # increment score
      self.right_score += 1

      score_string = '{} - {}'.format(self.left_score, self.right_score)
      SCORE_TEXT = FONT.render(score_string, True, white, black)

      # HANDLE IF REACHING WINNING SCORE
      if self.right_score == 5:
        self 
        print("YOU LOST")
        GAME_ENDED == True
    # regardless of who scored, reset ball
    self.ball_reset()

  def ball_reset(self):
    global BALL_RECT
    global BALL_SPEED

    # PUT THE BALL IN THE MIDDLE OF THE SCREEN
    BALL_RECT.top == HEIGHT / 2
    BALL_RECT.left == WIDTH / 2
    

    # SET THE BALL SPEED TO SOME RANDOM NUMBERS
    BALL_SPEED == 4


  def draw_victory_screen(self, scorer):
    global BALL_RECT
    global START_TEXT
    global GAME_ENDED

    # MOVE BALL OFF THE SCREEN (set top/left to a number that wouldn't show up on the screen)
    BALL_RECT.left == 99999999242343242353
    BALL_RECT.top == 999999999999999910845

    start_string = "{} wins! Press 'q' to quit, 'r' to restart".format(scorer)
    START_TEXT = FONT.render(start_string, True, white, black)
    GAME_ENDED = True

  def reset_game(self):
    global SCORE_TEXT
    # RESET THE BALL
    BALL_RECT.top == HEIGHT / 2
    BALL_RECT.left == WIDTH / 2

    # RESET THE SCORE VARIABLES
    SCORE_TEXT_RECT == "0"


    score_string = '{} - {}'.format(self.left_score, self.right_score)
    SCORE_TEXT = FONT.render(score_string, True, white, black)

####################################################################################################

def main():
  
  global GM
  GM = GameManager()
  GM.initial_setup()
  GM.play_game()


if __name__ == "__main__":
    main()
