using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class BuildingController : MonoBehaviour
    {

        [SerializeField]private List<BuildingScriptableObjects> buildingsList;
        [SerializeField] private int initialBuildingCount=8;
        [SerializeField] private Transform buildingSpawnPos;
        [SerializeField] private Transform buildingDestroyPos;

        BuildingObjectPool buildingObjectPool;
        private LevelService levelService;
        private bool isPaused;

        public void SetReferences(LevelService levelService)
        {
            this.levelService = levelService;
        }

        private void Start()
        {
            buildingObjectPool = new BuildingObjectPool( this, buildingsList);
            SpawnInitialBuilding();
            isPaused = true;
        }

        public void OnGameStart()
        {
            buildingObjectPool.ReturnAllItem();
            SpawnInitialBuilding();
            isPaused = false;
        }

        private void Update()
        {
            if (!isPaused) {
                MoveBuildings();
            }
        }

        private void MoveBuildings()
        {
            foreach (var pooledItem in buildingObjectPool.pooledItems)
            {
                var building = pooledItem.Item;
                if (pooledItem.isUsed)
                {
                    Vector3 targetPosition = building.transform.position + (Vector3.left * levelService.GetMoveSpeed() * Time.deltaTime);

                    building.transform.position = Vector3.Lerp(building.transform.position, targetPosition, 0.5f);

                    if (building.transform.position.x <= buildingDestroyPos.position.x )
                    {
                        buildingObjectPool.ReturnItem(pooledItem);
                        ConfigureBuilding(buildingObjectPool.GetItem(GetRandomBuilding()), buildingSpawnPos);
                    }
                }
            }
        }
        private BuildingType GetRandomBuilding()
        {
            return buildingsList[Random.Range(0, buildingsList.Count)].buildingType;
        }

        private void SpawnInitialBuilding()
        {
            buildingSpawnPos.position = Vector3.zero;
            for (int i = 0; i < initialBuildingCount ; i++)
            {
                if(i!=0)buildingSpawnPos.position = new Vector3(buildingSpawnPos.position.x+10, buildingSpawnPos.position.y,buildingSpawnPos.position.z );
                ConfigureBuilding(buildingObjectPool.GetItem(GetRandomBuilding()), buildingSpawnPos);
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

        public void OnMainMenuButtonClicked()
        {
            isPaused = true;
            buildingObjectPool.ReturnAllItem();
            SpawnInitialBuilding();
        }
    }
}