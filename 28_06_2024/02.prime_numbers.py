def check_prime_number(number):
    for i in range(2, number):
        if number % i == 0:
            return False
    return True




count = 0
num_array=[]
num=int(input("Enter a number: "))
for i in range(1,num+1):
    if check_prime_number(i):
        num_array.append(i)
        count+=1
for i in num_array:
    print(i, end =" "),
print("are the prime numbers\nCount is :",count)
