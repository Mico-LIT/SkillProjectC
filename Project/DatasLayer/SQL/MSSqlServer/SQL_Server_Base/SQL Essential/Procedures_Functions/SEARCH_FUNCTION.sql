USE ShopDB
GO	

  DROP TABLE MyEmployee
---------- Создаем таблицу сотрудников. ----------
CREATE TABLE MyEmployee
(
  EmployeeID int NOT NULL,
  ManagerID int NULL REFERENCES MyEmployee(EmployeeID), -- Показвает кому подченяется данный сотрудник.
  JobTitle nvarchar(50) NOT NULL,
  LastName nvarchar(50) NOT NULL,
  FirstName nvarchar(50) NOT NULL,
    CONSTRAINT PK_Employee2_EmployeeID PRIMARY KEY CLUSTERED (EmployeeID ASC)
);
GO

-- Иерархические данные (так как таблица содержит информацию о сторудниках подчиняющихся сотрудникам информация о которых так же хранится в этой таблице)
INSERT INTO MyEmployee(EmployeeID,ManagerID,JobTitle,LastName,FirstName)
VALUES
  (1, NULL, N'Генеральный директор',N'Сидоров', N'Виктор'),
  (2, 1, N'Финансовый директор', N'Левченко', N'Людмила'),	
  (3, 1, N'Кадровая поддержка',N'Стипанов',N'Григорий'),		
  (4, 1, N'Исполнительный директор', N'Самойленко', N'Виктор'),
  (5, 4, N'Инженер', N'Тимченко', N'Виталий'),			
  (8, 5, N'Инженер', N'Хабиб', N'Эльдар'),			
  (9, 5, N'Программист', N'Дулев', N'Павел'),				
  (10 ,5, N'Data Architect', N'Черчев', N'Робнрт'),			
  (11 ,5, N'Програмист', N'Залозный', N'Михаил'),				
  (6, 4, N'Персональный секретарь', N'Радченко', N'Вика'),	
  (7, 4, N'Начальник охраны',N'Стельмах',N'Игорь');				

SELECT * FROM MyEmployee;

-- Узнаем кто подчиняется исполнительному директору.
SELECT  sub.EmployeeID,
		sub.FirstName,
		sub.LastName
FROM
	MyEmployee as boss
	JOIN
	MyEmployee as sub
	ON boss.EmployeeID = sub.ManagerID
WHERE boss.JobTitle LIKE N'Исполнительный директор';
GO

-- Рекурсивная функция вывода всех подчиненных.

  DROP FUNCTION fnGetSub
  CREATE FUNCTION fnGetSub(@EmpID int) -- Создаем функцию с одним аргументом.
    RETURNS @Sub TABLE(  -- Обявляем возвращаемую таблицу.
    EmployeeID INT,
    SubID INT,
    Name NVARCHAR(90)
    )
    AS
    BEGIN 
      DECLARE @_EmpID INT ;

      INSERT @Sub (EmployeeID, SubID, Name)-- Добаляем запись о руководителе в выходную таблицу.
      SELECT EmployeeID, ManagerID ,FirstName+' '+LastName
        FROM MyEmployee me WHERE me.EmployeeID = @EmpID


      SELECT @_EmpID = (
        SELECT min(me.EmployeeID) FROM MyEmployee me WHERE -- Определяем первого подчеенного.
                        me.ManagerID = @EmpID
        )
      WHILE @_EmpID IS NOT NULL-- Пока есть подчиненные выполняем цикл.
        BEGIN 
          INSERT @Sub -- Добавляем запись о подчененных относительно выше выбраного руководителя.
            SELECT * FROM dbo.fnGetSub(@_EmpID) gs  -- Рекурсия.
          
      SET @_EmpID = 
        (
          SELECT MIN(me.EmployeeID) FROM MyEmployee me -- Определяем следующего подчиненного.
          WHERE me.EmployeeID >@_EmpID
          AND me.ManagerID = @EmpID 
          )
        
        END
      RETURN;
      
      END
    GO

SELECT * FROM dbo.fnGetSub(4); -- Воспользуемся для поиска функцией - fnGetSub.
SELECT * FROM MyEmployee;




