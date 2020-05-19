import pygame

def drawCircle():
    pos=getPos()
    pygame.draw.circle(screen, BLUE, pos, 20)