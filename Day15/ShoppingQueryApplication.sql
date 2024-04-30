--create DB
create database Shopping
use Shopping

--create table for Customers
create table Customers
(
Customer_Id int identity(100,1) constraint PK_Customer_ID primary key,
CustomerName char(50),
CustomerMobile varchar(20)
)
--create table for suppliers
create table Suppliers
(
Supplier_Id int identity(1,1) constraint PK_Supplier_ID primary key,
SupplierName char(50),
SupplierMobile varchar(20)
)
--create table for products
create table Products
(
Product_Id int identity(1,1) constraint PK_Product_ID primary key,
ProductName char(50),
SupplierId int constraint FK_SuplierId foreign key references Suppliers(Supplier_Id)
)
--create table for purchases
create table Purchase
(
Purchase_Id int identity(1,1) constraint PK_Purchase_ID primary key,
Customer_Id int constraint FK_Customer_Id foreign key references Customers(Customer_Id),
ProductId int constraint FK_Product_Id foreign key references Products(Product_Id),
Quantity int,
DateOfPurchase datetime
)


