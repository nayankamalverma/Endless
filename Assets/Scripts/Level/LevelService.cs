using Assets.Scripts.Events;
using Assets.Scripts.Level;
using UnityEngine;

public class LevelService
{
    private BuildingController buildingController;
    private ObstaclesController obstaclesController;
    private EventService eventService;

    public LevelService( EventService eventService,BuildingController buildingController , Transform buildingSpawnPos, Transform buildingDestroyPos, ObstaclesController obstaclesController)
    {
        this.eventService = eventService;
        this.buildingController = buildingController;
        this.obstaclesController = obstaclesController;
        buildingController.SetReferences(  buildingSpawnPos, buildingDestroyPos);
        AddEventListeners();
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

    public void OnDestroy()
    {
        eventService.OnGameStart.RemoveListener(OnGameStart);
        eventService.OnGameResume.RemoveListener(OnGameResume);
        eventService.OnGamePause.RemoveListener(OnGamePause);
        eventService.OnMainMenuButtonClicked.RemoveListener(OnMainMenuButtonClicked);
        eventService.OnGameEnd.RemoveListener(OnGameEnd);
    }
}
