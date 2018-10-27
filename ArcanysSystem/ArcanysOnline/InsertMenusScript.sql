/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [dbo].[Menus]
           ([PageName]
           ,[PageDescription]
           ,[PageURL]
		   ,[PageIcon] 
           ,[isEnabled]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[LastUpdatedOn]
           ,[LastUpdatedBy]
           ,[DeletedOn]
           ,[DeletedBy])
     VALUES
           ('Dashboard'
           ,'Dashboard Page'
           ,'/Application/Dashboard'
		   ,'fa-dashboard'
           ,1
           ,GETDATE()
           ,1
           ,NULL
           ,NULL
           ,NULL
           ,NULL)
GO
INSERT INTO [dbo].[Menus]
           ([PageName]
           ,[PageDescription]
           ,[PageURL]
		   ,[PageIcon] 
           ,[isEnabled]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[LastUpdatedOn]
           ,[LastUpdatedBy]
           ,[DeletedOn]
           ,[DeletedBy])
     VALUES
           ('Home'
           ,'Home Page'
           ,'/Home/Index'
		   ,'fa-home'
           ,1
           ,GETDATE()
           ,1
           ,NULL
           ,NULL
           ,NULL
           ,NULL)
GO