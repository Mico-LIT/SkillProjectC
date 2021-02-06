USE [C:\REPOSITORIES\SKILL\SKILLPROJECTC\PROJECT\SQL\SKILLDB.MDF]
GO

--------------------------------------------------------------------------
--				Конструкция ORDER BY
--------------------------------------------------------------------------

SELECT * FROM MyFriends mf 
  ORDER BY mf.FstName desc -- Сортировка по убыванию.

  SELECT * FROM MyFriends mf 
  ORDER BY mf.FstName asc -- Сортировка по возрастанию. ASC - по умолчанию.
