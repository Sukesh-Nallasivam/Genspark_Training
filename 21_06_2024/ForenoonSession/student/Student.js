class Student {
    constructor(studentName, studentAge, countryName) {
        this.studentName = studentName;
        this.studentAge = studentAge;
        this.countryName = countryName;
    }

    StudentDetails() {
        console.log("Student Details");
        return "Student name is " + this.studentName + " and age is " + this.studentAge;
    }

    StudentDemograhy() {
        return this.countryName;
    }
}

class CollegeStudent extends Student {
    constructor(studentName, studentAge, countryName, collegeName) {
        super(studentName, studentAge, countryName);
        this.collegeName = collegeName;
    }

    StudentDetails() {
        console.log("College Student Details");
        return "Student name is " + this.studentName + " and age is " + this.studentAge + " and college name is " + this.collegeName;
    }
}

class Transport extends Student {
    constructor(studentName, studentAge, countryName, collegeName, transportName) {
        super(studentName, studentAge, countryName, collegeName);
        this.transportName = transportName;
    }

    StudentDetails() {
        console.log("College Student Details");
        return "Student name is " + this.studentName + " and age is " + this.studentAge + " and college name is " + this.collegeName + " and transport name is " + this.transportName;
    }
}

class Department extends Student {
    constructor(studentName, studentAge, countryName, collegeName, departmentName) {
        super(studentName, studentAge, countryName, collegeName);
        this.departmentName = departmentName;
    }

    StudentDetails() {
        console.log("College Student Details");
        return "Student name is " + this.studentName + " and age is " + this.studentAge + " and college name is " + this.collegeName + " and department name is " + this.departmentName;
    }
}

// class object
const firstStudent = new Student("Ramu", 15, "India");
console.log(firstStudent.StudentDetails());

// polymorphism
const secondStudent = new CollegeStudent("Ravi", 22, "USA", "University");
console.log(secondStudent.StudentDetails());

// encapsulation
const thirdStudent = new Transport("Raj", 25, "UK", "College", "Aeroplane");
console.log(thirdStudent.StudentDetails());
