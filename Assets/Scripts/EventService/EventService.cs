namespace Assets.Scripts.Events
{
	public class EventService
	{
		public EventController OnGameStart;
		public EventController OnGamePause;
		public EventController OnGameResume;
		public EventController OnGameEnd;
		public EventController OnMainMenuButtonClicked;

		public EventService()
		{
			OnGameStart = new EventController();
			OnGamePause = new EventController();
			OnGameResume = new EventController();
			OnGameEnd = new EventController();
			OnMainMenuButtonClicked = new EventController();
		}
	}
}