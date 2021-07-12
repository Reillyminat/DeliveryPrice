--1
SELECT ProductName, (SELECT AVG(UnitPrice) FROM Products) AS AvgPrice, UnitPrice 
FROM Products 
WHERE UnitPrice > (SELECT AVG(UnitPrice) average_price FROM Products)
--2
SELECT C.CategoryName, MAX(UnitPrice) AS Maxprice FROM Products P JOIN Categories C ON P.CategoryID=C.CategoryID GROUP BY C.CategoryName
--3
SELECT LastName, FirstName, TerritoryDescription, RegionDescription,Region.RegionID FROM Employees 
JOIN EmployeeTerritories ON Employees.EmployeeID=EmployeeTerritories.EmployeeID 
JOIN Territories ON EmployeeTerritories.TerritoryID=Territories.TerritoryID
JOIN Region ON Territories.RegionID=Region.RegionID
--4
INSERT INTO Territories VALUES (85364,'Arizona',5);
INSERT INTO Region VALUES (5,'South-West');

SELECT EmployeeID, RegionDescription FROM EmployeeTerritories 
JOIN Territories ON EmployeeTerritories.TerritoryID=Territories.TerritoryID
RIGHT OUTER JOIN Region ON Territories.RegionID=Region.RegionID GROUP BY RegionDescription, EmployeeID HAVING EmployeeID IS NULL
