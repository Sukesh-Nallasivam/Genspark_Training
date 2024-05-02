go
use pubs

select * from titles

--1) Print all the titles names

select title from titles

--2) Print all the titles that have been published by 1389

select title from titles where pub_id=1389

--3) Print the books that have price in rangeof 10 to 15

select title_id,title,price from titles
group by price,title_id,title
having price>=10 and price<=15
order by price

--4) Print those books that have no price

select * from titles
order by price
select title,price from titles where price is null

--5) Print the book names that strat with 'The'
 
select title from titles where title like 'The%'

--6) Print the book names that do not have 'v' in their name

select title from titles where title not like '%v%'

--7) print the books sorted by the royalty

select * from titles 
select title,royalty from titles
order by 2

--8) print the books sorted by publisher in descending then by types in asending then by price in descending


select * from publishers

select title,pub_id,type from titles
order by pub_id desc,type asc

--9) Print the average price of books in every type
 
select type,avg(price) from titles
group by type

--10) print all the types in uniques

select distinct type from titles

--11) Print the first 2 costliest books

select top 2 title as book,price from titles  
order by price desc

--12) Print books that are of type business and have price less than 20 which also have advance greater than 7000

select title as book,type,price,advance from titles 
where type='business' and price <20 and advance>7000

--13) Select those publisher id and number of books which have price between 15 to 25 and 
--have 'It' in its name. Print only those which have count greater than 2.
-- Also sort the result in ascending order of count

select * from titles

--
select pub_id,title,count(title) as price_range_count from titles
where price between 15 and 25 and title like '%IT%'
group by pub_id,title
having count(title)>2
order by count(title) asc
 
--14) Print the Authors who are from 'CA'
select * from authors

select au_fname,au_lname,state from authors where state='ca'

--15) Print the count of authors from every state
select state,count(au_id) from authors
group by state
