namespace Healthcare020.Mobile.Interfaces
{
    public interface IHud
    {
        void Show();

        void Show(string message);

        void Dismiss();

        void Success(string message = "");

        void Error(string message);

        void Progress();

        void Toast(string message);
    }
}