namespace eventeaseapp.Services
{
    public class UserSessionService
    {
        public string UserName { get; private set; }
        public bool IsLoggedIn { get; private set; }

        public event Action OnChange;

        public void Login(string userName)
        {
            UserName = userName;
            IsLoggedIn = true;
            NotifyStateChanged();
        }

        public void Logout()
        {
            UserName = string.Empty;
            IsLoggedIn = false;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}