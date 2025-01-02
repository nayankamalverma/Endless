using System.Collections.Generic;
using Assets.Scripts.Events;
using Assets.Scripts.Level;
using Assets.Scripts.Player;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        #region References
        //LevelService
        [SerializeField] private Transform leftBuildingSpawnPos;
        [SerializeField] private Transform rightBuildingSpawnPos;
        [SerializeField] private Transform buildingDestroy;
        [SerializeField] private GameObject buildingPrefab;
        [SerializeField] private List<Transform> initialLeftBuildingSpawn;
        [SerializeField] private List<Transform> initialRightBuildingSpawn;
        [SerializeField] private BuildingController buildingController;

        //PlayerService
       // [SerializeField] private PlayerController playerController;

        #endregion
        #region Services
        //services
        private EventService EventService;
        private LevelService LevelService;
        //private PlayerService PlayerService;

        [SerializeField] private UIService UIService;
        #endregion

        private void Awake()
        {
            EventService = new EventService();
            LevelService = new LevelService(buildingController, initialLeftBuildingSpawn, initialRightBuildingSpawn,leftBuildingSpawnPos, rightBuildingSpawnPos, buildingDestroy, buildingPrefab);
            //PlayerService = new PlayerService(EventService, playerController);

            UIService.SetServices(EventService);
        }

        private void OnDestroy()
        {
            LevelService.OnDestroy();
           // PlayerService.OnDestroy();
        }

    }
}