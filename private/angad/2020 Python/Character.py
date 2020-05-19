def w(word):
  c = 0

  for w in word:
    if len(w) > 1 and w[0] == w[-1]:
      c += 1
  return c

    print(w(['long', 'short', 'i' ])