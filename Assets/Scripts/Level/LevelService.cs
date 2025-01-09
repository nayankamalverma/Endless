using Assets.Scripts.Events;
using Assets.Scripts.Level;
using UnityEngine;

public class LevelService
{
    private BuildingController buildingController;
    private ObstaclesController obstaclesController;
    private EventService eventService;

    public LevelService( EventService eventService,BuildingController buildingController ,GameObject buildingPrefab, Transform buildingSpawnPos, Transform buildingDestroyPos, ObstaclesController obstaclesController)
    {
        this.eventService = eventService;
        this.buildingController = buildingController;
        this.obstaclesController = obstaclesController;
        buildingController.SetReferences( buildingPrefab, buildingSpawnPos, buildingDestroyPos);
        AddEventListeners();
    }

    private void AddEventListeners()
    {
        eventService.OnGameStart.AddListener(OnGameStart);
        eventService.OnGamePause.AddListener(OnGamePause);
        eventService.OnGameResume.AddListener(OnGameResume);
        eventService.OnMainMenuButtonClicked.AddListener(OnMainMenuButtonClicked);
    }

    private void OnGameStart()
    {
        buildingController.OnGameStart();
    }

    private void OnGamePause()
    {
        buildingController.SetIsPaused(true);
    }

    private void OnGameResume()
    {
        buildingController.SetIsPaused(false);
    }

    private void OnMainMenuButtonClicked()
    {
        buildingController.OnMainMenuButtonClicked();
    }

    public void OnDestroy()
    {
        eventService.OnGameStart.RemoveListener(OnGameStart);
    }
}
