using Assets.Scripts.Events;
using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.UI{
    public class UIService : MonoBehaviour
    {
       // [SerializeField] 

        private EventService eventService;

        public void SetServices(EventService eventService)
        {
            this.eventService = eventService;
        }

        private void Start()
        {
            AddEventListeners();
        }

        private void AddEventListeners()
        {
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
    }
}
