name = input("Enter your name: ")
gender = input("Enter your gender: ").lower()
if gender == "male":
    saluation = "Mr"
elif gender == "female":
    saluation = "Mrs"
else:
    saluation = ""

print("Welcome "+ saluation + " "+ name)