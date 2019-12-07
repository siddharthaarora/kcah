-- --------------------------------------------------------
-- Envelop
--------

DROP TABLE IF EXISTS `envelop`;
CREATE TABLE IF NOT EXISTS `envelop` (
  `id` int NOT NULL,
  `user_id` int NOT NULL
  );

DROP TABLE IF EXISTS `docs`;
CREATE TABLE IF NOT EXISTS `docs` (
  `idnum` int NULL,
  `pageseq` int NOT NULL,
  `docext` varchar(100)
  );

INSERT INTO orders.envelop VALUES
  (1,1),
  (2,2),
  (3,3);

INSERT INTO orders.docs(idnum,pageseq) VALUES
  (1,5),
  (2,6),
  (null,0);

select * from orders.docs where idnum != 2 or idnum is null;
select * from orders.envelop;

UPDATE orders.docs 
	INNER JOIN orders.envelop 
    ON envelop.id = docs.idnum
	SET docs.docext=docs.pageseq 
WHERE EXISTS (
  SELECT 1 FROM (SELECT 1 FROM orders.docs
  WHERE docs.idnum = envelop.id) AS s
  WHERE s.idnum = envelop.id
);
