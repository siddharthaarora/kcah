drop table if exists `employee`;
create table if not exists `employee`
(
	id int not null primary key,
    name varchar(255) not null,
    salary numeric not null,
    manager_id int
);

insert into employee values
	(1, 'a', 10000, 9),
	(2, 'b', 11000, 9),
	(3, 'c', 12000, 2),
	(4, 'd', 13000, 2),
	(5, 'e', 14000, 2),
	(6, 'f', 15000, 2),
	(7, 'g', 16000, 1),
	(8, 'h', 17000, 1),
	(9, 'i', 18000, null),
	(10, 'j', 19000, 9),
	(11, 'k', 20000, 2),
	(12, 'l', 21000, 10),
	(13, 'm', 22000, 10),
	(14, 'n', 23000, 10),
	(15, 'o', 24000, 5),
	(16, 'p', 25000, 5),
	(17, 'q', 26000, 5),
	(18, 'r', 27000, 1);

select * 
from employee
order by salary
limit 10,1;    

select name
from employee
where id % 2 = 0
limit 10;

select group_concat(name)
from employee 

-- print org chart

set @ceo = (select id from employee where manager_id is null);

with recursive orgchart(empid, name, level) as
(
	select 
		id,
		name,
        1 as level
    from employee
    where id = @ceo
    
    union all
    
    select 
		e.id,
		e.name, 
        o.level+1 as level
    from employee as e
		inner join orgchart as o
        on e.manager_id = o.empid
) select *
from orgchart
order by level, empid;


