using Assets.Scripts.Events;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Collectibles
{
    public class CoinService : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI coinText;

        private int totalCoins = 0;
        private int coins=0;

        private bool playing;

        EventService eventService; 

        public void SetService(EventService eventService)
        {
            this.eventService = eventService;
            AddEventListeners();
        }

        private void AddEventListeners()
        {
            eventService.OnGameStart.AddListener(OnGameStart);
            eventService.OnGameEnd.AddListener(OnGameEnd);
            eventService.InitGame.AddListener(InitGame);
            eventService.OnCoinCollected.AddListener(OnCoinCollected);
        }

        private void OnGameStart()
        {
            coins = 0;
            playing = true;
        }

        private void OnCoinCollected()
        {

            coins += 10;
        }

        private void Update()
        {
            if (playing)
            {
                coinText.text = "Coins : " + coins;
            }
            else
            {
                coinText.text = "Coins : " + totalCoins;
            }
        }

        private void InitGame(int score, int coin)
        {
            totalCoins = coin;
        }

        private void OnGameEnd() {
            totalCoins += coins;
            eventService.UpdateCoin.Invoke(totalCoins);
        }

        private void OnDestroy()
        {
            eventService.OnGameStart.RemoveListener(OnGameStart);
            eventService.OnGameEnd.RemoveListener(OnGameEnd);
            eventService.InitGame.RemoveListener(InitGame);
            eventService.OnCoinCollected.RemoveListener(OnCoinCollected);

        }
    }
}