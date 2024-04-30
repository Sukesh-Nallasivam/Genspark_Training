create database EmployeeAndSales
go
use EmployeeAndSales



create table Department
(
    DepartmentName char(50) constraint PK_DepartmentName primary key,
    DepartmentFloor char(20),
    Phone varchar(20)
)


create table Employee 
(
    EmployeeNumber int identity(1,1) constraint PK_Employee_Id primary key,
    EmployeeName char(50),
    Salary int,
    DepartmentName char(50) constraint FK_DepartmenttName foreign key references Department(DepartmentName),
    BossNumber int constraint FK_BossNumber foreign key references Employee(EmployeeNumber)
)
alter table Department
add ManagerId int constraint FK_ManagerId foreign key references Employee(EmployeeNumber)


create table Item
(
ItemName char(50) constraint PK_ItemName primary key,
ItemType char,
ItemColor char
)

create table Sales
(
SalesNumber int identity(101,1) constraint PK_SalesNumber primary key,
SaleQuantity int,
ItemName char(50) constraint FK_ItemName foreign key references Item(ItemName),
DepartmentName char(50) constraint FK_DepartmentName foreign key references Department(DepartmentName)
)
sp_help Department
sp_help Sales



--Insertion

Insert into Department(DepartmentName,DepartmentFloor,Phone)
values('Management', 5, '34'),
('Books', 1, '81'),
('Clothes', 2, '24'),
('Equipment', 3, '57'),
('Furniture', 4, '14'),
('Navigation', 1, '41'),
('Recreation', 2, '29'),
('Accounting', 5, '35'),
('Purchasing', 5, '36'),
('Personnel', 5, '37'),
('Marketing', 5, '38');

select * from Department


--insertion into Department
Insert into Employee(EmployeeName,Salary,DepartmentName,BossNumber)
Values
('Alice', 75000, 'Management', NULL),
('Ned', 45000, 'Marketing', 1),
('Andrew', 25000, 'Marketing', 2),
('Clare', 22000, 'Marketing', 2),
('Todd', 38000, 'Accounting', 1),
('Nancy', 22000, 'Accounting', 5),
('Brier', 43000, 'Purchasing', 1),
('Sarah', 56000, 'Purchasing', 7),
('Sophile', 35000, 'Personnel', 1),
('Sanjay', 15000, 'Navigation', 3),
('Rita', 15000, 'Books', 4),
('Gigi', 16000, 'Clothes', 4),
('Maggie', 11000, 'Clothes', 4),
('Paul', 15000, 'Equipment', 3),
('James', 15000, 'Equipment', 3),
('Pat', 15000, 'Furniture', 3),
('Mark', 15000, 'Recreation', 3);


select * from Employee


--insertion for item

Insert into Item(ItemName,ItemType,ItemColor)
Values
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', NULL),
('Geo positioning system', 'N', NULL),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', NULL),
('Map Measure', 'N', NULL),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', NULL),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', NULL),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent -8 person', 'F', 'Khaki');

Select * from Item

alter table Item
ALTER COLUMN ItemColor char(50);

--insert in Sales

Insert into Sales(SaleQuantity,ItemName,DepartmentName)
values
(2, 'Boots-snake proof', 'Clothes'),
(1, 'Pith Helmet', 'Clothes'),
(1, 'Sextant', 'Navigation'),
(3, 'Hat-polar Explorer', 'Clothes'),
(5, 'Pith Helmet', 'Equipment'),
(2, 'Pocket Knife-Nile', 'Clothes'),
(3, 'Pocket Knife-Nile', 'Recreation'),
(1, 'Compass', 'Navigation'),
(2, 'Geo positioning system', 'Navigation'),
(5, 'Map Measure', 'Navigation'),
(1, 'Geo positioning system', 'Books'),
(1, 'Sextant', 'Books'),
(3, 'Pocket Knife-Nile', 'Books'),
(1, 'Pocket Knife-Nile', 'Navigation'),
(1, 'Pocket Knife-Nile', 'Equipment'),
(1, 'Sextant', 'Clothes'),
(1, 'Sextant', 'Equipment'),
(1, 'Sextant', 'Recreation'),
(1, 'Sextant', 'Furniture'),
(1, 'Pocket Knife-Nile', 'Furniture'),
(1, 'Exploring in 10 easy lessons', 'Books'),
(1, 'How to win foreign friends','Books'),
(1, 'Compass', 'Books'),
(1, 'Pith Helmet', 'Books'),
(1, 'Elephant Polo stick', 'Recreation'),
(1, 'Camel Saddle', 'Recreation');

select * from Sales

select * from Department
UPDATE Department
Set ManagerId = 
    Case DepartmentName
        When 'Management' Then 1
        When 'Books' Then 4
        When 'Clothes' Then 4
        When 'Equipment' Then 3
        When 'Furniture' Then 3
        When 'Navigation' Then 3
        When 'Recreation' Then 4
        When 'Accounting' Then 5
        When 'Purchasing' Then 7
        When 'Personnel' Then 9
        When 'Marketing' Then 5
    End;