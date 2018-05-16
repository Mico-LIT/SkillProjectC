USE [C:\REPOSITORIES\SKILL\SKILLPROJECTC\PROJECT\SQL\SKILLDB.MDF]
GO
--------------------------------------------------------------------------
--				Агрегирование данных. Конструкция GROUP BY
--------------------------------------------------------------------------

-- Агрегирование - процесс обьединения элементов

-- WHERE работает до группировки, а HAVING работает вместе с группировкой.
  SELECT mf.LstName, COUNT(*) -- Агрегированная функция COUNT()
  FROM MyFriends mf
    --WHERE mf.FrndId IN (1,2,3,4)
  GROUP BY mf.LstName
  HAVING count(*)>2
