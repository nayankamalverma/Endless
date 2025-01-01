using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class BuildingController : MonoBehaviour
    {
        private GameObject buildingPrefab;
        private Transform leftBuildingSpawnPos;
        private Transform rightBuildingSpawnPos;
        private Transform buildingDestroyPos;
        private List<Transform> initialLeftBuildingSpawn;
        private List<Transform> initialRightBuildingSpawn;
        [SerializeField] private float initMoveSpeed = 0.2f;
        [SerializeField] private float speedIncreaseRate = 0.01f;
        [SerializeField] private bool isPaused;

        private float moveSpeed;
        BuildingObjectPool buildingObjectPool;

        public void SetReferences(GameObject buildingPrefab, List<Transform> initialLeftBuildingSpawn, List<Transform> initialRightBuildingSpawn, Transform leftBuildingSpawnPos, Transform rightBuildingSpawnPos, Transform buildingDestroyPos)
        {
            if (leftBuildingSpawnPos == null || rightBuildingSpawnPos == null || buildingDestroyPos == null || buildingPrefab == null || initialLeftBuildingSpawn == null || initialRightBuildingSpawn == null )
            {
                Debug.LogError("Missing references in GameManager 3");
                return;
            }
            this.initialLeftBuildingSpawn = initialLeftBuildingSpawn;
            this.initialRightBuildingSpawn = initialRightBuildingSpawn;
            this.leftBuildingSpawnPos = leftBuildingSpawnPos;
            this.rightBuildingSpawnPos = rightBuildingSpawnPos;
            this.buildingDestroyPos = buildingDestroyPos;
            this.buildingPrefab = buildingPrefab;
        }

        private void Start()
        {
            buildingObjectPool = new BuildingObjectPool(buildingPrefab, this);
        }

        public void OnGameStart()
        {
            isPaused = false;
            moveSpeed = initMoveSpeed;
            SpawnInitialBuilding();
        }


        private void Update()
        {

            if (!isPaused) {
                MoveBuildings();
                IncreaseSpeedOverTime();
            }
        }

        private void MoveBuildings()
        {
            foreach (var pooledItem in buildingObjectPool.pooledItems)
            {
                var building = pooledItem.item;
                if (building.activeSelf)
                {
                    Vector3 targetPosition = building.transform.position + (Vector3.left * moveSpeed * Time.deltaTime);

                    building.transform.position = Vector3.Lerp(building.transform.position, targetPosition, 0.5f);

                    if (building.transform.position.x <= buildingDestroyPos.position.x )
                    {
                        buildingObjectPool.ReturnItem(pooledItem);
                        if( building.transform.position.z == leftBuildingSpawnPos.position.z) ConfigureBuilding(buildingObjectPool.GetBuilding(), leftBuildingSpawnPos);
                        else ConfigureBuilding(buildingObjectPool.GetBuilding(), rightBuildingSpawnPos);
                    }
                }
            }
        }

        private void IncreaseSpeedOverTime()
        {
            moveSpeed += speedIncreaseRate * Time.deltaTime;
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

        public void SetIsPaused(bool isPaused)
        {
            this.isPaused = isPaused;
        }

        public void OnGameEnd()
        {
            foreach (var i in buildingObjectPool.pooledItems)
            {
                buildingObjectPool.ReturnItem(i);
            }
        }
    }
}