
Create procedure [dbo].[SaveInventory]
 @Name nvarchar(40),
 @Description nvarchar(100),
 @Price Int,
 @Picture nvarchar(100) =null
as 
begin
 BEGIN TRY
	Insert into Inventory values(@Name,@Description,@Price,@Picture);
	select 1
 END TRY
      BEGIN CATCH
            DECLARE @ErrorMessage Varchar(4000)            
            SELECT @ErrorMessage=ERROR_MESSAGE();
            RAISERROR(@ErrorMessage,0,0);
      END CATCH
end