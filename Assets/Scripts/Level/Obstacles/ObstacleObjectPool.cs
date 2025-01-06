using System.Collections.Generic;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Level
{
	public class ObstacleObjectPool  : ObjectPool
	{
		public List<PooledObstacle> pooledItems = new List<PooledObstacle>();
		private ObstaclesController obstaclesController;
		private List<ObstacleScriptableObject> obstaclesList;

		public ObstacleObjectPool(ObstaclesController obstaclesController, List<ObstacleScriptableObject> obstaclesList)
		{
			this.obstaclesController = obstaclesController;
			this.obstaclesList = obstaclesList;
		}

		public GameObject GetItem(ObstacleType obstacleType)
		{
			if (pooledItems.Count > 0)
			{
				PooledObstacle item = pooledItems.Find(i => !i.isUsed && i.obstacleType == obstacleType);
				if (item != null)
				{
					item.isUsed = true;
					return item.item;
				}
			}
			return CreateNewPooledItem(obstacleType);
		}

		private GameObject CreateNewPooledItem(ObstacleType obstacleType)
		{
			PooledObstacle item = new PooledObstacle();
			item.item = CreateItem(obstacleType);
			item.obstacleType = obstacleType;
			item.isUsed = true;
			pooledItems.Add(item);
			return item.item;
		}

		private GameObject CreateItem(ObstacleType obstacleType)
		{
			return GameObject.Instantiate(GetPrefab(obstacleType), obstaclesController.gameObject.transform);
		}

        private GameObject GetPrefab(ObstacleType obstacleType)
        {
            return obstaclesList.Find(i => i.obstacleType == obstacleType).prefab;
        }
    }

	public class PooledObstacle : PooledItem
	{
		public ObstacleType obstacleType;
	}
}