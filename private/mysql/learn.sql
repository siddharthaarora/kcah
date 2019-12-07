/* a. The names of all salespeople that have an order with Samsonic. */
select s.name
from orders.salesperson as s
	inner join orders.order as o
	on s.id = o.salesperson_id
    inner join orders.customer c
    on c.id = o.customer_id
where c.name = 'Samsonic';

/* b. The names of all salespeople that do not have any order with Samsonic. */
select distinct s.name
from orders.salesperson as s
	inner join orders.order as o
	on s.id = o.salesperson_id
    inner join orders.customer c
    on c.id = o.customer_id
where c.name != 'Samsonic';

/* c. The names of salespeople that have 2 or more orders. */
select s.name, count(*)
from orders.salesperson as s
	inner join orders.order as o
	on s.id = o.salesperson_id
group by s.name
having count(*) > 1;

/* d. The names and ages of all salespersons must having a salary of 100,000 or greater. */
select s.name, s.age
from orders.salesperson as s
where s.salary >= 100000;

/* e. What sales people have sold more than 1400 total units? */
select s.name
from orders.salesperson as s
	inner join orders.order as o
    on s.id = o.salesperson_id
where o.order_amount > 1400;

/* f. When was the earliest and latest order made to Samony? */
select min(o.order_date) as Earliest_Order_Date, max(o.order_date) as Latest_Order_Date
from orders.order as o;

select o.*
from orders.order as o
where	o.order_date = (select min(order_date) as edate from orders.order) 
or	o.order_date = (select max(order_date) as ldate from orders.order) ;

-- list the orders with the highest order amount without using MIN/MAX
select *
from orders.order
where order_amount = 
	(select order_amount 
	 from orders.order 
	 order by order_amount desc
     limit 1);

create table test_a(id numeric);
create table test_b(id numeric);
insert into test_a(id) values
  (10),
  (20),
  (30),
  (40),
  (50);
insert into test_b(id) values
  (10),
  (30),
  (50);

select *
from orders.test_a as a
	left outer join orders.test_b as b
    on a.id = b.id
where b.id is null;

-----

create table test_c(id integer);
insert into test_c(id) values
  (1), (0), (0), (1), (1), (1), (1), (0), (0), (1), (0), (1), (0), (1), (0), (1);

update test_c
	set id = case
		when id = 0 then 2
        when id = 1 then 4
	end
where 1 = 1;

select * from test_c;

----

-- 	Imagine a single column in a table that is populated with either a single digit (0-9) or a single character (a-z, A-Z). Write a SQL query to print ‘Fizz’ for a numeric value or ‘Buzz’ for alphabetical value for all values in that column.
-- Example:
-- ['d', 'x', 'T', 8, 'a', 9, 6, 2, 'V']
-- …should output:
-- ['Buzz', 'Buzz', 'Buzz', 'Fizz', 'Buzz','Fizz', 'Fizz', 'Fizz', 'Buzz']

create table test_d(c char);
insert into test_d values
  ('d'), ('x'), ('T'), ('8'), ('a'), ('9'), ('6'), ('2'), ('V');

select * 
from test_d;

select case c
	when '8' then "Fizz"
    when ('x') then "Buzz"
    end as a
from test_d;
