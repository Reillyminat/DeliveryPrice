USE [DeliveryService]
GO
/****** Object:  StoredProcedure [dbo].[MergeWithXml]    Script Date: 03.07.2021 16:25:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[MergeWithXml]
	@tablename AS varchar, @request AS xml
AS
BEGIN
BEGIN TRAN
BEGIN TRY
DECLARE @xmlDoc xml
DECLARE @xmlDocHandle integer


--Creating XML document based on Users table
SET @xmlDoc=(SELECT CONVERT(XML, BulkColumn) AS BulkColumn
FROM OPENROWSET(BULK 'C:\Users\illym\Source\Repos\Reillyminat\DeliveryPrice\SQL\Task 5\Users.xml', SINGLE_BLOB) AS x);
EXEC sp_xml_preparedocument @xmlDocHandle OUTPUT, @xmlDoc;

WITH SOURCE AS (SELECT UserId,
Address,
FullName,
Telephone  FROM OPENXML(@xmlDocHandle,'/*/*',2)
WITH(
UserId int,
Address nvarchar(MAX),
FullName nvarchar(MAX),
Telephone numeric(18,0)
))

MERGE Users AS TARGET
USING SOURCE
ON (TARGET.UserId=SOURCE.UserId)
WHEN MATCHED THEN UPDATE SET UserId=SOURCE.UserId
WHEN NOT MATCHED THEN INSERT VALUES (SOURCE.UserId, SOURCE.Address,SOURCE.FullName,SOURCE.Telephone)
WHEN NOT MATCHED BY SOURCE THEN DELETE;

EXEC sp_xml_removedocument @xmlDocHandle
COMMIT TRAN
END TRY
BEGIN CATCH
ROLLBACK TRAN
EXEC sp_xml_removedocument @xmlDocHandle
END CATCH

END