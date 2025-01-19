using Assets.Scripts.Events;
using Assets.Scripts.Level;
using UnityEngine;

public class LevelService
{
    private BuildingController buildingController;
    private ObstaclesController obstaclesController;
    private EventService eventService;

    private float initMoveSpeed;
    private float speedIncreaseRate;
    private float moveSpeed;
    
    public LevelService( EventService eventService,float initMoveSpeed, float speedIncreaseRate, BuildingController buildingController ,ObstaclesController obstaclesController)
    {
        this.eventService = eventService;
        this.initMoveSpeed = initMoveSpeed;
        this.speedIncreaseRate = speedIncreaseRate;
        this.buildingController = buildingController;
        this.obstaclesController = obstaclesController;
        buildingController.SetReferences(this);
        obstaclesController.SetReferences(this);
        AddEventListeners();
        moveSpeed = initMoveSpeed;
    }

    public void Update()
    {
        IncreaseSpeedOverTime();
    }

    private void AddEventListeners()
    {
        eventService.OnGameStart.AddListener(OnGameStart);
        eventService.OnGamePause.AddListener(OnGamePause);
        eventService.OnGameResume.AddListener(OnGameResume);
        eventService.OnMainMenuButtonClicked.AddListener(OnMainMenuButtonClicked);
        eventService.OnGameEnd.AddListener(OnGameEnd);
    }


    private void OnGameStart()
    {
        buildingController.OnGameStart();
        obstaclesController.OnGameStart();
        moveSpeed = initMoveSpeed;
    }

    private void OnGamePause()
    {
        buildingController.SetIsPaused(true);
        obstaclesController.SetIsPaused(true);
    }

    private void OnGameResume()
    {
        buildingController.SetIsPaused(false);
        obstaclesController.SetIsPaused(false);
    }
    private void OnGameEnd()
    {
        buildingController.SetIsPaused(true);
        obstaclesController.SetIsPaused(true);
    }

    private void OnMainMenuButtonClicked()
    {
        buildingController.OnMainMenuButtonClicked();
        obstaclesController.OnMainMenuButtonClicked();
    }


    private void IncreaseSpeedOverTime()
    {
        if (moveSpeed < 30) moveSpeed += speedIncreaseRate * Time.deltaTime;
    }

    public float GetMoveSpeed() => moveSpeed; 

    public void OnDestroy()
    {
        eventService.OnGameStart.RemoveListener(OnGameStart);
        eventService.OnGameResume.RemoveListener(OnGameResume);
        eventService.OnGamePause.RemoveListener(OnGamePause);
        eventService.OnMainMenuButtonClicked.RemoveListener(OnMainMenuButtonClicked);
        eventService.OnGameEnd.RemoveListener(OnGameEnd);
    }
}
