number_of_bldgs = input('Enter number of buildings: ')
number_of_ninjas = input('Enter number of ninjas: ')

number_of_tunnels = input('Enter number of tunnels: ')
number_of_samurais = input('Enter number of samurais: ')

total_fighters_in_bldg = number_of_bldgs * number_of_ninjas
total_fighters_in_tunnel = number_of_tunnels * number_of_samurais

print("Total number of fighters: ", total_fighters_in_bldg + total_fighters_in_tunnel)