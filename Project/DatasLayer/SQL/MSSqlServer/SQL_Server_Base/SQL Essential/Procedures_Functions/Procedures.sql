USE[C:\REPO\PROJECT\SQL\SKILLDB.MDF]

----------------------------------------------------------------------
  
  CREATE PROC spCustomers -- Создание хранимой процедуры. 
    AS
    SELECT * FROM Customers
GO

EXEC spEmployee
GO
----------------------------------------------------------

  ALTER PROCEDURE spCustomers
    AS
    SELECT c.CustumerNo, c.City FROM Customers c
    GO

EXEC spEmployee
  DROP PROC spEmployee
    EXEC spEmployee ---- ОШИБКА, так как данная процедура удалена.
GO

--------------------------------

/*Хранимая процедура с параметрами*/

  DROP PROCEDURE spCustomers

    CREATE PROC spCustomers
      @State CHAR(2)
      AS

      SELECT * FROM Customers c WHERE c.State = @State
GO

EXEC spCustomers '22'

EXEC spEmployeeByName -- ОШИБКА если не передать обязательное значение по умолчанию
GO
---------------------------------

DROP PROC spEmployeeByName;
GO

CREATE PROC spEmployeeByName
	@LastName nvarchar(25) = NULL -- чтобы указать что параметр является не обязательным, при инициализации необходимо ввести для него значение по умолчанию.

AS
IF @LastName IS NOT NULL  -- условная конструкция IF где @LastName IS NOT NULL является проверочным выражением возвращающим TRUE или FALSE 
    
    SELECT pc.BusinessEntityID, pc.FirstName, pc.LastName, pc.ModifiedDate
    FROM Person.Person pc
    WHERE pc.LastName LIKE @LastName + '%'
    
ELSE
    
    SELECT pc.BusinessEntityID, pc.FirstName, pc.LastName, pc.ModifiedDate
    FROM Person.Person pc;
    
GO

EXEC spEmployeeByName     -- вызов без параметра.

EXEC spEmployeeByName 'Ca' --вызов с параметром

EXEC spEmployeeByName 'Cao' 
GO
--------------------------------------------------------------------------

/*Выходные параметры в хранимых процедурах*/
DROP PROC spEmployeeCount;
GO

CREATE PROC spEmployeeCount
    @Info int = null OUTPUT -- Для обьявления выходного парметра используется ключевое слово OUTPUT
AS
BEGIN
    SET @Info =(SELECT Count(*) From Person.Person);
END
GO

DECLARE @MyInfo int;

EXEC  spEmployeeCount @MyInfo OUTPUT; -- при вызове хранимой прроцедуры ключевое слово OUTPUT должно использоваться так же как и при обьявлении, обратите внимание как присваивается значение внешней переменной

PRINT CAST (@MyInfo as varchar);
GO
------------------------

---   Оператор возврата значения RETURN   --- 

DROP PROC TestProc
  CREATE proc TestProc
    AS
    DECLARE @i INT = 12
    RETURN @i  -- оператор RETURN в процедурах возвращает ТОЛЬКО целочисленное значение!
 GO

DECLARE @fild INT
EXEC @fild = TestProc
SELECT CAST(@MyRTN as varchar)

  GO
-----------------------------------------------
--- Рекурсия ----
-- МАКСИМАЛЬНАЯ ГЛУБИНА РЕКУРСИИ 32 УРОВНЕЙ
DROP PROC spFactial

  CREATE PROC spFactial
    @ValueIn INT,
    @ValueOut INT OUT
    AS
BEGIN
    DECLARE @InWorking int;
    DECLARE @OutWorking int;

  IF @ValueIn != 1 BEGIN  
    SET @InWorking = @ValueIn - 1;
    EXEC spFactial @InWorking , @OutWorking OUTPUT  -- вызов процедуры из самой себя (рекурсия)
  	SET @ValueOut = @ValueIn * @OutWorking
  END
    ELSE
    SET @ValueOut = 1
  END
GO

DECLARE @OUT INT;
EXEC spFactial 4,@OUT OUTPUT
SELECT @OUT

----Процедура регистрации ошибок в таблице -----

DROP TABLE ErrorLog

CREATE TABLE ErrorLog
(
    ErrorId int IDENTITY,
    ErrorLine int,
    ErrorMessage nvarchar(200)
)
GO

-- Создаем процедуру регистрации ошибок

  CREATE PROC uspLogError
    @ErrorLogId INT = 0 OUT
    AS

BEGIN 
    
  INSERT ErrorLog (ErrorLine,ErrorMessage)
  VALUES (ERROR_LINE(),ERROR_MESSAGE())
  set @ErrorLogId = @@identity
    
    
    END

------------------------------

BEGIN TRY
    
    CREATE TABLE OurTest
    (
        col int
    )
    
END TRY
BEGIN CATCH
    
    DECLARE @OutIdError int;
    
        PRINT N'Попытка создать существующую таблицу';
        EXEC uspLogError @OutIdError OUTPUT;
        PRINT N'Ошибка записана в журнал Номер записи: ' + CAST(@OutIdError as varchar);

        PRINT N'Не известная ошибка ';
        
END CATCH

SELECT * FROM ErrorLog

