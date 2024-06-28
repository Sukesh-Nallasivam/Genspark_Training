def digit_sum(num):
    sum = 0
    num=num*2

    if num>=10:
        sum = sum+(num%10)
        sum = sum+(num//10)
        return sum

    return num
def card_validation_check(card_number):
    if not card_number.isdigit():
        return False
    length = len(card_number)
    is_second=False;
    first_sum=0
    second_sum=0
    for i in range(length-1, -1, -1):

        if (is_second):
            # print(card_number[i],end=" ")
            sum = digit_sum(int(card_number[i]))
            second_sum += sum
            is_second = False
        else:
            # print(card_number[i])
            first_sum+=int(card_number[i])
            is_second = True

    if((first_sum+second_sum)%10==0):
        return True
    return False


#Luhn check algorithm
card_number = input('Enter your card number: ').replace(" ","")
print({card_validation_check(card_number):"Valid"}.get(True,"InValid"),"Card ")