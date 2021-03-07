
Create procedure [dbo].[GetInventoryById]
 @Id nvarchar(40)
as 
begin
 BEGIN TRY
	select Name,Description,Price,Picture from Inventory where Id=@Id;
	select 1
 END TRY
      BEGIN CATCH
            DECLARE @ErrorMessage Varchar(4000)            
            SELECT @ErrorMessage=ERROR_MESSAGE();
            RAISERROR(@ErrorMessage,0,0);
      END CATCH
end