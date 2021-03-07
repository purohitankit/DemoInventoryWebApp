
Create procedure [dbo].[GetInventoryList]
as
begin
 BEGIN TRY
	select * from Inventory
 END TRY
      BEGIN CATCH
            DECLARE @ErrorMessage Varchar(4000)            
            SELECT @ErrorMessage=ERROR_MESSAGE();
            RAISERROR(@ErrorMessage,0,0);
      END CATCH
end
