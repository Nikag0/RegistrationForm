using System.Windows.Threading;
using System.Runtime.CompilerServices;
using UserManager;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace UsersApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private UserManager.UserManager userManager = new UserManager.UserManager();
        private DataUserRegOrAuth dataUserAuthorization = new DataUserRegOrAuth();

        DispatcherTimer timer = new DispatcherTimer();
        private int timerNum = 0;
        private string timetButtonText = "Start timer";
        private bool inputAccess = true;

        public ViewModel()
        {
            userManager.LoadUsers();
        }

        public int TimerNum
        {
            get => timerNum;
            set
            {
                timerNum = value;
                OnPropertyChanged();
            }
        }
        public string TimetButtonText
        {
            get => timetButtonText;
            set
            {
                timetButtonText = value;
                OnPropertyChanged();
            }
        }

        public bool InputAccess
        {
            get => inputAccess;
            set
            {
                inputAccess = value;
                OnPropertyChanged();
            }
        }

        public ICommand Timer
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    if (timerNum == 0)
                    {
                        timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromSeconds(1);
                        timer.Tick += TimerTick;
                        timer.Start();
                        TimetButtonText = "Reset timer";
                    }
                    else
                    {
                        TimerNum = 0;
                        timer.Stop();
                        TimetButtonText = "Start timer";
                    }
                });
            }
        }

        public ICommand ButtonCreateAccountClick
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    RegistrationWindow registrationWindow = new RegistrationWindow(userManager);
                    registrationWindow.Show();
                });
            }
        }

        public ICommand ButtonSignInClick
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    if (userManager.AuthorizationUser(dataUserAuthorization))
                    {
                        MessageBox.Show("login is successful", "Message");
                    }
                    else
                    {
                        MessageBox.Show("The user is not registered or password was entered incorrectly", "Message");
                        MessageBox.Show($"{dataUserAuthorization.Login} and {dataUserAuthorization.Password}");
                    }
                });
            }
        }

        public ICommand EnabledText
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    InputAccess = false;

                });

            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            TimerNum++;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
