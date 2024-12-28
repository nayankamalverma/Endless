using Assets.Scripts.Level;
using System.Collections.Generic;
using UnityEngine;

public class LevelService
{
    private BuildingController buildingController;

    public LevelService(BuildingController buildingController, List<Transform> initialLeftBuildingSpawn, List<Transform> initialRightBuildingSpawn,Transform leftBuildingSpawnPos, Transform rightBuildingSpawnPos, Transform buildingDestroyPos, GameObject buildingPrefab)
    {
        if (leftBuildingSpawnPos == null || rightBuildingSpawnPos == null || buildingDestroyPos == null || buildingPrefab == null || initialLeftBuildingSpawn == null || initialRightBuildingSpawn == null || buildingController == null)
        {
            Debug.LogError("Missing references in GameManager 2");
            return;
        }
        this.buildingController = buildingController;
        buildingController.SetReferences( buildingPrefab, initialLeftBuildingSpawn, initialRightBuildingSpawn, leftBuildingSpawnPos, rightBuildingSpawnPos, buildingDestroyPos);

    }

    private void OnGameStart()
    {
        buildingController.gameObject.SetActive(true);
    }
    
    private void OnGameEnd()
    {
        buildingController.gameObject.SetActive(false);
    }
}
