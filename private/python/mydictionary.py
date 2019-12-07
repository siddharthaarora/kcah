# English to Spanish counting mappings

def engtospanishcounting(k, v):
    dictionary = dict()
    dictionary['one'] = 'uno'
    dictionary['two'] = 'dos'
    dictionary['three'] = 'tres'
    dictionary['four'] = 'quatro'
    dictionary['five'] = 'cinco'
    
    if k in dictionary:
        print('key found')
    
    for key in dictionary:
        if (dictionary[key] == v):
            print('value found')
            break

engtospanishcounting('two', 'seis')