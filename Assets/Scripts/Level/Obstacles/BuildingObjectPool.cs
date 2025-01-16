using Assets.Scripts.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Level
{
	public class BuildingObjectPool : GenericObjectPool<BuildingType>
	{
		private BuildingController buildingController;
		private List<BuildingScriptableObjects> buildingsList;

		public BuildingObjectPool( BuildingController buildingController, List<BuildingScriptableObjects> buildingsList)
		{
			this.buildingController = buildingController;
			this.buildingsList = buildingsList;
		}

        protected override GameObject CreateItem(BuildingType buildingType)
        {
            return GameObject.Instantiate(GetPrefab(buildingType), buildingController.gameObject.transform);
        }


        private GameObject GetPrefab(BuildingType buildingType)
        {
            return buildingsList.Find(i => i.buildingType == buildingType).prefab;
        }
    }
}