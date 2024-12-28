namespace Assets.Scripts.Utilities
{
    public abstract class IState<T>
    {
        protected T controller;
        
        public virtual void Entry(){}
        public virtual void Update(){}
        public virtual void Exit(){}
    }
}