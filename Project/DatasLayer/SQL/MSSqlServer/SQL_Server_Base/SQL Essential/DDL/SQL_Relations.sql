
USE [C:\REPOSITORIES\SKILL\SKILLPROJECTC\PROJECT\SQL\SKILLDB.MDF]

-------------------------------------------------------------------------
--                 Связь Один к Одному
-------------------------------------------------------------------------

DROP TABLE Orders;
GO

DROP TABLE Customers;
GO

CREATE TABLE Customers(
  CustomerNo INT IDENTITY(1,1) NOT NULL,
  CustomerName VARCHAR(30) NOT NULL,
  Address1 VARCHAR(30) NOT NULL,
  City VARCHAR(30) NOT NULL,
  Contact VARCHAR(30) NOT NULL,
  Phone CHAR(12)

  );
GO

CREATE TABLE Orders(
  OrderID INT IDENTITY NOT NULL,
  CustomerNo INT NOT NULL, 
  OrderDate DATE NOT NULL,
  Goods varchar(30) NOT NULL  
  );
GO

ALTER TABLE Customers ADD CONSTRAINT PK_CustomerNo PRIMARY KEY(CustomerNo) ;
ALTER TABLE Orders ADD CONSTRAINT FK_CustomerNo FOREIGN KEY(CustomerNo) REFERENCES Customers(CustomerNo);
ALTER TABLE Orders ADD UNIQUE (CustomerNo)

INSERT INTO Customers																			   
(CustomerName, Address1, City, Contact, Phone)
VALUES
('Петренко Петр Петрович', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212'),
('Иваненко Иван Иванович', 'Дихтяревская 5', 'Чернигов', 'IvanenkoIvan@gmail.com', '(095)2313244');	

INSERT INTO Orders
(CustomerNo, OrderDate,	Goods)
VALUES
(1, GETDATE(), 'KeyBoard'),
(2, GETDATE(), 'Mouse');


SELECT CustomerNO, CustomerName, Address1, City FROM Customers;
SELECT * FROM Orders;



INSERT INTO Orders
(CustomerNo, OrderDate,	Goods)
VALUES
(2, GETDATE(), 'WebCam'),
(1, GETDATE(), 'Mouse');  -- Ошибка

-------------------------------------------------------------------------
--                 Связь Один ко Многим
-------------------------------------------------------------------------


DROP TABLE Orders;
GO

DROP TABLE Customers;
GO

CREATE TABLE Customers(
  CustomerNo INT IDENTITY(1,1) NOT NULL,
  CustomerName VARCHAR(30) NOT NULL,
  Address1 VARCHAR(30) NOT NULL,
  City VARCHAR(30) NOT NULL,
  Contact VARCHAR(30) NOT NULL,
  Phone CHAR(12)

  );
GO

CREATE TABLE Orders(
  OrderID INT IDENTITY NOT NULL,
  CustomerNo INT NOT NULL, 
  OrderDate DATE NOT NULL,
  Goods varchar(30) NOT NULL  
  );
GO

ALTER TABLE Customers ADD CONSTRAINT PK_Customer PRIMARY KEY(CustomerNo);
  ALTER TABLE Orders ADD CONSTRAINT PK_Order PRIMARY KEY (OrderID)
ALTER TABLE Orders ADD CONSTRAINT FK_Orders FOREIGN KEY (CustomerNo) REFERENCES Customers(CustomerNo)


INSERT INTO Customers																			   
(CustomerName, Address1, City, Contact, Phone)
VALUES
('Петренко Петр Петрович', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212'),
('Иваненко Иван Иванович', 'Дихтяревская 5', 'Чернигов', 'IvanenkoIvan@gmail.com', '(095)2313244');	

INSERT INTO Orders
(CustomerNo, OrderDate,	Goods)
VALUES
(1, GETDATE(), 'KeyBoard'),
(2, GETDATE(), 'Mouse'),
(2, GETDATE(), 'WebCam'),
(1, GETDATE(), 'Mouse');

SELECT CustomerNO, CustomerName, Address1, City FROM Customers;
SELECT * FROM Orders;

-------------------------------------------------------------------------
--                 Связь Многие ко Многим
-------------------------------------------------------------------------


DROP table Students;
DROP TABLE Courses;
DROP TABLE StudentsCourses;


CREATE TABLE Students(
  StudentID INT IDENTITY NOT NULL,
  Fname VARCHAR(30) NOT NULL,
  LName VARCHAR(30) NOT NULL,
  Email VARCHAR(30) NOT NULL,
  Phone VARCHAR(30) NOT NULL
  )

CREATE  TABLE  Courses(
  CourseID INT IDENTITY NOT NULL,
  CourseName NVARCHAR(50) NOT NULL,
  Price MONEY NOT NULL
  )

CREATE TABLE StudentsCourses(
  StudentID INT NOT NULL,
  CourseId INT NOT NULL,
  )


  ALTER TABLE Students ADD CONSTRAINT PK_Student PRIMARY KEY(StudentID);
  ALTER TABLE Courses ADD CONSTRAINT PK_Courses PRIMARY KEY(CourseID)
  ALTER TABLE StudentsCourses ADD CONSTRAINT FK_Student FOREIGN KEY (StudentID) REFERENCES Students (StudentID)
  ALTER TABLE StudentsCourses ADD CONSTRAINT FK_Courses FOREIGN KEY (CourseId) REFERENCES Courses (CourseID)
