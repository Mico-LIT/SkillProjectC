
USE [C:\REPOSITORIES\SKILL\SKILLPROJECTC\PROJECT\SQL\SKILLDB.MDF] 

DROP TABLE Customers
  DROP TABLE Orders

CREATE TABLE Customers(
  CustomerNo INT IDENTITY NOT NULL PRIMARY key,
  CustomerName VARCHAR(30) NOT NULL,
  Address1 VARCHAR(30) NOT NULL,
  City VARCHAR(30) NOT NULL,
  Contact VARCHAR(30) NOT NULL,
  Phone CHAR(12)
  )

  GO

CREATE TABLE Orders
  (
  OrderID INT IDENTITY NOT NULL PRIMARY KEY,
  CustomerNo INT NULL DEFAULT 2,
  OrderDate DATE NOT NULL,
  Employeeid INT NULL
  )
GO


ALTER TABLE Orders ADD CONSTRAINT FK_CustNo 
  FOREIGN KEY(CustomerNo) REFERENCES Customers(CustomerNo)


INSERT INTO Customers																			   
(CustomerName, Address1, City, Contact, Phone)
VALUES
('Petrenko Petr Petrovich', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212'),
('Ivanenko Ivan Ivanovich', 'Дихтяревская 5', 'Чернигов', 'IvanenkoIvan@gmail.com', '(095)2313244');	


INSERT INTO Orders
(CustomerNo, OrderDate,	EmployeeId)
VALUES
(1, GETDATE(), 1);

SELECT * FROM Customers;
SELECT * FROM Orders;

-- Невозможно удалить запись из родительской таблицы, так как на нее имеется ссылка из дочерней таблицы.

DELETE Customers
  WHERE CustomerName = 'Petrenko Petr Petrovich'


-------------------------------------------------------------------------
--              Ограничения ссылочной целостности
-------------------------------------------------------------------------

-- С помощью ограничений ссылочной целостности (ON DELETE, ON UPDATE) 
-- можно определять действия, которые SQL Server будет производить
-- над строками дочерней таблицы, когда пользователь попытается
-- удалить или обновить ключевой столбец родительской таблицы.

-- Действия:

-- 1. CASCADE -	при UPDATE, DELETE в родительской таблице ключевого значения,
--				в дочерней таблице также выполняется  UPDATE на новое значение, 
--				или DELETE	строк из дочерней таблицы соответственно

  ALTER TABLE Orders DROP CONSTRAINT FK_CustNo 

  ALTER TABLE Orders add CONSTRAINT FK_CustNo 
  FOREIGN KEY (CustomerNo) 
  REFERENCES Customers(CustomerNo) ON DELETE CASCADE
  GO

  DELETE Customers WHERE CustomerName = 'Petrenko Petr Petrovich';


  SELECT * FROM Customers;
  SELECT * FROM Orders;

  DBCC CHECKIDENT ("Customers",RESEED,0) -- Обновление значение IDENTITY = 0

  INSERT INTO Customers																			   
  (CustomerName, Address1, City, Contact, Phone)
  VALUES
  ('Петренко Петр Петрович', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212')

DBCC CHECKIDENT("Customers",RESEED,2) -- Обновление значение IDENTITY = 2
GO

DBCC CHECKIDENT("Orders",RESEED,0); -- Обновление значение IDENTITY = 0
GO

INSERT INTO Orders
(CustomerNo, OrderDate,	EmployeeId)
VALUES (1,GETDATE(),1);
GO

SELECT * FROM Customers;
SELECT * FROM Orders;
  
-- 2. SET NULL - при UPDATE, DELETE в родительской таблице ключевого значения,
--				 в дочерней таблице все значения, составляющие эти внешние ключи, 
--				 будут изменены на NULL


ALTER TABLE Orders DROP CONSTRAINT FK_CustNo

ALTER TABLE Orders ADD CONSTRAINT FK_ConstNo 
  FOREIGN KEY (CustomerNo) 
  REFERENCES Customers(CustomerNo) ON DELETE SET null

go

DELETE Customers
WHERE CustomerName = 'Петренко Петр Петрович';
GO

SELECT * FROM Customers;
SELECT * FROM Orders;


DBCC CHECKIDENT("Customers",RESEED,0) -- Обновление значение IDENTITY = 0


INSERT INTO Customers																			   
(CustomerName, Address1, City, Contact, Phone)
VALUES
('Petrenko Petr Petrovich', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212')


DBCC CHECKIDENT ("Customers",RESEED,2)-- Обновление значение IDENTITY = 2


DELETE Orders WHERE OrderID=1

DBCC CHECKIDENT("Orders",RESEED,0); -- Обновление значение IDENTITY = 0
GO

INSERT INTO Orders
(CustomerNo, OrderDate,	EmployeeId)
VALUES (1,GETDATE(),1);
GO

SELECT * FROM Customers;
SELECT * FROM Orders;


-- 3. SET DEFAULT - при UPDATE, DELETE в родительской таблице ключевого значения,
--					в дочерней таблице все значения, составляющие эти внешние ключи, 
--					будут изменены на значение по умолчанию.

ALTER TABLE orders 
  DROP CONSTRAINT  FK_ConstNo
GO

 ALTER TABLE Orders ADD CONSTRAINT 
 FK_CustNo FOREIGN KEY (CustomerNo) REFERENCES Customers (CustomerNo)
 ON DELETE SET DEFAULT
  
DELETE Customers
WHERE CustomerName = 'Petrenko Petr Petrovich';
GO

SELECT * FROM Customers;
SELECT * FROM Orders;

DBCC CHECKIDENT("Customers",RESEED,0); -- Обновление значение IDENTITY = 0
GO

INSERT INTO Customers																			   
(CustomerName, Address1, City, Contact, Phone)
VALUES
('Petrenko Petr Petrovich', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212')

DBCC CHECKIDENT("Customers",RESEED,2) -- Обновление значение IDENTITY = 2
GO

DELETE Orders WHERE OrderID = 1;
GO

DBCC CHECKIDENT("Orders",RESEED,0); -- Обновление значение IDENTITY = 0
GO

INSERT INTO Orders
(CustomerNo, OrderDate,	EmployeeId)
VALUES (1,GETDATE(),1);
GO

SELECT * FROM Customers;
SELECT * FROM Orders;

-- 4. NO ACTION (по умолчанию) - запрещает выполнение UPDATE, DELETE!
ALTER TABLE orders DROP CONSTRAINT FK_CustNo


  ALTER TABLE Orders ADD CONSTRAINT FK_CustNo FOREIGN KEY(CustomerNo)
    REFERENCES Customers (CustomerNo) ON DELETE NO ACTION
GO

DELETE Customers
WHERE CustomerName = 'Petrenko Petr Petrovich';

SELECT * FROM Customers;
SELECT * FROM Orders;
