using System.Collections.Generic;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        //LevelService
        [SerializeField] private Transform leftBuildingSpawnPos;
        [SerializeField] private Transform rightBuildingSpawnPos;
        [SerializeField] private Transform buildingDestroy;
        [SerializeField] private GameObject buildingPrefab;
        [SerializeField] private List<Transform> initialLeftBuildingSpawn;
        [SerializeField] private List<Transform> initialRightBuildingSpawn;
        [SerializeField] private BuildingController buildingController;

        //services
        private LevelService LevelService;

        private void Start()
        {
            if(leftBuildingSpawnPos == null || rightBuildingSpawnPos == null || buildingDestroy == null || buildingPrefab == null || initialLeftBuildingSpawn == null || initialRightBuildingSpawn == null || buildingController == null)
            {
                Debug.LogError("Missing references in GameManager");
                return;
            }
            LevelService = new LevelService(buildingController, initialLeftBuildingSpawn, initialRightBuildingSpawn,leftBuildingSpawnPos, rightBuildingSpawnPos, buildingDestroy, buildingPrefab);
        }

    }
}