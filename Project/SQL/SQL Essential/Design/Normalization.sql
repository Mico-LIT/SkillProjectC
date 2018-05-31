USE [C:\REPOSITORIES\SKILL\SKILLPROJECTC\PROJECT\SQL\SKILLDB.MDF]

DROP TABLE Orders

CREATE TABLE Orders (
  Customer VARCHAR(200),
  OrderDate DATE,
  OrderDetails VARCHAR(200),
  Employee VARCHAR(200)
  
  )

  INSERT Orders
VALUES
(
 'Василий Петрович Лященко; Харьков, Лужная 15; (092)3212211;',
 '2009-12-28',
 'LV231 Джинсы, 45$, 5, 225$; DG30 Ремень, 30$, 5, 145$; LV12 Обувь, 26$, 5, 125$;',
 'Иван Иванович Белецкий'),
 
 ('Зигмунд Федорович Унакий; Киев, Дегтяревская 5; (092)7612343;',
 '2010-09-01',
 'GC11 Шапка, 32$, 10, 320#$; GC111 Футболка, 20$, 15, 300$;',
 'Светлана Олеговна Лялечкина'),
 
 
 ('Олег Евстафьевич Выжлецов; Чернигов, Киевская 5; (044)2134212;',
 '2010-09-18',
 'LV12 Обувь, 26$, 20, 520$; GC11 Шапка, 32$, 18, 576$;',
 'Светлана Олеговна Лялечкина'
 )


 SELECT * FROM Orders



-------------------------------------------------------------------------
--                            Первая НФ
-------------------------------------------------------------------------

-- Первая нормальная форма (1NF) – подразумевает отсутствие повторяющихся 
-- строк в таблице, а так же разбиение сложных значений атомарных данных 
-- в ячейке на более простые атомарные  данные. 

