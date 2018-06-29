USE [C:\REPO\PROJECT\SQL\SKILLDB.MDF] 
USE [ShopDB]
/*Пользовательские функции возвращаемые скалярное значение (не табличное)*/

  CREATE FUNCTION Hello() -- создать функцию
    RETURNS VARCHAR(30)-- обьявляем тип возвращаемого значения
    AS
    BEGIN 
    DECLARE @MyVar VARCHAR(20) = 'HI';
    RETURN @MyVar; -- возвращаемое значение 
    END 

    PRINT dbo.Hello();

    DROP TABLE TestTable;
    GO
    
    CREATE TABLE TestTable
    (
    id int identity not null,
    name varchar(25) not null,
    CDate smalldatetime not null
    )
    GO

-------------------------------------------------------


  DECLARE @MyVar INT = 1;
  DECLARE @MyVcVar VARCHAR(10);

  WHILE @MyVar < 20
    BEGIN 
    SET @MyVcVar = 'Test ' + CAST(@MyVar AS VARCHAR)
    INSERT TestTable (name, CDate)
  VALUES (@MyVcVar, DATEADD(Mi, @MyVar, GETDATE()))
    SET @MyVar = @MyVar + 1;  
    
    END

/* данная выборка будет пустая, так как функция GETDATE() 
 возвращает значение типа datetime (возвращает не только 
 дату но и текущее время до 3-х сотых секунды)*/
SELECT * FROM TestTable
WHERE CDate = GETDATE(); 
GO
---------------------------------------------------------

CREATE FUNCTION DateOnly (@date DATETIME)-- создаем функцию вводя ее имя и аргумент
  RETURNS DATE--обявляем возвращаемый тип
  AS
  BEGIN --тело функции
  RETURN CAST(@date AS DATE)-- приводим к типу date возвращаемое значение  
  END
GO

SELECT * FROM TestTable -- данная выборка вернет 19 записей(все за сегодняшний день
WHERE dbo.DateOnly(CDate)= dbo.DateOnly(GETDATE()); --нужно явно указывать схему при вызове пользовательской функции

--------------------------------------------------------


/*Пользвательские функции возвращемые таблицу*/


  CREATE FUNCTION fnCustomers()
    RETURNS TABLE
    AS
      RETURN (SELECT * FROM Customers c)
    GO

   SELECT * FROM dbo.fnCustomers(); 

  

--ЗАДАНИЕ: повторите предыдущий пример с помощью представления
CREATE VIEW viCustomers
  AS
  SELECT * FROM Customers c

  SELECT * FROM viCustomers

--------------------------------------------------------

  CREATE FUNCTION fnCustomersSearch(@myVar VARCHAR)
    RETURNS TABLE
    AS
    RETURN (SELECT * FROM Customers c WHERE c.CustumerName LIKE @myVar + '%')

    SELECT * FROM fnCustomersSearch('Ale')













