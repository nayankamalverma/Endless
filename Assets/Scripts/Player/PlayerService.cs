
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private EventService eventService;

        public PlayerService(EventService eventService, PlayerController playerController) 
        {
            this.eventService = eventService;
            this.playerController = playerController;
            playerController.SetService(eventService);
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
            playerController.OnGameStart();
        }

        private void OnGamePause()
        {
            playerController.OnGamePause();
        }

        private void OnGameResume()
        {
            playerController.OnGameResume();
        }

        private void OnMainMenuButtonClicked()
        {
            playerController.ResetPlayer();
        }

        public void OnDestroy()
        {
            eventService.OnGameStart.RemoveListener(OnGameStart);
            eventService.OnGamePause.RemoveListener(OnGamePause);
            eventService.OnGameResume.RemoveListener(OnGameResume);
            eventService.OnMainMenuButtonClicked?.RemoveListener(OnMainMenuButtonClicked);
        }
    }
}
