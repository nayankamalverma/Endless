using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Level
{
	public class BuildingObjectPool : ObjectPool
	{
        private GameObject buildingPrefab;
        private BuildingController buildingController;

        public BuildingObjectPool(GameObject buildingPrefab, BuildingController buildingController)
        {
            this.buildingPrefab = buildingPrefab;
            this.buildingController = buildingController;
        }

        public GameObject GetBuilding() => GetItem();


        protected override GameObject CreateItem()
        {
            return GameObject.Instantiate(buildingPrefab);
        }
    }
}