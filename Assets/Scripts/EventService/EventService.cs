namespace Assets.Scripts.Events
{
    public class EventService
    {
        public EventController OnGameStart;
        public EventController OnGamePause;
        public EventController OnGameResume;
        public EventController OnGameEnd;

        public EventService()
        {
            EventController OnGameStart = new EventController();
            EventController OnGamePause = new EventController();
            EventController OnGameResume = new EventController();
            EventController OnGameEnd = new EventController();
        }
    }
}