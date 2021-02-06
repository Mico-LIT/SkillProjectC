USE [C:\REPO\PROJECT\SQL\SKILLDB.MDF] 

--------------------------------------------------------------------------
--                   Условная конструкция IF..ELSE
--------------------------------------------------------------------------

DECLARE @myVar VARCHAR(10);

 set @myVar = 'HI'

-- В условной конструкции IF, указываем выражение: @myVar is NULL 
  IF @myVar IS NULL
    PRINT ('myVar не задано')
    ELSE
    PRINT @myVar

--------------------------------------------------------------------------
--                        Операция EXISTS
--------------------------------------------------------------------------
-- Операция EXISTS возвращает значение TRUE или FALSE, в зависимости от того
-- имеется ли соответствующие запросу SELECT данные 


IF EXISTS(SELECT * FROM BTree WHERE numbers=23)
  PRINT 'Yes'
  ELSE
  PRINT 'No'

----------------------------------------------------------------------------

-- таблица sys.schemas содержит информацию о схемах применямых в даной БД
  SELECT * FROM sys.schemas
-- таблица sys.tables содержит информацию о таблицах применямых в даной БД
  SELECT * FROM  sys.tables

----------------------------------------------------------------------------

--пример создания таблицы TestTable с предпроверкой не создана ли она ранее.
IF NOT EXISTS (    
				SELECT s.name,t.name
				FROM sys.schemas AS s					-- schemas - системная таблица хранящая информацию о схемах
					JOIN sys.tables AS t				-- tables - системная таблица хранящая информацию о таблицах
					 ON s.schema_id = t.schema_id	-- выборка таблицы находящейся в схеме
				WHERE s.name = 'dbo'				-- где схема dbo
					AND t.name = 'TestTable'		-- и таблица TestTable
				)				
	CREATE TABLE TestTable --создать таблицу если она не существует
		(
			Col1 int,
			Col2 varchar(20)
		)	
ELSE
	PRINT 'Таблица TestTable уже существует!' -- вывести сообщение если существует
----------------------------------------------------------------------------

----- групировка операторов в блоки -----

DROP TABLE TestTable;
-- Если необходимо выполнить несколько операторов, их обеденяют в блоки BEGIN ... END
IF NOT EXISTS (    
				SELECT s.name,t.name
				FROM sys.schemas s 
				JOIN sys.tables t  
					ON s.schema_id=t.schema_id 
				WHERE s.name = 'dbo' 
					AND t.name = 'TestTable' 
				)	
				
	BEGIN   -- Начало блока
		PRINT 'Таблица TestTable не найдена';
		PRINT 'Создаю таблицу TestTable';
		CREATE TABLE TestTable   -- Создать таблицу если она не существует
			(
				Col1 int,
				Col2 varchar(20)
			)
	END   -- Конец блока
	
ELSE
	BEGIN
		PRINT 'Таблица TestTable существует!'; 
		PRINT 'Удаляю таблицу TestTable';
		DROP TABLE TestTable;
		PRINT 'Таблица TestTable удалена';
	END;
GO



----------------------------------------------------------------------------
--                            Оператор CASE 
----------------------------------------------------------------------------
-- Простой оператор CASE 

DECLARE @myTinyVar TINYINT = 3

  PRINT CASE @myTinyVar
    WHEN 0 THEN '0'
    WHEN 1 THEN '1'
    WHEN 2 THEN '2'
    WHEN 3 THEN '3'
    ELSE 'More than three'
    END
GO

----------------------------------------------------------------------------
-- Поисковый оператор CASE 

DECLARE @myTinyVar TINYINT = 3

  PRINT CASE  -- отсутствует входное выражение
    WHEN @myTinyVar>0 THEN '0'
    WHEN @myTinyVar = 2  THEN '1'
    WHEN @myTinyVar = 2 THEN '2'
    WHEN @myTinyVar=3 THEN '3'
    ELSE 'Непредвиденная ситуация'
    END
GO

----------------------------------------------------------------------------
-- Оператор WHILE. Организация циклов

DECLARE @myVar int;
SET @myVar = 0;

    WHILE (@myVar < 21) -- условие выполнения цикла, пока условие истинно выполняется цикл.
    BEGIN
        PRINT 'Текущее Значение ' + CAST (@myVar as varchar);
        SET @myVar = @myVar + 1;
    END
