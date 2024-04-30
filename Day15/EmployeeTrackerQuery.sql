--creating database
create database dbEmployeeTracker
--selecting database
use dbEmployeeTracker

--deleting database
--use master 
--go
--drop database dbEmployeeTracker

create Table Areas
(
Area varchar(20),Skill char(10)
)

select * from Areas
sp_help Areas


alter table Areas
alter column Area varchar(30) not null

alter table Areas
add constraint pk_Area Primary key(Area)


drop table Areas


create Table Areas
(Area varchar(20) constraint pk_Area primary key,
Zipcode char(5))


--Alter table to add clolumn
Alter table Areas
add AreaDescription varchar(1000)



alter table Areas
drop column AreaDescription


create table Skills
(Skill varchar(20),Descriptin char(20))

sp_help Skills

drop table Skills

create table Skills
(
Skill varchar(20) constraint PK_Skills primary key,
SkillDescription char(15)
)

alter table Skills
add Skill_ID int identity(101,1)


drop table Skills


create table Skills(
Skill_id int identity(1,1) constraint pk_skill primary key,
Skill varchar(20),
SkillDescription varchar(100))
--Employee Table

create table Employees
(
Id int identity(100,1) constraint PK_EmployeeId primary key,
name varchar(100),
DateOfBirth datetime constraint chk_DOB Check(DateOfBirth<GetDate()),
EmployeeArea varchar(20) constraint fk_Area references Areas(Area),
Phone varchar(15),
email varchar(100) not null
)

sp_help Employees







create table EmployeeSkills
(
Employee_Id int constraint Fk_Skill_EId foreign key references Employees(Id),
Skill int constraint Fk_Skill_ESkill foreign key references Skills(Skill_id),
SkillLevel float constraint chk_skilllevel check(skillLevel>=0),
constraint PK_Employee_Skill primary key(Employee_id,Skill)
)
sp_help EmployeeSkills


Insert into Areas(Area,Zipcode) values('DDDD','12345')
Insert into Areas(Zipcode,Area) values('12333','FFFF')
insert into Areas values('HHHH','12222')



--Failures during Insertion
Insert into Areas(Area,Zipcode) values('DDDD','12345')--Primary key duplication
Insert into Areas(Area,Zipcode) values('OOOO','12345334')--Size violation
Insert into Areas(Zipcode) values('12345')--Primary key null


select * from Areas



insert into Skills(Skill,SkillDescription) values('C','PLT')
insert into Skills(Skill,SkillDescription) values('C++','OOPS'),('Java','Web'),('C#','Web'),('SQL','RDBMS')
select * from skills

--Foreign Key insert
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Ramu','2000-12-12','DDDD','9876543210','ramu@gmail.com')
insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
Values('Somu','2001-05-01','FFFF','9988776655','somu@gmail.com')

select * from Employees

--Employee Skill- Composite key

Insert into EmployeeSkills values(101,3,8)
select * from EmployeeSkills