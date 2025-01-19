using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.UI{
	public class UIService : MonoBehaviour
	{
		[SerializeField] private MainMenuUIController mainMenuUIController;
		[SerializeField] private PauseMenuUIController pauseMenuUIController;
		[SerializeField] private GameEndUIController gameEndUIController;

		private EventService eventService;

		public void SetServices(EventService eventService)
		{
			this.eventService = eventService;
			mainMenuUIController.SetService(eventService);
			pauseMenuUIController.SetService(eventService);
			gameEndUIController.SetService(eventService);
			AddEventListeners();
		}
		private void AddEventListeners()
		{
			eventService.OnGameStart.AddListener(OnGameStart);
			eventService.OnGameResume.AddListener(OnGameResume);
			eventService.OnGameEnd.AddListener(OnGameEnd);
			eventService.OnMainMenuButtonClicked.AddListener(OnMainMenuButtonClicked);
		}

		private void Update()
		{
			if(Input.GetKey(KeyCode.Escape))
			{
				eventService.OnGamePause.Invoke();
				pauseMenuUIController.gameObject.SetActive(true);
			}
		}

		private void OnGameStart()
		{
			gameEndUIController.gameObject.SetActive(false);
			mainMenuUIController.gameObject.SetActive(false);
		}

		private void OnGameResume()
		{
			pauseMenuUIController.gameObject.SetActive(false);
		}

		private void OnGameEnd()
		{
			pauseMenuUIController.gameObject.SetActive(false);
			gameEndUIController.gameObject.SetActive(true);
		}

		private void OnMainMenuButtonClicked()
		{
			gameEndUIController.gameObject.SetActive(false);
			mainMenuUIController.gameObject.SetActive(true);
		}

		private void OnDestroy()
		{
            eventService.OnGameStart.RemoveListener(OnGameStart);
            eventService.OnGameResume.RemoveListener(OnGameResume);
            eventService.OnGameEnd.RemoveListener(OnGameEnd);
            eventService.OnMainMenuButtonClicked.RemoveListener(OnMainMenuButtonClicked);
        }
	}
}