DROP TABLE Orders

  CREATE TABLE Orders(
    CustFNaeme VARCHAR(30) NOT NULL,
    CustMNaeme VARCHAR(30) NOT NULL,
    CustLNaeme VARCHAR(30) NOT NULL,
    CustCity VARCHAR(30),
    CustAddress VARCHAR(30),
    Phone VARCHAR (12) NOT NULL,
    OrderDate DATE NOT NULL,
    ProductID CHAR(5) NOT NULL,
    ProductDescriptin VARCHAR(30) NOT NULL,
    UnitPrice smallmoney NOT NULL,
    Qty INT NOT NULL,
    TotalPrice MONEY,
    EmpFName VARCHAR(30) NOT NULL,
    EmpMName VARCHAR(30) NOT NULL,
    EmpLName VARCHAR(30) NOT NULL,
    
    CHECK(Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')

    )




INSERT Orders
VALUES
('Василий', 'Петрович', 'Лященко', 'Харьков', 'Лужная 15', '(092)3212211',
 '2009-12-28',
 'LV231', 'Джинсы', 45, 5, 225,
 'Иван', 'Иванович', 'Белецкий'),
  
('Василий', 'Петрович', 'Лященко', 'Харьков', 'Лужная 15', '(092)3212211',
 '2009-12-28', 
 'DG30', 'Ремень', 30, 5, 145,
 'Иван', 'Иванович', 'Белецкий'),
 
 ('Василий', 'Петрович', 'Лященко', 'Харьков', 'Лужная 15', '(092)3212211',
 '2009-12-28', 
 'LV12', 'Обувь', 26, 5, 125,
 'Иван', 'Иванович', 'Белецкий'),
 
 ('Зигмунд', 'Федорович', 'Унакий', 'Киев', 'Дегтяревская 5', '(092)7612343',
 '2010-09-01',
 'GC11', 'Шапка', 32, 10, 320, 
 'Светлана', 'Олеговна', 'Лялечкина'),
 
 ('Зигмунд', 'Федорович', 'Унакий', 'Киев', 'Дегтяревская 5', '(092)7612343',
 '2010-09-01',
 'GC111', 'Футболка', 20, 15, 300,
 'Светлана', 'Олеговна', 'Лялечкина'),

 ('Олег', 'Увстафьевич', 'Выжлецов', 'Чернигов', 'Киевская 5', '(044)2134212',
 '2010-09-18',
 'LV12', 'Обувь', 26, 20, 520, 
 'Светлана', 'Олеговна', 'Лялечкина'
 ),
 
 ('Олег', 'Увстафьевич', 'Выжлецов', 'Чернигов', 'Киевская 5', '(044)2134212',
 '2010-09-18',
 'GC11', 'Шапка', 32, 18, 576,
 'Светлана', 'Олеговна', 'Лялечкина'
 )

 SELECT * FROM Orders


-- Перед тем как переходить к рассмотрению второй и третьей нормальной формы следует обеспечить сущностную целостность 
-- для таблицы Orders(определить первичный ключ)

DROP TABLE Orders

CREATE TABLE Orders
(
	OrderID int NOT NULL,
	LineItem int NOT NULL,
	OrderDate date NOT NULL,
	CustFName varchar(15) NOT NULL,
	CustMName varchar(15) NOT NULL,
	CustLName varchar(15) NOT NULL,
	CustomerCity varchar(15),
	CustomerAddress varchar(25),
	Phone varchar(12) NOT NULL,
	ProductID char(5) NOT NULL,
	ProductDescription varchar(15),
	UnitPrice smallmoney NOT NULL,
	Qty int NOT NULL,
	TotalPrice money,
	EmpFName varchar(15) NOT NULL,
	EmpMName varchar(15) NOT NULL,
	EmpLName varchar(15) NOT NULL,

	CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	PRIMARY KEY (OrderId, LineItem)
)


INSERT Orders
VALUES
( 1,1,'2009-12-28',
 'Василий', 'Петрович', 'Лященко', 'Харьков', 'Лужная 15', '(092)3212211',
 'LV231', 'Джинсы', 45, 5, 225,
 'Иван', 'Иванович', 'Белецкий'),
  
( 1,2,'2009-12-28', 
 'Василий', 'Петрович', 'Лященко', 'Харьков', 'Лужная 15', '(092)3212211',
 'DG30', 'Ремень', 30, 5, 145,
 'Иван', 'Иванович', 'Белецкий'),
 
( 1,3, '2009-12-28', 
 'Василий', 'Петрович', 'Лященко', 'Харьков', 'Лужная 15', '(092)3212211',
 'LV12', 'Обувь', 26, 5, 125,
 'Иван', 'Иванович', 'Белецкий'),
 
( 2,1,'2010-09-01',
 'Зигмунд', 'Федорович', 'Унакий', 'Киев', 'Дегтяревская 5', '(092)7612343',
 'GC11', 'Шапка', 32, 10, 320, 
 'Светлана', 'Олеговна', 'Лялечкина'),
 
( 2,2, '2010-09-01',
 'Зигмунд', 'Федорович', 'Унакий', 'Киев', 'Дегтяревская 5', '(092)7612343',
 'GC111', 'Футболка', 20, 15, 300,
 'Светлана', 'Олеговна', 'Лялечкина'),

( 3,1,'2010-09-18',
 'Олег', 'Увстафьевич', 'Выжлецов', 'Чернигов', 'Киевская 5', '(044)2134212',
 'LV12', 'Обувь', 26, 20, 520, 
 'Светлана', 'Олеговна', 'Лялечкина'
 ),
 
( 3,2, '2010-09-18',
 'Олег', 'Увстафьевич', 'Выжлецов', 'Чернигов', 'Киевская 5', '(044)2134212',
 'GC11', 'Шапка', 32, 18, 576,
 'Светлана', 'Олеговна', 'Лялечкина'
 )

SELECT * FROM Orders

-------------------------------------------------------------------------
--                          Вторая НФ
-------------------------------------------------------------------------

-- Вторая нормальная форма (2NF) – удовлетворяет первой нормальной форме, 
-- и каждый столбец  должен зависеть от всего ключа.

-- В таблице Orders все поля кроме ProductID, ProductDescription, UnitPrice, Qty, TotalPrice зависят не от всего ключа.


DROP TABLE Orders
DROP TABLE Employees
DROP TABLE Customers
DROP TABLE OrderDetails

CREATE TABLE Employees(
  EmployeeID INT IDENTITY NOT NULL
  PRIMARY KEY,
  FName VARCHAR(30) NOT NULL,
  LName VARCHAR(30) NOT NULL,
  MName VARCHAR(30) NOT NULL,
  Salary MONEY NOT NULL,
  PriorSalary MONEY NOT NULL,
  HireDate DATE NOT NULL,
  TerminationDate DATE NULL,
  ManagerEmpID INT NULL
  )
GO


CREATE TABLE Customers(
    CustomerNo INT NOT NULL IDENTITY PRIMARY KEY,
    FName VARCHAR(30) NOT NULL,
    LName VARCHAR(30) NOT NULL,
    MName VARCHAR(30) NOT NULL,
    Address1 VARCHAR(50) NOT NULL,
    Address2 VARCHAR(50) NULL,
    City NCHAR(10) NOT NULL,
    Phone CHAR(12) NOT NULL UNIQUE,
    DateInSystem DATE NULL,
    CHECK(Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
  
  )
  GO

CREATE TABLE Orders(
  OrderID INT NOT NULL IDENTITY PRIMARY KEY,
  OrderDate DATE NOT NULL,
  CustomerNo INT,
  EmployeeID INT,
  FOREIGN KEY (CustomerNo) REFERENCES Customers(CustomerNo),
  FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
  
  )

CREATE TABLE OrderDetails
(
	OrderID int NOT NULL,
	LineItem int NOT NULL,
	ProductID char(5) NOT NULL,
	ProductDescription varchar(15),
	UnitPrice smallmoney NOT NULL,
	Qty int NOT NULL,
	TotalPrice as Qty * UnitPrice,

  FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
	PRIMARY KEY (OrderId, LineItem)
)

  
INSERT Products
VALUES
( 'LV231', 'Джинсы', 45, 2),
( 'DG30', 'Ремень', 30,  1),
( 'GC111', 'Футболка', 20,  2),
( 'LV12', 'Обувь', 26,  2),
( 'GC11', 'Шапка', 32,  1)


INSERT OrderDetails
VALUES
( 1, 1, 'LV231', 5 ),
( 1, 2, 'DG30', 5 ),
( 1, 3, 'LV12', 5 ),
( 2, 1, 'GC11', 10 ),
( 2, 2, 'GC111', 15 ),
( 3, 1, 'LV12', 20 ),
( 3, 2, 'GC11', 18 )


SELECT * FROM Customers
SELECT * FROM Employees
SELECT * FROM Orders
SELECT * FROM OrderDetails
SELECT * FROM Products


  
-------------------------------------------------------------------------
--                            Денормализация
-------------------------------------------------------------------------

-- Денормализация – процесс понижения нормальной формы. 
-- Осуществляется если приведенная высшая форма приводит 
-- к ухудшению практического использования

DROP TABLE OrderDetails

CREATE TABLE OrderDetails
(
	OrderID int NOT NULL,
	LineItem int NOT NULL,
	ProductID char(5) NOT NULL,
	Qty int NOT NULL,
	TotalPrice money,

    FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
	PRIMARY KEY (OrderId, LineItem)
)


INSERT OrderDetails
VALUES
( 1, 12, 'LV231', 5, 5 * (select UnitPrice FROM Products where ProductID = 'LV231')),
( 1, 2, 'DG30', 5, 5 * (select UnitPrice FROM Products where ProductID = 'DG30')),
( 1, 3, 'LV12', 5, 5 * (select UnitPrice FROM Products where ProductID = 'LV12')),
( 2, 1, 'GC11', 10, 10 * (select UnitPrice FROM Products where ProductID = 'GC11') ),
( 2, 2, 'GC111', 15, 15 * (select UnitPrice FROM Products where ProductID = 'GC111') ),
( 3, 1, 'LV12', 20, 20 * (select UnitPrice FROM Products where ProductID = 'LV12') ),
( 3, 2, 'GC11', 18, 18 * (select UnitPrice FROM Products where ProductID = 'GC11') )


SELECT * FROM OrderDetails 