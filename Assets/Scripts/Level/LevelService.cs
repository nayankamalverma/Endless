using Assets.Scripts.Level;
using System.Collections.Generic;
using UnityEngine;

public class LevelService
{
    private BuildingController buildingController;

    public LevelService(BuildingController buildingController, List<Transform> initialLeftBuildingSpawn, List<Transform> initialRightBuildingSpawn,Transform leftBuildingSpawnPos, Transform leftBuildingDestroyPos, Transform rightBuildingSpawnPos, Transform rightBuildingDestroyPos, GameObject buildingPrefab)
    {
        if (leftBuildingSpawnPos == null || leftBuildingDestroyPos == null || rightBuildingSpawnPos == null || rightBuildingDestroyPos == null || buildingPrefab == null || initialLeftBuildingSpawn == null || initialRightBuildingSpawn == null || buildingController == null)
        {
            Debug.LogError("Missing references in GameManager 2");
            return;
        }
        this.buildingController = buildingController;
        buildingController.SetReferences( buildingPrefab, initialLeftBuildingSpawn, initialRightBuildingSpawn, leftBuildingSpawnPos, leftBuildingDestroyPos, rightBuildingSpawnPos, rightBuildingDestroyPos);
    }

    private void OnGameStart()
    {
        buildingController.enabled = true;
    }
    
    private void OnGameEnd()
    {
        buildingController.enabled = false;
    }
}
