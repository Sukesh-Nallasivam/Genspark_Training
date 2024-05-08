use pubs
go


  
--1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name


create procedure GetBooksByAuthor
as
begin
select a.au_fname,t.title,p.pub_name from authors a
join titleauthor ta on ta.au_id=a.au_id
join titles t on ta.title_id=t.title_id
join publishers p on p.pub_id=t.pub_id
end

exec GetBooksByAuthor

alter procedure GetBooksByAuthor
    @firstname varchar(50)
as
begin
select a.au_fname,t.title,p.pub_name from authors a
join titleauthor ta on ta.au_id=a.au_id
join titles t on ta.title_id=t.title_id
join publishers p on p.pub_id=t.pub_id
where a.au_fname = @firstname
end

--example
exec GetBooksByAuthor 'Anne'


--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.

create procedure GetEmployeeName
as
begin
select t.title,t.price,s.qty,(t.price*s.qty) as Cost from employee e
join titles t on t.pub_id=e.pub_id
join sales s on s.title_id=t.title_id
end
exec GetEmployeeName

alter procedure GetEmployeeName
as
begin
select e.fname,t.title,t.price,s.qty,(t.price*s.qty) as Cost from employee e
join titles t on t.pub_id=e.pub_id
join sales s on s.title_id=t.title_id
end


alter procedure GetEmployeeName
as
begin
select e.fname,t.title,t.price,s.qty,(t.price*s.qty) as Cost from employee e
join titles t on t.pub_id=e.pub_id
join sales s on s.title_id=t.title_id
end
exec GetEmployeeName

alter procedure GetEmployeeName
@firstname varchar(30)
as
begin
select e.fname,t.title,t.price,s.qty,(t.price*s.qty) as Cost from employee e
join titles t on t.pub_id=e.pub_id
join sales s on s.title_id=t.title_id
where e.fname=@firstname
end


alter procedure GetEmployeeName
@firstname varchar(30)
as
begin
select e.fname,t.title,t.price,sum(s.qty) as Quantity,(t.price*sum(s.qty)) as Cost from employee e
join titles t on t.pub_id=e.pub_id
join sales s on s.title_id=t.title_id
where e.fname=@firstname
group by e.fname, t.title, t.price;
end

exec GetEmployeeName 'peter'


select * from employee where fname = 'paul'
select * from titles where pub_id = 0877

--3) Create a query that will print all names from authors and employees

select authors.au_fname+' '+authors.au_lname as Names from authors 
union
select employee.fname+' '+employee.lname from employee

--4) Create a  query that will float the data from sales,titles, publisher 
--and authors table to print title name, Publisher's name, author's full name 
--with quantity ordered and price for the order for all orders,
--print first 5 orders after sorting them based on the price of order

with GetOrderDetails_CTE (Title,PublisherName,AuthorName,Quantity,TotalPrice)
as
(
select t.title as Title,p.pub_name as PublisherName,a.au_fname+' '+a.au_lname as AuthorName,
s.qty as Quantity,s.qty*t.price as TotalPrice from titles t
join sales s on s.title_id=t.title_id
join publishers p on t.pub_id=p.pub_id
join titleauthor ta on ta.title_id=t.title_id
join authors a on a.au_id=ta.au_id
)

select top 5 * from GetOrderDetails_CTE
order by TotalPrice desc


--5) Please learn grant and revoke

