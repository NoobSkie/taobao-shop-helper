CREATE VIEW [dbo].[v_ImportItem_All]
AS
SELECT     dbo.ImportItem.Id, dbo.ImportItem.OperatorUserId, dbo.ImportItem.OperatorUserName, dbo.ImportItem.ItsImportGroupId, dbo.ImportItem.ImportFormItemIid, 
                      dbo.ImportItem.ImportFormItemTitle, dbo.ImportItem.ImportFormItemPrice, dbo.ImportItem.ImportFormSellerNick, dbo.ImportItem.ImportFormShopTitle, 
                      dbo.ImportItem.ImportToItemIid, dbo.ImportItem.ImportToItemTitle, dbo.ImportItem.ImportToItemPrice, dbo.ImportItem.ImportToSellerNick, 
                      dbo.ImportItem.ImportToShopTitle, dbo.ImportItem.ImportState, dbo.ImportItem.ImportResult, dbo.ImportItem.ResultMessage, dbo.ImportItem.ListDateTime, 
                      dbo.ImportItem.StartDateTime, dbo.ImportItem.FinishDateTime, dbo.ImportItem.CreateDate, dbo.ImportItem.CreateUserId, dbo.ImportItem.LastUpdateDate, 
                      dbo.ImportItem.LastUpdateUserId, dbo.ImportItem.CurrentVersion, dbo.SystemUser.Id AS OperatorUserId_Last, 
                      dbo.SystemUser.LoginName AS OperatorLoginName_Last, dbo.SystemUser.UserName AS OperatorUserName_Last
FROM         dbo.ImportItem INNER JOIN
                      dbo.ImportGroup ON dbo.ImportItem.ItsImportGroupId = dbo.ImportGroup.Id LEFT OUTER JOIN
                      dbo.SystemUser ON dbo.ImportItem.OperatorUserId = dbo.SystemUser.Id

GO
