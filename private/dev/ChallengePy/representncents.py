# Coins: Given an infinite number of quarters (25 cents), dimes (10 cents), nickels (5 cents), and
# pennies (1 cent), write code to calculate the number of ways of representing n cents.

def RepresentNCents(n):
    coins = [25, 10, 5, 1]
    i = 0
    numWays = [0]
    while i < len(coins):
        cointCount = int(n / coins[i])
        for cc in range (0, cointCount):
            CountRepresentNCentsUsingMaxCoin(n, coins, i, cc, numWays)
        i = i+1
    print("Number of ways to represent", n, "cents is: ", numWays)

def CountRepresentNCentsUsingMaxCoin(n, coins, i, coinCount, numWays):
    print(n, coins[i], coinCount, numWays)
    
    n = n - (coins[i] * coinCount)
    n = n % coins[i]

    if (n > 0):
        CountRepresentNCentsUsingMaxCoin(n, coins, i+1, coinCount-1, numWays)
    else:
        numWays[0] = numWays[0] + 1

RepresentNCents(34)