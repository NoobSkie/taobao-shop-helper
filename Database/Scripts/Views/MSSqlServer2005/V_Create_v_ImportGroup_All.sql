CREATE VIEW [dbo].[v_ImportGroup_All]
AS
SELECT     dbo.ImportGroup.Id, dbo.ImportGroup.OperatorUserId, dbo.ImportGroup.OperatorUserName, dbo.ImportGroup.TotalCount, dbo.ImportGroup.SuccessCount, 
                      dbo.ImportGroup.FailCount, dbo.ImportGroup.ImportFormSellerNick, dbo.ImportGroup.ImportFormShopTitle, dbo.ImportGroup.ImportFormShopImageUrl, 
                      dbo.ImportGroup.ImportToSellerNick, dbo.ImportGroup.ImportToShopTitle, dbo.ImportGroup.ImportType, dbo.ImportGroup.ImportState, dbo.ImportGroup.ImportResult, 
                      dbo.ImportGroup.ListDateTime, dbo.ImportGroup.StartDateTime, dbo.ImportGroup.FinishDateTime, dbo.ImportGroup.CreateDate, dbo.ImportGroup.CreateUserId, 
                      dbo.ImportGroup.LastUpdateDate, dbo.ImportGroup.LastUpdateUserId, dbo.ImportGroup.CurrentVersion, dbo.SystemUser.Id AS OperatorUserId_Last, 
                      dbo.SystemUser.LoginName AS OperatorLoginName_Last, dbo.SystemUser.UserName AS OperatorUserName_Last
FROM         dbo.ImportGroup LEFT OUTER JOIN
                      dbo.SystemUser ON dbo.ImportGroup.OperatorUserId = dbo.SystemUser.Id

GO