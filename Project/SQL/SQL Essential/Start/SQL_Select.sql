USE [C:\REPOSITORIES\SKILL\SKILLPROJECTC\PROJECT\SQL\SKILLDB.MDF];
GO
--------------------------------------------------------------------------
--                     Выборка данных. Запрос SELECT 
--------------------------------------------------------------------------

-- Производим выборку всех данных из таблицы MyFriends.
SELECT * FROM MyFriends; 

-- Производим выборку данных из столбца FstName, таблицы MyFriends
SELECT FstName FROM MyFriends; 

-- Производим выборку данных из столбца LstName, таблицы MyFriends
SELECT LstName FROM MyFriends; 

SELECT BthDate FROM MyFriends; 

-- Производим выборку данных из столбцов FstName и LstName, таблицы MyFriends
SELECT FstName, LstName FROM MyFriends; 

-- Производим выборку данных из столбцов FstName, LstName и BthDate, таблицы MyFriends
SELECT FstName,LstName,BthDate FROM MyFriends; 

--------------------------------------------------------------------------
