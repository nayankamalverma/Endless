
using Assets.Scripts.Events;
using Unity.VisualScripting;

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
        }

        private void OnGameStart()
        {

        }

        private void OnGamePause()
        {

        }

        private void OnGameResume()
        {

        }

        private void OnGameEnd()
        {

        }

        public void OnDestroy()
        {

        }
    }
}
