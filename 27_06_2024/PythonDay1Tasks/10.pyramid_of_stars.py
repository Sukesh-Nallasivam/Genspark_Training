num = int(input("Enter number of rows: "))

for i in range(1,num+1):
    for j in range(0,num-i):
        print(" ",end="")
    for j in range(1,i*2):
        print("*",end="")
    print()