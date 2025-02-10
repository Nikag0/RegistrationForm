namespace UsercСhanges
{
    [Serializable]
    public class DataUserRegOrAuth : DataUser
    {
        private string repPassword = "";

        public string RepPassword
        {
            get => repPassword;
            set
            {
                repPassword = value;
                OnPropertyChanged();
            }
        }
    }
}
