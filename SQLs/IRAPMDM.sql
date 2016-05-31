SELECT * FROM IRAP..sfn_AvailableCSMenus(60010, 1065, 734238, 9, 1)

DECLARE @ErrCode INT, @ErrText NVARCHAR(400),@ScenarioIndex INT, @RefreshGUIOptions BIT 
EXEC IRAP..ssp_RunAFunction 60010, 734238, -354036, @ScenarioIndex OUTPUT, @RefreshGUIOptions OUTPUT, @ErrCode OUTPUT, @ErrText OUTPUT
SELECT @ScenarioIndex, @RefreshGUIOptions, @ErrCode, @ErrText

SELECT EntityID FROM IRAP..stb053 WHERE PartitioningKey IN (3, 600100003) AND LeafID = 354036
SELECT * FROM IRAP..stb053 WHERE PartitioningKey IN (3, 600100003)


SELECT * FROM IRAP..sfn_AccessibleLeafSetEx(60010, 216, 1, 126193)

SELECT S.*, M.Leaf01 AS T116LeafID, X.NodeName AS T116LeafName 
  FROM IRAP..sfn_AccessibleLeafSetEx(60010, 216, 1, 126193) S
       INNER JOIN IRAPMDM..stb064 M ON S.LeafID = M.LeafID AND M.PartitioningKey = 600100216
       INNER JOIN IRAPMDM..stb058 X ON M.Leaf01 = X.LeafID AND X.TreeID = 116

SELECT * FROM IRAPMDM..ufn_GetList_ProcessOperations(60010, 126501)
SELECT * FROM IRAP..sfn_SubtreeLeaves(60010, 102, 22114)
SELECT * FROM IRAPMDM..ufn_GetInfo_ProductProcess(60010, 2256555, '', 126501)

SELECT * FROM IRAPMDM..ufn_GetList_MethodMMenu(60010, 12159, 126507)
SELECT * FROM IRAPMDM..ufn_GetList_MethodMMenu(60010, 0, 126507)

SELECT * FROM IRAPMDM..ufn_GetList_MethodMMenu(60006, 0, 0)

SELECT * FROM IRAP..sfn_RowSetAttributes(0, -64, 0, 30)
SELECT * FROM IRAPMDM..CorrRSAttr_MFGPrograms
EXEC IRAP..ssp_GetList_DBObjDependers 'IRAPMDM', 'CorrRSAttr_MFGPrograms'