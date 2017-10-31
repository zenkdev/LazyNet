USE lazynet
GO

DECLARE @_name  NVARCHAR(200) = N'Samsung Smart TV'
DECLARE @_group NVARCHAR(200) = N'Разное'

INSERT dbo.PhotoLibrary(CreatedOn,UpdatedOn,Oid,Name,[Group],Photo,OptimisticLockField)
VALUES (GETDATE(),GETDATE(),NEWID(),@_name,@_group,NULL,0)

-- ПУТЬ К ФАЙЛУ ОТНОСИТЕЛЬНО СЕРВЕРА
UPDATE dbo.PhotoLibrary SET Photo = (SELECT * FROM OPENROWSET(BULK 'c:\Hardware\samsung-smart-tv.png', SINGLE_BLOB) AS x) WHERE Id = SCOPE_IDENTITY()
GO

