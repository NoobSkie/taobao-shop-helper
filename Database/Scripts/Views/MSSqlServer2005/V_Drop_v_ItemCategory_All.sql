IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[v_ItemCategory_All]'))
DROP VIEW [dbo].[v_ItemCategory_All]