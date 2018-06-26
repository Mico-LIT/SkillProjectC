USE[C:\REPO\PROJECT\SQL\SKILLDB.MDF]

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