GO
----------------------------------------------------------------------------


DECLARE @myVar int;
SET @myVar =0;

    WHILE @myVar < 21 
    BEGIN
        PRINT 'Текущее Значение ' + CAST (@myVar as varchar);
        IF @myVar =5
            BEGIN
                SET @myVar = @myVar + 2;
                CONTINUE; -- Прерывает дальнейшее выполнение текущей итерации и возвращается в начало цикла WHILE
            END; 
        SET @myVar = @myVar + 1;
    END
GO
----------------------------------------------------------------------------

DECLARE @myVar int;
SET @myVar = 0;

    WHILE @myVar < 21 
    BEGIN
        PRINT 'Текущее Значение ' + CAST (@myVar as varchar);	
        IF @myVar = 7 
            BEGIN
            PRINT '@myVar = 7! Прерывание цикла!' 
            BREAK; -- Оператор прерывания цикла (не рекомендуется использовать)
        END
        SET @myVar = @myVar + 1;
    END
GO

----------------------------------------------------------------------------
--------------------------- Блоки TRY и CATCH ------------------------------
-- предназначены для обработки ошибок

BEGIN TRY -- Попытка выполнить код, если возникает ошибка то бросаем ее в блок CATCH, иначе продолжаем работу без блока CATCH. 

    CREATE TABLE TestTable 
        (
            col1 int,
            col2 varchar(10)	
        );

END TRY
BEGIN CATCH -- блок CATCH - блок-обработчик ошибок

    DECLARE @ErrorNo  int,
            @Message  nvarchar(4000);

    SELECT
        @ErrorNo = ERROR_NUMBER(),--системная функция, возвращает код текущей ошибки
        @Message = ERROR_MESSAGE();--системная функция, возвращает сообщение текущей ошибки

    IF @ErrorNo = 2714
        PRINT 'Данная таблица уже существует!'
    ELSE
        PRINT CAST(@ErrorNo as varchar)+' '+@Message;
END CATCH
GO

----------------------------------------------------------------------------

BEGIN TRY -- пытаемся выполнить код, если возникает ошибка то бросаем ее в блок CATCH, иначе продолжаем работу без блока CATCH. 

    DROP TABLE TestTable;

END TRY

BEGIN CATCH -- блок CATCH - блок-обработчик ошибок

    DECLARE @ErrorNo  int,
            @Message  nvarchar(4000);

    SELECT
        @ErrorNo = ERROR_NUMBER(),		--системная функция, возвращает код текущей ошибки
        @Message = ERROR_MESSAGE();		--системная функция, возвращает сообщение текущей ошибки

    IF @ErrorNo = 3701
        PRINT 'Данная таблица уже удалена!'
    ELSE
        PRINT CAST(@ErrorNo as varchar)+' '+@Message;
END CATCH
GO

----------------------------------------------------------------------------
--                 Активация сообщения об ошибке вручную 
IF NOT EXISTS (
                SELECT s.name,t.name
                FROM sys.schemas as s 
                JOIN sys.tables t  
                ON s.schema_id = t.schema_id 
                WHERE s.name = 'dbo' 
                AND t.name = 'TestTable' 
                )
                
   BEGIN   -- начало блока
      PRINT 'Таблица TestTable не найдена';
      PRINT 'Создаю таблицу TestTable';
      CREATE TABLE TestTable --создать таблицу если она не существует
                (
                Col1 int,
                Col2 varchar(10)
                )
   END   -- конец блока

ELSE
   BEGIN
      RAISERROR('Данная таблица существует', 11, 238) -- Ошибка вызваная пользователем в ручную 
      -- RAISERROR('Данная таблица существует', 11, 238)-- Снять комментарий		
      -- (второй аргумент RAISERROR - степень серезности ошибки и обозначение состояния)
      -- RAISERROR (строка сообщения, степень серезности ошибки, обозначение состояния)
      /*степень серезности ошибки - определяет какие действия следует принимать при возникновении ошибки
      обозначение состояния - произвольное значение, применяется в роли маркера места возникшей ошибки, 
      если у нас в нескольких местах происходит ошибка, то видя значение 
      обозревателя состояния можно определить где возникла в коде ошибка*/
   END;
GO