namespace Healthcare020.Mobile.Interfaces
{
    public interface ILocator
    {
        T GetInstance<T>() where T : class;
        void Register<T>() where T : class;
    }
}