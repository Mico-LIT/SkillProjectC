USE[C:\REPO\PROJECT\SQL\SKILLDB.MDF]

--Показать статистику по количеству проданых единиц товара.
SELECT p.ProdID, p.Description, 
  SUM(od.Qty) AS Qty, SUM(od.TotalPrice)  AS TotalSold
  FROM Products p 
  JOIN OrderDetails od ON p.ProdID = od.ProdID
  GROUP BY p.ProdID, p.Description

-- Вывести общую суму продаж по сотрудикам.
  SELECT 
    e.FName,
    e.LName,
    e.MName,
    SUM(od.TotalPrice) AS [Total Sold]
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    JOIN OrderDetails od ON o.OrderID = od.OrderID

-- Вывести план подченения сотрудников (Кто кому подчиняется)

  SELECT 
    e.FName,e.LName,e.MName,
    e1.FName,e1.LName,e1.MName
    
    FROM Employees e 
    JOIN Employees e1 ON e.EmployeeID = e1.ManagerEmpID

