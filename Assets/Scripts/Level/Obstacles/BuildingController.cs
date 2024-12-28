using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class BuildingController : MonoBehaviour
    {
        private GameObject buildingPrefab;
        private Transform leftBuildingSpawnPos;
        private Transform leftBuildingDestroyPos;
        private Transform rightBuildingSpawnPos;
        private Transform rightBuildingDestroyPos;
        private List<Transform> initialLeftBuildingSpawn;
        private List<Transform> initialRightBuildingSpawn;

        BuildingObjectPool buildingObjectPool;

        public void SetReferences(GameObject buildingPrefab, List<Transform> initialLeftBuildingSpawn, List<Transform> initialRightBuildingSpawn, Transform leftBuildingSpawnPos, Transform leftBuildingDestroyPos, Transform rightBuildingSpawnPos, Transform rightBuildingDestroyPos)
        {
            if (leftBuildingSpawnPos == null || leftBuildingDestroyPos == null || rightBuildingSpawnPos == null || rightBuildingDestroyPos == null || buildingPrefab == null || initialLeftBuildingSpawn == null || initialRightBuildingSpawn == null )
            {
                Debug.LogError("Missing references in GameManager 3");
                return;
            }
            this.initialLeftBuildingSpawn = initialLeftBuildingSpawn;
            this.initialRightBuildingSpawn = initialRightBuildingSpawn;
            this.leftBuildingSpawnPos = leftBuildingSpawnPos;
            this.leftBuildingDestroyPos = leftBuildingDestroyPos;
            this.rightBuildingSpawnPos = rightBuildingSpawnPos;
            this.rightBuildingDestroyPos = rightBuildingDestroyPos;
            this.buildingPrefab = buildingPrefab;
        }

        private void Start()
        {
            buildingObjectPool = new BuildingObjectPool(buildingPrefab, this);
        }

        private void OnEnable()
        { 
            SpawnInitialBuilding();
        }


        private void Update()
        {
            
        }


        private void SpawnInitialBuilding()
        {
            for (int i = 0; i < initialLeftBuildingSpawn.Count; i++)
            {
                ConfigureBuilding(buildingObjectPool.GetBuilding(), initialLeftBuildingSpawn[i] );
                ConfigureBuilding(buildingObjectPool.GetBuilding(), initialRightBuildingSpawn[i] );
            }
        }

        private void ConfigureBuilding(GameObject item,Transform spawnPos)
        {
            item.transform.position = spawnPos.position;
            item.transform.rotation = spawnPos.rotation;
        }

        private void OnDisable()
        {
            foreach (var i in buildingObjectPool.pooledItems)
            {
                buildingObjectPool.ReturnItem(i);
            }
        }
    }
}