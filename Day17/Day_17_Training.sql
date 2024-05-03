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


--select the order number for the maximum fright paid by every customer

select * from Orders
select OrderID,CustomerID,Freight from Orders a where Freight =
(select max(freight) from Orders b where a.CustomerID=b.CustomerID)
order by a.CustomerID


--cross join 

select * from Customers,Categories

--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID


--Get the Supplier company name, contact person name, Product name and the stock ordered
select *  from products
select * from Suppliers
select * from [order Details]

select CompanyName,contactName,productName,UnitsOnOrder from Suppliers
join products on Suppliers.SupplierID=Products.SupplierID
order by UnitsOnOrder desc


 --Print the order id, customername and the fright cost for all teh orders
select * from orders
select * from Customers

select orderId,orders.CustomerID,ContactName,Freight from orders
join Customers on orders.CustomerID=Customers.CustomerID


--product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID



 --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)
select * from customers
select * from products
select * from suppliers
select * from orders
select * from [Order Details]


select d.ContactName "Customer Name",b.ProductName "Product Name",c.Freight,a.Quantity "Units Sold"
,(b.UnitPrice*c.Freight+a.Quantity) "total price"
from [Order Details] a join Products b on a.ProductID=b.ProductID
join orders c on c.OrderID=a.OrderID
join Customers d on d.CustomerID=c.CustomerID
join Suppliers e on e.SupplierID=b.SupplierID
order by d.ContactName



 --Print the product name and the total quantity sold
select productName,sum(quantity) "Total quantity sold"
from products p join [Order Details] od
on p.ProductID = od.ProductID
group by ProductName
order by 2 desc


--emp name ,custname,prod name,total price


select ( a.FirstName+' '+a.LastName) "Employee Name",c.ContactName,e.ProductName,(e.UnitPrice*b.Freight+d.Quantity) "total price"
from Employees a join Orders b on a.EmployeeID=b.EmployeeID
join Customers c on b.CustomerID=b.CustomerID
join [Order Details] d on d.OrderID=b.OrderID
join Products e on e.ProductID=d.ProductID
