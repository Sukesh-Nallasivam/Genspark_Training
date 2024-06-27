import datetime
name= str(input("Enter your name: "))
year = int(input("Enter your birth year: "))
month = int(input("Enter your birth month from (1-12): "))
day = int(input("Enter your birth date: "))
date_of_birth= datetime.datetime(year,month,day)
date_of_birth_str = date_of_birth.strftime("%m/%d/%Y")
current_date = datetime.datetime.now()
age = current_date.year - date_of_birth.year - ((current_date.month,current_date.date)<(date_of_birth.month,date_of_birth.date))
phone= (input("Enter your phone number: "))


print("Hi, "+name)
print("Your age is "+str(age))
print("Your date of birth is "+date_of_birth_str)
print("Your phone number is "+phone)