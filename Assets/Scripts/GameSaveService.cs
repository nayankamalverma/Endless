using Assets.Scripts.Events;
using Assets.Scripts.UI;
using UnityEngine;

public class GameSaveService 
{
    string highScore = "HighScore";
    string coin = "Coin";

    private EventService eventService;

    private void Awake()
    {
        
    }

    public void SetService(EventService eventService)
    {
        this.eventService = eventService;
        AddEventListeners();
        eventService.InitGame.Invoke(GetHighScore(),GetCoins());
    }

    private int GetCoins()
    {
        return PlayerPrefs.HasKey(coin) ? PlayerPrefs.GetInt(coin) : 0;
    }

    private int GetHighScore()
    {
        return PlayerPrefs.HasKey(highScore) ? PlayerPrefs.GetInt(highScore) : 0;
    }

    private void AddEventListeners()
    {
        eventService.UpdateScore.AddListener(UpdateScore);
        eventService.UpdateCoin.AddListener(UpdateCoin);
    }

    private void UpdateScore(int score)
    {
        if(score>PlayerPrefs.GetInt(highScore))
        PlayerPrefs.SetInt(highScore, score);
        Save();
    }
    private void UpdateCoin(int coins)
    {
        PlayerPrefs.SetInt(coin, coins);
        Save();
    }

    private void Save()
    {
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        eventService.UpdateScore.RemoveListener(UpdateScore);
        eventService.UpdateCoin.RemoveListener(UpdateCoin);
    }


}
