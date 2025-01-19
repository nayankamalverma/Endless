using System;
using System.Collections.Generic;
using Assets.Scripts.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Level
{
    public class ObstaclesController : MonoBehaviour
    {
        [SerializeField] List<ObstacleScriptableObject> obstaclesList;
        [SerializeField] private Transform obstacleSpawnPos;
        [SerializeField] private Transform destroyPos;
        [SerializeField] private float spawnRate = 3f;

        private float spawnTime;
        private bool isPaused;
        private ObstacleObjectPool obstaclePool;
        private LevelService levelService;

        public void SetReferences(LevelService levelService) { this.levelService = levelService; }

        private void Start()
        {
            obstaclePool = new ObstacleObjectPool(this,obstaclesList);
            isPaused = true;
            spawnTime = 0;
        }
        
        private void Update()
        {
            if (!isPaused)
            {
                SpawnObstacles();
                MoveObstacles();
            }
        }

        public void OnGameStart()
        {
            obstaclePool.ReturnAllItem();
            isPaused = false;
        }

        public void OnMainMenuButtonClicked()
        {
            obstaclePool.ReturnAllItem();   
            isPaused = true;
        }

        private void SpawnObstacles()
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                ConfigureObstacle();
                spawnTime = spawnRate;
            }
        }

        private void ConfigureObstacle()
        {
            GameObject obs = obstaclePool.GetItem(GetRandomObstacle());
            obs.transform.position = obstacleSpawnPos.position;
            obs.transform.rotation = obstacleSpawnPos.rotation;
        }

        private void MoveObstacles()
        {
            foreach (var pooledItem in obstaclePool.pooledItems)
            {
                var obj = pooledItem.Item;
                if (pooledItem.isUsed)
                {
                    Vector3 targetPosition = obj.transform.position + (Vector3.left * levelService.GetMoveSpeed() * Time.deltaTime);

                    obj.transform.position = Vector3.Lerp(obj.transform.position, targetPosition, 0.5f);

                    if (obj.transform.position.x <= destroyPos.position.x)
                    {
                        obstaclePool.ReturnItem(pooledItem);
                    }
                }
            }
        }

        private ObstacleType GetRandomObstacle()
        {
            return obstaclesList[Random.Range(0, obstaclesList.Count)].obstacleType;
        }

        public void SetIsPaused(bool isPaused)
        {
            this.isPaused = isPaused;
        }
    }
}