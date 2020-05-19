from twython import Twython, TwythonError
import time

APP_KEY = 'YOUR KEY'
APP_SECRET = 'YOUR SECRET'
OAUTH_TOKEN = 'YOUR TOKEN'
OAUTH_TOKEN_SECRET = 'YOUR SECRET TOKEN'

twitter = Twython(APP_KEY, APP_SECRET, OAUTH_TOKEN, OAUTH_TOKEN_SECRET)

with open('liners.txt', 'r+') as tweetfile:
	buff = tweetfile.readlines()

for line in buff[:]:
	line = line.strip(r'\n') # Strips any empty line.
	if len(line)<=140 and len(line)>0:
		print ("Tweeting...")
		try:
			twitter.update_status(status=line)
		except TwythonError as e:
			print (e)
		with open ('liners.txt', 'w') as tweetfile:
			buff.remove(line) # Removes the tweeted line.
			tweetfile.writelines(buff)
		time.sleep(900)
	else:
		with open ('liners.txt', 'w') as tweetfile:
			buff.remove(line) # Removes the line that has more than 140 characters.
			tweetfile.writelines(buff)
		print ("Skipped line - Too long for a tweet!")
		continue
print ("No more lines to tweet...") # When you see this... Well, go find some new tweets...