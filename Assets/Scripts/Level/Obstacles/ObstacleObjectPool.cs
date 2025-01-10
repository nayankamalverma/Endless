using System.Collections.Generic;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Level
{
	public class ObstacleObjectPool : GenericObjectPool<ObstacleType>
	{
		private ObstaclesController obstaclesController;
		private List<ObstacleScriptableObject> obstaclesList;

		public ObstacleObjectPool(ObstaclesController obstaclesController, List<ObstacleScriptableObject> obstaclesList)
		{
			this.obstaclesController = obstaclesController;
			this.obstaclesList = obstaclesList;
		}
		protected override GameObject CreateItem(ObstacleType obstacleType)
		{
			return GameObject.Instantiate(GetPrefab(obstacleType), obstaclesController.gameObject.transform);
		}

        private GameObject GetPrefab(ObstacleType obstacleType)
        {
            return obstaclesList.Find(i => i.obstacleType == obstacleType).prefab;
        }

		
    }
}