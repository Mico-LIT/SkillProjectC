USE[C:\REPO\PROJECT\SQL\SKILLDB.MDF]

go
-- »спользовать курсоры только при крайней необходимости!
--  урсор - набор записей вместе с указателем, который идентифицирует текущую строку.

  --------------------------- ќпределение курсора -------------------------------------

  DECLARE OrdersDetails_cursor CURSOR -- объ€вление курсора
    FOR 
       SELECT * FROM OrderDetails -- отбор строк дл€ курсора

    OPEN OrdersDetails_cursor           -- открытие курсора
      CLOSE OrdersDetails_cursor        -- закрытие курсора
        DEALLOCATE OrdersDetails_cursor -- удаление курсора
GO

-- FETCH извлекает данные из курсора 


 DECLARE BTree_cursor CURSOR
  SCROLL
  FOR
  SELECT * FROM dbo.BTree

  OPEN BTree_cursor

  DECLARE @FildOne VARCHAR(20),
          @FildTwo VARCHAR(20)
  FETCH NEXT FROM BTree_cursor  -- NEXT извлекает строку 
    INTO @FildOne,@FildTwo
    SELECT @FildOne,@FildTwo

  FETCH PRIOR FROM BTree_cursor  -- PRIOR - и извлекает предыдущ
    INTO @FildOne,@FildTwo
    SELECT @FildOne,@FildTwo

  FETCH LAST FROM BTree_cursor --- LAST извлекает последнюю строку
    INTO @FildOne,@FildTwo
    SELECT @FildOne,@FildTwo
  
  FETCH FIRST FROM BTree_cursor -- FIRST извлекает первую строку
    INTO @FildOne,@FildTwo
    SELECT @FildOne,@FildTwo

  FETCH ABSOLUTE 3 FROM BTree_cursor -- ABSOLUTE n извлечь строку номер n
    INTO @FildOne,@FildTwo
    SELECT @FildOne,@FildTwo

      SELECT * FROM Btree
  FETCH RELATIVE 5 FROM BTree_cursor -- RELATIVE n извлечь n-ную строку после текущей
    INTO @FildOne,@FildTwo
    SELECT @FildOne,@FildTwo
  
  CLOSE BTree_cursor
    DEALLOCATE BTree_cursor

GO

SELECT @FildOne,@FildTwo
-- LOCAL - позвол€ет автоматически закрывать и удал€ть курсор после выполнени€ скрипта.

 
DECLARE BTree_cursor CURSOR
  LOCAL
  FOR 
  SELECT * FROM BTree
  
  OPEN BTree_cursor

    DECLARE @FildOne VARCHAR(20),@FildTwo VARCHAR(20)

  FETCH NEXT FROM BTree_cursor
    INTO @FildOne,@FildTwo

    SELECT @FildOne,@FildTwo
 go
DEALLOCATE BTree_cursor -- ќшибка, так как LOCAL удалил курсор.
  go





