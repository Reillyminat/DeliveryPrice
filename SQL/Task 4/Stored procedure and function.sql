USE [DeliveryService]
GO
/****** Object:  StoredProcedure [dbo].[GenerateUniqueKey]    Script Date: 01.07.2021 20:47:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GenerateUniqueKey]
	@tablename AS varchar, @readableId AS varchar(MAX) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SET @readableId = CONCAT(SUBSTRING(@tablename, 1, 1),NEWID())
END

/****** Object:  UserDefinedFunction [dbo].[GetUniqueKey]    Script Date: 01.07.2021 20:49:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetUniqueKey]
(
	@tableName varchar, @rowsCount int
)
RETURNS varchar(MAX)
AS
BEGIN
	DECLARE @id AS varchar(max)
	SET @id = CONCAT(SUBSTRING(@tablename, 1, 1),@rowsCount);
	RETURN @id
END


DECLARE @id varchar(max), @rowsCount int
EXEC GenerateUniqueKey @tablename=UserTypes, @id=@id OUTPUT
INSERT INTO UserTypes VALUES (@id,'registered user');

SELECT @rowsCount=COUNT(id) FROM UserTypes
INSERT INTO UserTypes VALUES (dbo.GetUniqueKey('UserTypes',@rowsCount),'new user');


