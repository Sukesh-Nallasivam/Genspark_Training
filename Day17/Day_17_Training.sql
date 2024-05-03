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

