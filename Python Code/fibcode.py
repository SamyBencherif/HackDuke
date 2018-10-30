def recurse(input):
        if(input < 2):
                return 1
        else:
                return recurse(input-1) + recurse(input-2)
