USE [C:\REPOSITORIES\SKILL\SKILLPROJECTC\PROJECT\SQL\SKILLDB.MDF]
GO

DROP TABLE Customers
  GO
CREATE TABLE  Customers(
  CustomerNO  INT IDENTITY NOT NULL PRIMARY KEY,
  CustomerName VARCHAR(50) NOT NULL,
  Address1 VARCHAR(50) NOT NULL,
  City VARCHAR(50) NOT NULL,
  Contact VARCHAR(50) NOT NULL,
  Phone CHAR (12)
  )

  GO
-------------------------------------------------------------------------
--                  Создание внешнего ключа
-------------------------------------------------------------------------
-- FOREIGN KEY (внешний ключ, ограничение внешнего ключа)


  DROP TABLE Orders
GO

-- Значения ячеек столбца дочерней таблицы с ограничением FOREIGN KEY 
-- должно совпадать с одним из имеющихся значений в родительской таблице.

  CREATE TABLE  Orders (
  OrderID INT IDENTITY NOT NULL PRIMARY KEY ,
    CustomerNo INT NOT NULL FOREIGN KEY (CustomerNo) REFERENCES Customers(CustomerNO),
    OrderDate DATE NOT NULL,
    Goods VARCHAR(30) NOT NULL

    )

    GO


INSERT INTO Customers																			   
(CustomerName, Address1, City, Contact, Phone)
VALUES
('Petrenko Petr Petrovich', 'Luganskaya 25', 'Konotop', 'PetrPetrenko@mail.ru', '(093)1231212'),
('Ivanenko Ivan Ivanovich', 'Dehtarivska 5', 'Chernigov', 'IvanenkoIvan@gmail.com', '(095)2313244');	

INSERT INTO Orders
(CustomerNo, OrderDate,	Goods)
VALUES
(1, GETDATE(), 'KeyBoard'),
(2, GETDATE(), 'Mouse'),
(2, GETDATE(), 'WebCam'),
(1, GETDATE(), 'Mouse');


SELECT CustomerNO, CustomerName, Address1, City FROM Customers;
SELECT * FROM Orders;

-- Не допускается запись в ссылаемый столбец (столбец с FOREIGN KEY) дочерней таблици, 
-- значений несуществующих в ссылочном столбце (столбец с PRIMARY KEY) родительской таблицы.


INSERT INTO Orders
(CustomerNo, OrderDate,	Goods)
VALUES
(3, GETDATE(), 'Mouse'); -- Ошибка! 

DROP TABLE Orders;
GO

CREATE TABLE Orders(
  OrderID INT IDENTITY NOT NULL PRIMARY KEY ,
  CustomerNO INT NOT NULL,
  OrderDate DATE NOT NULL,
  Goods VARCHAR(30) NOT null
    )


ALTER TABLE Orders ADD CONSTRAINT Fk_CustomerCustNo 
  FOREIGN KEY (CustomerNo) REFERENCES Customers(CustomerNO)


DROP TABLE Customers -- Невозможно удалить таблицу на которую ссылается дочерняя таблица.

-- Первыми удаляются дочерние таблицы после чего удаляются родительские таблицы.

DROP TABLE Orders
  DROP TABLE Customers


USE [C:\REPOSITORIES\SKILL\SKILLPROJECTC\PROJECT\SQL\SKILLDB.MDF]
GO

DROP TABLE Customers
  DROP TABLE Orders

CREATE TABLE Customers
  (
  CustomerNo INT IDENTITY NOT NULL PRIMARY KEY,
  CoustomerName VARCHAR(30) NOT NULL,
  Address1 VARCHAR(30) NOT NULL,
  City VARCHAR (30) NOT NULL,
  Contact VARCHAR(30) NOT NULL,
  Phone CHAR(12) ,
  
  )
GO

CREATE TABLE Orders
  (
  OrderID INT IDENTITY PRIMARY KEY NOT NULL,
  CustomerNo INT NOT NULL,
  OrderDate DATE NOT NULL,
  Goods VARCHAR (30) NOT NULL
  
  )
  GO

ALTER TABLE Orders ADD CONSTRAINT FK_Customer 
  FOREIGN KEY (CustomerNo) REFERENCES Customers(CustomerNO)

-- Удаление ограничения внешнего ключа. FK_CustomersCustomerNo - имя по умолчанию
ALTER TABLE orders DROP CONSTRAINT FK_Customer
  GO

DROP TABLE Customers; -- Таблица Customers удалена.
GO









