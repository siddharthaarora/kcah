import sys, pygame
pygame.init()
width, height = 320, 240
screen_size = width,height
speed = [2,2]
black = 0,0,0

screen = pygame.display.set_mode(screen_size)
ball = pygame.image.load("ball.gif")
ball_rect = ball.get_rect()

while True:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            sys.exit()
    ball_rect = ball.rect.move(speed)
    if ball_rect.left < 0 or ball.rect.right > width:
        speed[0] = -1*speed[0]
    if ball_rect.top<0 or ball.rect.bottom>height:
        speed[1] = -1*speed[1]  

    screen.fill(black)
    screen.blit(ball,ball.rect)
    pygame.display.flip()