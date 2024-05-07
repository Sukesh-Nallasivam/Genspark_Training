go 
use NorthWind


select * from Categories

select * from Suppliers

--Union
select CategoryID,  categoryname from Categories
union
select SupplierId,CompanyName from Suppliers


select * from [Order Details]


--Intersect
select * from Orders where ShipCountry='Spain'
intersect
select * from orders where Freight>50


--Union all

select * from Orders where ShipCountry='Spain'
union all
select * from orders where Freight>50

select top 5 * from orders order by Freight desc

--get the order id, productname and quantitysold of products that have price
--greater than 15


select OrderID,ProductName,Quantity from [Order Details] od
join Products p on od.ProductID=p.ProductID where p.UnitPrice>15

--get the order id, productname and quantitysold of products that are from category 'dairy'
--and within the price range of 10 to 20


select orderID,ProductName,Quantity from [Order Details] od
join Products p on od.ProductID=p.ProductID 
join Categories c on p.CategoryID=c.CategoryID 
where c.CategoryName like '%dairy%' and p.UnitPrice between 10 and 20


--CTE

  with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
  as
  (select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
  from [Order Details] od join Products p
  on od.ProductId = p.ProductID
  where p.UnitPrice>15
  union
  SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
  JOIN Products p ON p.ProductID = [Order Details].ProductID
  JOIN Categories c ON c.CategoryID = p.CategoryID
  WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')
  
  select top 10 * from  OrderDetails_CTE order by price desc

  

  create view vwOrderDetails
  as
  (select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
  from [Order Details] od join Products p
  on od.ProductId = p.ProductID
  where p.UnitPrice>15
  union
  SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
  JOIN Products p ON p.ProductID = [Order Details].ProductID
  JOIN Categories c ON c.CategoryID = p.CategoryID
  WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

select * from vwOrderDetails order by UnitPrice


--Get the first 10 records of

--The order ID, Customer name and the product name for products that are purchaced by 
--people from USA
--The order ID, Customer name and the product name for products that are ordered by people from france 
--with fright less than 20

with NewOrderDetails_CTE (OrderID,ContactName,ProductName)
as
(
select o.OrderID,c.ContactName,p.ProductName from [Order Details] od 
join Products p on od.ProductID=p.ProductID
join Orders o on od.OrderID=o.OrderID
join Customers c on c.CustomerID=o.CustomerID
where c.Country like '%USA%'
union 
select o.OrderID,c.ContactName,p.ProductName from [Order Details] od 
join Products p on od.ProductID=p.ProductID
join Orders o on od.OrderID=o.OrderID
join Customers c on c.CustomerID=o.CustomerID
where c.Country like '%france%' and o.Freight<20
)
select top 10 * from  NewOrderDetails_CTE


sp_help Employees

create index idxEmpEmail on Employees(email)

select * from employees where email like 'r%'

drop index idxEmpEmail on Employees



create procedure proc_FirstProcedure
as
begin
    print 'Hello'
end

execute proc_FirstProcedure

create proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Hello '+@cname
end

exec proc_GreetWithName 'Ramu'


select * from Employees

create proc proc_AddEmployee(@ename varchar(10),@edob datetime,
@earea varchar(10), @ephone varchar(15), @eemail varchar(15))
as
begin
   insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
   values(@ename,@edob,@earea,@ephone,@eemail)
end

exec proc_AddEmployee 'Bimu','2000-09-07','HHHH','1122334455','bimu@gmail.com'
create proc proc_AddEmployee(@ename varchar(10),@edob datetime,
@earea varchar(10), @ephone varchar(15), @eemail varchar(15))
as
begin
   insert into Employees(name,DateOfBirth,EmployeeArea,Phone,Email)
   values(@ename,@edob,@earea,@ephone,@eemail)
end


alter proc proc_GreetWithName(@cname varchar(20))
as
begin
   print 'Welcome '+@cname
end


Create proc proc_PrintDetails(@cname varchar(20),@cage int,@cphone varchar(15))
as
begin
   print 'Welcome '+@cname + ' and you are '+@cage +'years old, Your phone is '+@cphone
end
alter  proc proc_PrintDetails(@cname varchar(20),@cage int,@cphone varchar(15))
as
begin
   print 'Welcome '+@cname + ' and you are '+cast(@cage as varchar(3))+'years old, Your phone is '+@cphone
end

proc_PrintDetails 'Ramu',23,'8877665544'


