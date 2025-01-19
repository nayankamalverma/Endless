using Assets.Scripts.Collectibles;
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
        [SerializeField] private BuildingController buildingController;
        [SerializeField] private int initialBUildingCount = 8;
        [SerializeField] private float initMoveSpeed = 4f;
        [SerializeField] private float speedIncreaseRate = 0.05f;

        [SerializeField] private ObstaclesController obstaclesController;

        //PlayerService
        [SerializeField] private PlayerController playerController;

        #endregion
        #region Services
        //services
        private EventService EventService;
        private LevelService LevelService;
        private PlayerService PlayerService;

        [SerializeField] private UIService UIService;
        [SerializeField] private ScoreService ScoreService;
        [SerializeField] private CoinService CoinService;
        #endregion

        private void Awake()
        {
            EventService = new EventService();
            LevelService = new LevelService( EventService, initMoveSpeed, speedIncreaseRate, buildingController,  obstaclesController);
            PlayerService = new PlayerService(EventService, playerController);

            UIService.SetServices(EventService);
            ScoreService.SetService(EventService);
            CoinService.SetService(EventService);
        }

        private void Update()
        {
            LevelService.Update();
        }

        private void OnDestroy()
        {
            LevelService.OnDestroy();
            PlayerService.OnDestroy();
        }

    }
}