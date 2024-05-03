go
use NorthWind

--All the products from 'Confections'
--Sub Query
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')

select * from Suppliers

--select product names from the supplier Tokyo Traders

select ProductName from products where SupplierId=
(select SupplierID from suppliers where CompanyName = 'Tokyo Traders')

--get all the products that are supplied by suppliers from USA
-- "=" wont work when there is multiple values
select ProductName from products where SupplierID in 
(select SupplierID from Suppliers where Country = 'USA')

--get all the products from the category that has 'ea' in the description
select * from Categories
select ProductName from Products where CategoryID in 
(select CategoryID from Categories where Description like '%ea%')



select * from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%')
and SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')


select * from customers
select * from orders
select * from [Order Details]
--select the product id and the quantity ordered by customrs from France
select productID,Quantity from [Order Details] where OrderID in
(select OrderID from Orders where CustomerID in 
(select CustomerID from Customers where Country = 'France'))

--Get the products that are priced above the average price of all the products

select * from products

select avg(unitPrice) from Products

select productName,UnitPrice from products where UnitPrice > 
(select avg(UnitPrice) from products)
---Co-related sub query
--select latest order by every employee
select * from Orders

select * from Orders a
where OrderDate = (select max(orderDate) from Orders as b where a.EmployeeID=b.EmployeeID)
order by a.EmployeeID


--Select the maximum priced product in every category

select * from products
select * from products a where UnitPrice = 
(select max(UnitPrice) from Products b where a.CategoryID=b.CategoryID)
order by a.CategoryID