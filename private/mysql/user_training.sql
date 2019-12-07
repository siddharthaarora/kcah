-- 	8. Given the following tables:
-- SELECT * FROM users;
-- user_id  username
-- 1        John Doe                                                                                            
-- 2        Jane Don                                                                                            
-- 3        Alice Jones                                                                                         
-- 4        Lisa Romero
-- SELECT * FROM training_details;
-- user_training_id  user_id  training_id  training_date
-- 1                 1        1            "2015-08-02"
-- 2                 2        1            "2015-08-03"
-- 3                 3        2            "2015-08-02"
-- 4                 4        2            "2015-08-04"
-- 5                 2        2            "2015-08-03"
-- 6                 1        1            "2015-08-02"
-- 7                 3        2            "2015-08-04"
-- 8                 4        3            "2015-08-03"
-- 9                 1        4            "2015-08-03"
-- 10                3        1            "2015-08-02"
-- 11                4        2            "2015-08-04"
-- 12                3        2            "2015-08-02"
-- 13                1        1            "2015-08-02"
-- 14                4        3            "2015-08-03"

drop table if exists `user`;
create table if not exists `user`
(
	id int not null primary key,
    name varchar(255) not null
);

drop table if exists `user_training`;
create table if not exists `user_training`
(
	user_training_id int not null primary key,
    user_id int not null,
    training_id int not null,
    training_date date not null
);

insert into user values
(1,'John Doe'),
(2, 'Jane Don'),
(3, 'Alice Jones'),
(4, 'Lisa Romero');

insert into user_training values
(1, 1, 1, "2015-08-02"),
(2, 2, 1, "2015-08-03"),
(3, 3, 2, "2015-08-02"),
(4, 4, 2, "2015-08-04"),
(5, 2, 2, "2015-08-03"),
(6, 1, 1, "2015-08-02"),
(7, 3, 2, "2015-08-04"),
(8, 4, 3, "2015-08-03"),
(9, 1, 4, "2015-08-03"),
(10, 3, 1, "2015-08-02"),
(11, 4, 2, "2015-08-04"),
(12, 3, 2, "2015-08-02"),
(13, 1, 1, "2015-08-02"),
(14, 4, 3, "2015-08-03");

-- Write a query to to get the list of users who took the a training lesson 
-- more than once in the same day, grouped by user and training lesson, 
-- each ordered from the most recent lesson date to oldest date.

select distinct u.id, u.name
from orders.user as u
	inner join orders.user_training as ut
    on u.id = ut.user_id
group by ut.user_id, ut.training_id, ut.training_date
having count(ut.user_id) > 1
order by ut.training_date desc;


select sum(3) 
from user;