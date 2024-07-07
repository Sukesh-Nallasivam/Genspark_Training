-- Create the database
CREATE DATABASE myCustomDB;

-- Connect to the database
\c myCustomDB;

-- Create the tables
CREATE TABLE CustomDepartment (
    Department_id SERIAL PRIMARY KEY,
    Department_name VARCHAR(255) NOT NULL
);

CREATE TABLE CustomEmployee (
    Employee_id SERIAL PRIMARY KEY,
    Employee_name VARCHAR(255) NOT NULL,
    Employee_age INT,
    Employee_phone VARCHAR(20),
    Department_id INT,
    FOREIGN KEY (Department_id) REFERENCES CustomDepartment(Department_id)
);

CREATE TABLE CustomSalary (
    Salary_id SERIAL PRIMARY KEY,
    Employee_id INT,
    Salary_amount DECIMAL(10, 2),
    FOREIGN KEY (Employee_id) REFERENCES CustomEmployee(Employee_id)
);

-- Insert some sample data
INSERT INTO CustomDepartment (Department_name) VALUES ('IT'), ('HR');
INSERT INTO CustomEmployee (Employee_name, Employee_age, Employee_phone, Department_id) VALUES ('Rajesh Kumar', 30, '123-456-7890', 1), ('Priya Sharma', 28, '098-765-4321', 2);
INSERT INTO CustomSalary (Employee_id, Salary_amount) VALUES (1, 70000), (2, 65000);
