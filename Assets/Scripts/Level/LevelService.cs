using Assets.Scripts.Level;
using System.Collections.Generic;
using UnityEngine;

public class LevelService
{
    private BuildingController buildingController;

    public LevelService(BuildingController buildingController,GameObject buildingPrefab, Transform buildingSpawnPos, Transform buildingDestroyPos)
    {
        this.buildingController = buildingController;
        buildingController.SetReferences( buildingPrefab, buildingSpawnPos, buildingDestroyPos);
    }

    private void OnGameStart()
    {
        buildingController.OnGameStart();
    }

    private void OnGamePause()
    {
        buildingController.SetIsPaused(true);
    }

    private void OnGameResume()
    {
        buildingController.SetIsPaused(false);
    }

    private void OnGameEnd()
    {
        buildingController.OnGameEnd();
    }

    public void OnDestroy()
    {
        
    }
}
