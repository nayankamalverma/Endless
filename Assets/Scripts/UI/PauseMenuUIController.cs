using Assets.Scripts.Events;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PauseMenuUIController : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button EndGameButton;

        private EventService eventService;

        private void Awake()
        {
            resumeButton.onClick.AddListener(OnResumeButtonClicked);
            EndGameButton.onClick.AddListener(OnEndGameButtonClicked);
        }

        private void OnEndGameButtonClicked()
        {
            eventService.OnGameEnd.Invoke();
        }

        private void OnResumeButtonClicked()
        {
            eventService.OnGameResume.Invoke();
        }

        public void SetService(EventService eventService)
        {
            this.eventService = eventService;
        }
        private void OnDestroy()
        {
            resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
            EndGameButton.onClick.RemoveListener(OnEndGameButtonClicked);
        }
    }
}