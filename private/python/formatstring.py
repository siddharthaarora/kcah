def formatstring(name, street, city, state):
    f = "hi, my name is %s. I am living at %s in %s city in %s state" % (name, street, city, state)
    print(f)

formatstring('sid', '123 street', 'redmond', 'wa')
formatstring('joe', '456 street', 'new york', 'ny')