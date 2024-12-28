using System.Collections.Generic;
using Assets.Scripts.Level;
using Assets.Scripts.Obstacles;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        //LevelService
        [SerializeField] private Transform leftBuildingSpawnPos;
        [SerializeField] private Transform leftBuildingDestroyPos;
        [SerializeField] private Transform rightBuildingSpawnPos;
        [SerializeField] private Transform rightBuildingDestroyPos;
        [SerializeField] private GameObject buildingPrefab;
        [SerializeField] private List<Transform> initialLeftBuildingSpawn;
        [SerializeField] private List<Transform> initialRightBuildingSpawn;
        [SerializeField] private BuildingController buildingController;

        //services
        private LevelService LevelService;

        private void Start()
        {
            if(leftBuildingSpawnPos == null || leftBuildingDestroyPos == null || rightBuildingSpawnPos == null || rightBuildingDestroyPos == null || buildingPrefab == null || initialLeftBuildingSpawn == null || initialRightBuildingSpawn == null || buildingController == null)
            {
                Debug.LogError("Missing references in GameManager");
                return;
            }
            LevelService = new LevelService(buildingController, initialLeftBuildingSpawn, initialRightBuildingSpawn,leftBuildingSpawnPos, leftBuildingDestroyPos, rightBuildingSpawnPos, rightBuildingDestroyPos, buildingPrefab);
        }

    }
}