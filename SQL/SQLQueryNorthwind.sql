use Northwind
--4
SELECT * FROM Customers WHERE Region='RJ' UNION
SELECT * FROM Customers WHERE City='Geneve'
--5
SELECT LastName, FirstName, BirthDate, Hiredate, Address, City, Region FROM Employees WHERE Region='WA' EXCEPT
SELECT LastName, FirstName, BirthDate, Hiredate, Address, City, Region FROM Employees WHERE City='Seattle'
--6
SELECT Country, Region, COUNT (Region) AS SuppliersCount FROM Suppliers WHERE Region IS NOT NULL GROUP BY Region, Country HAVING COUNT (Region)>1