import datetime
import csv
import pandas as pd
from openpyxl import Workbook
from fpdf import FPDF


def validate_email(email):
    # Basic email validation using a simple regex
    import re
    return re.match(r'[^@]+@[^@]+\.[^@]+', email) is not None


def calculate_age(dob):
    # Calculate age based on date of birth
    today = datetime.date.today()
    age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
    return age


def get_employee_details():
    name = input("Enter Employee Name: ")
    dob_str = input("Enter Date of Birth (YYYY-MM-DD): ")
    try:
        dob = datetime.datetime.strptime(dob_str, "%Y-%m-%d").date()
    except ValueError:
        print("Invalid date format. Please enter date in YYYY-MM-DD format.")
        return None

    phone = input("Enter Phone Number: ")

    email = input("Enter Email Address: ")
    if not validate_email(email):
        print("Invalid email format. Please enter a valid email address.")
        return None

    age = calculate_age(dob)

    return {
        "Name": name,
        "DOB": dob_str,
        "Age": age,
        "Phone": phone,
        "Email": email
    }
def save_to_text(data):
    with open('employee_data.txt', 'a') as file:
        file.write(f"Name: {data['Name']}\n")
        file.write(f"DOB: {data['DOB']}\n")
        file.write(f"Age: {data['Age']}\n")
        file.write(f"Phone: {data['Phone']}\n")
        file.write(f"Email: {data['Email']}\n\n")

def save_to_excel(data_list):
    df = pd.DataFrame(data_list)
    df.to_excel('employee_data.xlsx', index=False)

def save_to_pdf(data):
    pdf = FPDF()
    pdf.add_page()
    pdf.set_font("Arial", size=12)
    for key, value in data.items():
        pdf.cell(200, 10, txt=f"{key}: {value}", ln=True)
    pdf.output("employee_data.pdf")


def main():
    employees = []
    while True:
        print("\n1. Add Employee")
        print("2. Save to Text File")
        print("3. Save to Excel File")
        print("4. Save to PDF File")
        print("5. Exit")

        choice = input("Enter your choice: ")

        if choice == '1':
            employee_data = get_employee_details()
            if employee_data:
                employees.append(employee_data)
                print("Employee details added successfully.")

        elif choice == '2':
            for employee in employees:
                save_to_text(employee)
            print("Data saved to text file.")

        elif choice == '3':
            save_to_excel(employees)
            print("Data saved to Excel file.")

        elif choice == '4':
            for employee in employees:
                save_to_pdf(employee)
            print("Data saved to PDF file.")

        elif choice == '5':
            print("Exiting the program.")
            break

        else:
            print("Invalid choice. Please enter a valid option.")
if __name__ == "__main__":
    main()
