using Assets.Scripts.Events;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.UI
{
    public class MainMenuUIController : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        private EventService eventService;

        private void Awake()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        public void SetService(EventService eventService)
        {
            this.eventService = eventService;
        }

        private void OnPlayButtonClicked()
        {
            eventService.OnGameStart.Invoke();
        }
    }
}