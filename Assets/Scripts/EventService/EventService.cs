namespace Assets.Scripts.Events
{
	public class EventService
	{
		public EventController<int, int> InitGame;
		public EventController OnGameStart;
		public EventController OnGamePause;
		public EventController OnGameResume;
		public EventController OnGameEnd;
		public EventController OnMainMenuButtonClicked;
		public EventController OnCoinCollected;
		public EventController<int> UpdateScore;
		public EventController<int> UpdateCoin;

		public EventService()
		{
			InitGame = new EventController<int, int>();
			OnGameStart = new EventController();
			OnGamePause = new EventController();
			OnGameResume = new EventController();
			OnGameEnd = new EventController();
			OnMainMenuButtonClicked = new EventController();
			OnCoinCollected = new EventController();
			UpdateCoin = new EventController<int>();
			UpdateScore = new EventController<int>();
		}
	}
}