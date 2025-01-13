using Assets.Scripts.Events;
using TMPro;
using UnityEngine;

public class ScoreService : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI scoreText;
    private float score;
    private int highScore;
    private bool IsPaused = false;
    private bool Playing = false;
    private EventService eventService;


    public void SetService(EventService eventService)
    {
        this.eventService = eventService;
        AddEventListeners();
    }

    private void AddEventListeners()
    {
        eventService.OnGameStart.AddListener(OnGameStart);
        eventService.OnGamePause.AddListener(OnGamePause);
        eventService.OnGameResume.AddListener(OnGameResume);
        eventService.OnGameEnd.AddListener(OnGameEnd);
    }

    private void OnGameStart()
    {
        score = 0;
        IsPaused = false;
        Playing =true;
    }

    private void OnGamePause()
    {
        IsPaused = true;
    }

    private void OnGameResume()
    {
        IsPaused = false;
    }

    private void OnGameEnd()
    {
        IsPaused = true;
        Playing=false;
        if (score > highScore) highScore = (int)score;
        eventService.UpdateScore.Invoke((int)score); 
    }

    private void Update()
    {
        if (!IsPaused)
        {
            IncreaseScore();
        }
        if(Playing)
            scoreText.text = "Score : " + (int)score;
        else scoreText.text = "HighScore : "+highScore;
    }

    private void IncreaseScore()
    {
        score += Time.deltaTime;
    }

    private void OnDestroy()
    {
        eventService.OnGameStart.RemoveListener(OnGameStart);
        eventService.OnGamePause.RemoveListener(OnGamePause);
        eventService.OnGameResume.RemoveListener(OnGameResume);
        eventService.OnGameEnd.RemoveListener(OnGameEnd);
    }
}
