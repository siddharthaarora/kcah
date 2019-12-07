/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `order`
--

-- --------------------------------------------------------

DROP TABLE `salesperson`;
CREATE TABLE IF NOT EXISTS `salesperson` (
  `id` int NOT NULL,
  `name` varchar(80) NOT NULL,
  `age` int NOT NULL,
  `salary` float NOT NULL,
  PRIMARY KEY (`id`)
  ) ENGINE=InnoDB DEFAULT CHARSET=latin1 ;

DROP TABLE IF EXISTS `customer`;
CREATE TABLE IF NOT EXISTS `customer` (
  `id` int NOT NULL,
  `name` varchar(80) NOT NULL,
  `city` varchar(255) NOT NULL,
  `industry_type` char NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ;

DROP TABLE IF EXISTS `order`;
CREATE TABLE IF NOT EXISTS `order` (
  `order_number` int NOT NULL,
  `order_date` date NOT NULL,
  `customer_id` int NOT NULL,
  `salesperson_id` int NOT NULL,
  `order_amount` float NOT NULL,
  PRIMARY KEY (`order_number`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ;

INSERT INTO `salesperson` (`id`, `name`, `age`, `salary`) VALUES
(1, 'Abe', 61, 140000),
(2, 'Bob', 34, 44000),
(5, 'Chris', 34, 40000),
(7, 'Dan', 41, 52000),
(8, 'Ken', 57, 115000),
(11, 'Joe', 38, 38000);

INSERT INTO `customer` (`id`, `name`, `city`, `industry_type`) VALUES
(4, 'Samsonic', 'pleasent', 'J'),
(6, 'Pansung', 'oaktown', 'J'),
(7, 'Samony', 'jackson', 'B'),
(9, 'Orange', 'Jackson', 'B');

INSERT INTO `order` (`order_number`, `order_date`, `customer_id`, `salesperson_id`, `order_amount`) VALUES
(9, '1997-08-02', 9, 5, 2400),
(10, '1996-08-02', 4, 2, 540),
(20, '1999-01-30', 4, 8, 1800),
(30, '1995-07-14', 9, 1, 460),
(40, '1998-01-29', 7, 2, 2400),
(50, '1998-02-03', 6, 7, 600),
(60, '1998-03-02', 6, 7, 720),
(70, '1998-05-06', 9, 7, 150);
