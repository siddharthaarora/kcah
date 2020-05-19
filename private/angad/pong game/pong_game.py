import sys, time, pygame, random
pygame.mixer.load("")
# GAME MANAGER OBJECT
GM = None
GAME_STARTED = False
GAME_ENDED = False
keyw_State = False
keys_State = False
keyu_State = False
keyj_State = False
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
  START_TEXT = FONT.render("HAHA DO YOUR HOMEWORK! DON'T THINK YOU KNOW HOW TO FIX IT!", True, white, black)
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

    BALL = pygame.image.load("ball.gif")
    pygame.transform
    BALL_RECT = BALL.get_rect()

  

    BALL_SPEED = [random_number(-3, 3), random_number(-3, 3)]

####################################################################################################



    # RIGHT SCORES
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
        move_ball(self)
        update_screen()

  def score_point(self, scorer):
    
    global SCORE_TEXT
    
    if scorer == "LEFT":
      # increment score
      self.left_score += 1
      # update the score string
      score_string = '{} - {}'.format(self.left_score, self.right_score)
      SCORE_TEXT = FONT.render(score_string, True, white, black)

      # HANDLE IF REACHING WINNING SCORE
      if self.left_score >= self.winning_score:
            winner = 'left'
            GAME_ENDED = True
          

    if scorer == "RIGHT":
      self.right_score+=1
      
      if BALL_RECT.x <= 0: 
        self.left_score += 1

      score_string = '{} - {}'.format(self.left_score, self.right_score)
      SCORE_TEXT = FONT.render(score_string, True, white, black)

      # HANDLE IF REACHING WINNING SCORE
      if self.left_score >= self.winning_score:
        winner = 'right'
        GAME_ENDED = True
    
    # regardless of who scored, reset ball
    self.ball_reset()

  def ball_reset(self):
    global BALL_RECT
    global BALL_SPEED

    # PUT THE BALL IN THE MIDDLE OF THE SCREEN
    BALL_RECT.left = WIDTH / 2
    BALL_RECT.top = HEIGHT / 2

    # SET THE BALL SPEED TO SOME RANDOM NUMBERS
    BALL_SPEED = [random_number(-3, 3), random_number(-3, 3)]


  def draw_victory_screen(self, scorer):
    global BALL_RECT
    global START_TEXT
    global GAME_ENDED

    # MOVE BALL OFF THE SCREEN (set top/left to a number that wouldn't show up on the screen)
    BALL_RECT.left = 700
    BALL_RECT.top = 99999

    start_string = "{} wins! Press 'q' to quit, 'r' to restart".format(scorer)
    START_TEXT = FONT.render(start_string, True, white, black)
    GAME_ENDED = True

  def reset_game(self):
    global SCORE_TEXT
    # RESET THE BALL
    self.ball_reset()

    # RESET THE SCORE VARIABLES
    self.left_score = 0
    self.right_score = 0

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
