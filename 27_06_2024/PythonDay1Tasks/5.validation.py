import datetime

def validate_name(name):
    return len(name.strip()) > 0

def validate_year(year):
    try:
        year = int(year)
        return len(str(year)) == 4
    except ValueError:
        return False

def validate_month(month):
    try:
        month = int(month)
        return 1 <= month <= 12
    except ValueError:
        return False

def validate_day(day, month, year):
    try:
        day = int(day)
        datetime.datetime(year, month, day)
        return 1 <= day <= 31
    except ValueError:
        return False

def validate_phone(phone):
    return phone.isdigit() and len(phone) == 10

while True:
    name = input("Enter your name: ")
    if validate_name(name):
        break
    else:
        print("Invalid name. Please try again.")

while True:
    year_input = input("Enter your birth year (YYYY): ")
    if validate_year(year_input):
        year = int(year_input)
        break
    else:
        print("Invalid year format. Please enter a valid 4-digit year.")

while True:
    month_input = input("Enter your birth month (1-12): ")
    if validate_month(month_input):
        month = int(month_input)
        break
    else:
        print("Invalid month. Please enter a number between 1 and 12.")

while True:
    day_input = input("Enter your birth day (1-31): ")
    if validate_day(day_input, month, year):
        day = int(day_input)
        break
    else:
        print("Invalid day. Please enter a valid day for the selected month and year.")

date_of_birth = datetime.datetime(year, month, day)

if date_of_birth > datetime.datetime.now():
    print("Invalid birthdate. Please enter a birthdate that is not in the future.")
    exit()

date_of_birth_str = date_of_birth.strftime("%m/%d/%Y")

phone = input("Enter your phone number (10 digits only): ")

while not validate_phone(phone):
    print("Invalid phone number. Please enter a 10-digit number.")
    phone = input("Enter your phone number (10 digits only): ")

print("Hi, " + name)
print("Your date of birth is " + date_of_birth_str)
print("Your phone number is " + phone)

current_date = datetime.datetime.now()
age = current_date.year - date_of_birth.year - ((current_date.month, current_date.day) < (date_of_birth.month, date_of_birth.day))
print("Your age is " + str(age))
