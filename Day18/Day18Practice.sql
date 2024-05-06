use NorthWind


--outer join

select * from customers where CustomerID not in (select distinct customerid from Orders)

select * from orders

select ContactName,ShipName,ShipAddress
from customers c join orders o
on c.CustomerID = o.CustomerID

select ContactName,ShipName,ShipAddress
from customers c left outer join orders o
on c.CustomerID = o.CustomerID

--are there products never ordered

select distinct p.ProductName from Products p join [Order Details] od
on p.ProductID = od.ProductID