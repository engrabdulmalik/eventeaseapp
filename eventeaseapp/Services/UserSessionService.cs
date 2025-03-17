namespace eventeaseapp.Services
{
    public class UserSessionService
    {
        public string UserName { get; private set; }
        public bool IsLoggedIn { get; private set; }
        public List<string> AttendedEvents { get; private set; } = new List<string>();

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
            AttendedEvents.Clear();
            NotifyStateChanged();
        }

        public void AttendEvent(string eventName)
        {
            if (!AttendedEvents.Contains(eventName))
            {
                AttendedEvents.Add(eventName);
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}