CREATE VIEW [dbo].[v_ItemCategory_All]
AS
SELECT     Id, CategoryId, ParentId, Name, IsParent, Status, SortOrder
FROM         dbo.ItemCategory