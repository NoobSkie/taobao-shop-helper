CREATE VIEW [dbo].[v_Area_All]
AS
SELECT     Id, AreaId, AreaType, AreaName, ParentId, Zip
FROM         dbo.Area
