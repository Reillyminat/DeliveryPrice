USE DeliveryService
DECLARE @xmlDoc xml
SET @xmlDoc=(SELECT CONVERT(XML, BulkColumn) AS BulkColumn
FROM OPENROWSET(BULK 'C:\Users\illym\Source\Repos\Reillyminat\DeliveryPrice\SQL\Task 5\Users.xml', SINGLE_BLOB) AS x);
EXEC [dbo].[MergeWithXml] @tableName=Users,@request=@xmlDoc