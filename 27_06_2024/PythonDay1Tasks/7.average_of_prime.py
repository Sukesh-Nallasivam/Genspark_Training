def check_prime_number(number):
    for i in range(2, number):
        if number % i == 0:
            return False
    return True



sum = 0
count = 0
num_array=[]
for i in range(0,10):
    num=int(input("Enter a number: "))
    if check_prime_number(num):
        num_array.append(num)
        sum=sum+num
        count+=1
for i in num_array:
    print(i, end =" "),
print("are the prime numbers and count is :",count)
print("Average is",sum/count)

