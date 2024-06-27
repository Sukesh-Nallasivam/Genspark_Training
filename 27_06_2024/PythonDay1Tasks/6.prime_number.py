def check_prime_number(number):
    for i in range(2, number):
        if number % i == 0:
            return False
    return True




num=int(input("Enter a number: "))
print("Your number is "+{(check_prime_number(num)):"Prime number"}.get(True,"not a prime"))