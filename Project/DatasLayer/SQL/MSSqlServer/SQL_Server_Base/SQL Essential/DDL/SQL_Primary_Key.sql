USE [C:\REPOSITORIES\SKILL\SKILLPROJECTC\PROJECT\SQL\SKILLDB.MDF]
GO

--ALTER DATABASE [C:\REPOSITORIES\SKILL\SKILLPROJECTC\PROJECT\SQL\SKILLDB.MDF] -- кодировка 
--COLLATE Cyrillic_General_CI_AS


--DROP TABLE Customers

-------------------------------------------------------------------------
--                  Создание первичного ключа
-------------------------------------------------------------------------
-- PRIMARY KEY (первичный ключ, ограничение первичного ключа)


-- Значения ячеек столбца(-ов) с ограничением PRIMARY KEY 
-- однозначно определяет (-ют) каждую строку в таблице.

CREATE TABLE CustomersV2(
  CustomerNo INT PRIMARY KEY NOT NULL,
  CustomerName NVARCHAR(25) NOT NULL,
  Address1 NVARCHAR(25) NOT NULL,
  City NVARCHAR(15) NOT NULL,
  Contact NVARCHAR(25) NOT NULL,
  Phone NCHAR(12) 
  )

  GO

SELECT * FROM Customers c
SELECT * FROM CustomersV2 c
GO

--DROP TABLE CustomersV2

INSERT INTO CustomersV2																			   
(CustomerNO, CustomerName, Address1, City, Contact, Phone)
VALUES
(1,'Привет', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212'),
(2,'Иваненко Иван Иванович', 'Дихтяревская 5', 'Чернигов', 'IvanenkoIvan@gmail.com', '(095)2313244'); 
GO

SELECT * FROM CustomersV2
GO

-- Попытка нарушить уникальность.
INSERT INTO CustomersV2																			   
(CustomerNO, CustomerName, Address1, City, Contact, Phone)
VALUES
(1,'Сидоров Семен Семенович', 'Драйзера 12', 'Харьков', 'SemSem@mail.ru', '(063)4533272'); -- Ошибка!
GO


DROP TABLE CustomersV2
GO

-- Если первичный ключ состоит из двух и более столбцов,
-- его называют составным первичный ключом. 
-- Попытка вставить второй Первичный ключ в таблицу приводит к ошибке.
-- Первичный ключ в таблице может быть только один (простой или составной)


CREATE TABLE CustomersV2(
    
  CustomerNo INT NOT NULL,
  CustomerName NVARCHAR(25) NOT NULL,
  Address1 NVARCHAR(25) NOT NULL,
  City NVARCHAR(15) NOT NULL,
  Contact NVARCHAR(25) NOT NULL,
  Phone NCHAR(12) 
  PRIMARY KEY (CustomerNo,CustomerName) -- задаем составной первичный ключ на столбцах CustomerNo, CustomerName
  )



INSERT INTO CustomersV2																	   
(CustomerNO, CustomerName, Address1, City, Contact, Phone)
VALUES
(1,'Петренко Петр Петрович', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212'),
(2,'Иваненко Иван Иванович', 'Дихтяревская 5', 'Чернигов', 'IvanenkoIvan@gmail.com', '(095)2313244'); 
GO

INSERT INTO CustomersV2																			   
(CustomerNO, CustomerName, Address1, City, Contact, Phone)
VALUES
(1,'Сидоров Семен Семенович', 'Драйзера 12', 'Харьков', 'SemSem@mail.ru', '(063)4533272'); 

INSERT INTO CustomersV2																			   
(CustomerNO, CustomerName, Address1, City, Contact, Phone)
VALUES
(2,'Иваненко Иван Иванович', 'Янгеля 32', 'Киев', 'IvanenkoIvan@mail.ru', '(050)1752124'); -- Ошибка!

SELECT * FROM CustomersV2;

-- Создание ограничения первичного ключа на существующей таблице
DROP TABLE CustomersV2;
GO

CREATE TABLE CustomersV2               
(                                      
	CustomerNO int IDENTITY NOT NULL, 
	CustomerName varchar(25) NOT NULL,
	Address1 varchar(25) NOT NULL,
	City     varchar(15) NOT NULL,
	Contact  varchar(25) NOT NULL,
	Phone char(12)             
)
GO


-- Изменяем таблицу	Customers задав ограничение первичного ключа на столбце	CustomerNo
  ALTER TABLE CustomersV2
  ADD CONSTRAINT PK_CustomersV2 
  PRIMARY KEY (CustomerNo)

  
  INSERT INTO CustomersV2																			   
  (CustomerName, Address1, City, Contact, Phone)
  VALUES
  ('Петренко Петр Петрович', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212'),
  ('Иваненко Иван Иванович', 'Дихтяревская 5', 'Чернигов', 'IvanenkoIvan@gmail.com', '(095)2313244'); 
  GO

  SELECT * FROM CustomersV2;

  DROP TABLE CustomersV2;
  GO

  CREATE TABLE CustomersV2             
  (                                      
  	CustomerNO int NOT NULL, 
  	CustomerName varchar(25) NOT NULL,
  	Address1 varchar(25) NOT NULL,
  	City     varchar(15) NOT NULL,
  	Contact  varchar(25) NOT NULL,
  	Phone char(12)             
  )
  GO

  ALTER TABLE CustomersV2
    ADD 
    PRIMARY KEY (CustomerNo,CustomerName) 


  INSERT INTO CustomersV2																			   
  (CustomerNO, CustomerName, Address1, City, Contact, Phone)
  VALUES
  (1,'Петренко Петр Петрович', 'Луганская 25', 'Конотоп', 'PetrPetrenko@mail.ru', '(093)1231212'),
  (2,'Иваненко Иван Иванович', 'Дихтяревская 5', 'Чернигов', 'IvanenkoIvan@gmail.com', '(095)2313244'); 
  GO
  
  INSERT INTO CustomersV2																			   
  (CustomerNO, CustomerName, Address1, City, Contact, Phone)
  VALUES
  (1,'Сидоров Семен Семенович', 'Драйзера 12', 'Харьков', 'SemSem@mail.ru', '(063)4533272'); 
  
  INSERT INTO CustomersV2																			   
  (CustomerNO, CustomerName, Address1, City, Contact, Phone)
  VALUES
  (2,'Иваненко Иван Иванович', 'Янгеля 32', 'Киев', 'IvanenkoIvan@mail.ru', '(050)1752124'); 
  
  SELECT * FROM CustomersV2;



