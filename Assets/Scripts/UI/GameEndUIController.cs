using Assets.Scripts.Collectibles;
using Assets.Scripts.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUIController : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinCollectedText;

    EventService eventService;

    private void Awake()
    {
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        MainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
    }

    public void SetService(EventService eventService)
    {
        this.eventService = eventService;
        AddEventListeners();
    }

    private void AddEventListeners()
    {
        eventService.UpdateCoin.AddListener(UpdateCoins);
        eventService.UpdateScore.AddListener(UpdateScore);
    }

    private void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;
    }
    private void UpdateCoins(int coins)
    {
        coinCollectedText.text = "Coins Collected : " + coins;
    }

    private void OnRestartButtonClicked()
    {
        eventService.OnGameStart.Invoke();
    }

    private void OnMainMenuButtonClicked()
    {
        eventService.OnMainMenuButtonClicked.Invoke();
    }
    private void OnDestroy()
    {
        eventService.UpdateCoin.RemoveListener(UpdateCoins);
        eventService.UpdateScore.RemoveListener(UpdateScore);
    }
}
