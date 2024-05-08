create database DoctorClinicDB
go
use DoctorClinicDB


create table Patients (
    PatientId int identity(1,1) constraint PK_PatientID primary key,
    PatientName varchar(100),
    PatientAge int
)

create table Doctors (
    DoctorId int identity(1,1) constraint PK_DoctorID primary key,
    doctor_name varchar(100),
    speciality varchar(100),
    contact varchar(15),
    consulting_hours varchar(100)
)

create table Appointments (
	AppointmentID int identity(1,1) Constraint PK_AppointmentId primary key,
	PatientId int Constraint FK_PatientId foreign key References Patients(PatientId),
	DoctorId int Constraint FK_DoctorId foreign key References Doctors(DoctorId),
    AppointmentDateTime datetime,
    Purpose varchar(200),
    AppointmentStatus varchar(50)
)

create table MedicalHistory (
    PatientId int Constraint FK_MedicalHistoryPatientId foreign key References Patients(PatientId),
    MedicalCondition varchar(200)
)

create table PreviousConsultations (
    PatientId int Constraint FK_PreviousConsultationsPatientId foreign key References Patients(PatientId),
    ConsultantId int Constraint FK_PreviousConsultationsDoctorId foreign key References Doctors(DoctorId)
)


select * from Patients
select * from Appointments
select * from Doctors
select * from MedicalHistory
select * from PreviousConsultations

sp_help Patients;
sp_help Appointments
sp_help Doctors
sp_help MedicalHistory
sp_help PreviousConsultations