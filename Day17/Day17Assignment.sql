go 
use pubs
--1) Print the storeid and number of orders for the store

select * from stores 
select * from titles
select * from sales

select a.stor_id,a.stor_name,count(b.ord_num) "No of orders" from stores a join 
sales b on b.stor_id=a.stor_id
group by a.stor_id,a.stor_name


--2) print the numebr of orders for every title

select b.title,count(a.ord_num) as "No of Orders"
from sales a
join titles b on b.title_id=a.title_id
group by b.title

--3) print the publisher name and book name

select a.pub_name "Publisher Name",b.title "Book Name" from publishers a  
join titles b on a.pub_id=b.pub_id

--4) Print the author full name for al the authors

select * from authors
select au_fname+' '+au_lname as "Author full name" from authors


--5) Print the price or every book with tax (price+price*12.36/100)

select * from titles
select title,price,(titles.price+titles.price*12.36/100) as "Total Price" from titles

--6) Print the author name, title name

select c.au_fname+' '+c.au_lname "author name",title from titles a join 
titleauthor b on b.title_id=a.title_id join authors c on 
c.au_id=b.au_id


--7) print the author name, title name and the publisher name

select c.au_fname+' '+c.au_lname "author name",title,d.pub_name from titles a join 
titleauthor b on b.title_id=a.title_id join authors c on 
c.au_id=b.au_id join publishers d on d.pub_id=a.pub_id

--8) Print the average price of books pulished by every publicher
select * from publishers
select distinct pub_id from titles
select a.pub_id,pub_name,avg(price) "Average" from publishers a join 
titles b on a.pub_id=b.pub_id
group by pub_name,a.pub_id 

--9) print the books published by 'Marjorie'
select * from publishers
select a.title from titles a 
join titleauthor b on b.title_id=a.title_id
join authors c on c.au_id=b.au_id
join publishers d on a.pub_id=d.pub_id
where d.pub_name='Marjorie'

--10) Print the order numbers of books published by 'New Moon Books'
select * from titles
select p.pub_name,count(t.pub_id) "count" from publishers p
join titles t on p.pub_id=t.pub_id
where p.pub_name='new moon books'
group by p.pub_name


--11) Print the number of orders for every publisher

select * from sales
select p.pub_id,p.pub_name,count(sa.ord_num) "No of Orders" from sales sa 
join titles t on sa.title_id=t.title_id 
join publishers p on t.pub_id=p.pub_id
group by p.pub_id,p.pub_name

--12) print the order number , book name, quantity, price and the total price for all orders
select * from sales
select sa.ord_num "Order No",t.title "Book Name",sa.qty "Quantity",t.price,t.price*sa.qty "Total price"  from sales sa
join titles t on sa.title_id=t.title_id 

--13) print he total order quantity fro every book

select t.title,sum(sa.qty) "Total order Quantity" from sales sa join 
titles t on sa.title_id=t.title_id
group by t.title


--14) print the total ordervalue for every book

select t.title,sum(sa.qty) "Total order Quantity",t.price,sum(t.price*sa.qty) "Total price"  from sales sa 
join titles t on sa.title_id=t.title_id
group by t.title,t.price

--15) print the orders that are for the books published by the publisher for which 'Paolo' works for

select * from sales

select fname,t.title,p.pub_name from employee e 
join publishers p on e.pub_id=p.pub_id join 
titles t on t.pub_id=e.pub_id 
where e.fname='paolo'

