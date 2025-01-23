using System.Windows.Threading;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using UsercСhanges;

namespace UsersApp
{
    public class ViewModelAuthorization : INotifyPropertyChanged
    {
        private UserManagerSQLite userManager = new UserManagerSQLite();
        private DataUserRegOrAuth dataUserAuthorization = new DataUserRegOrAuth();

        DispatcherTimer timer = new DispatcherTimer();
        private int timerNum = 0;
        private string timetButtonText = "Start timer";
        private bool inputAccess = true;

        public ViewModelAuthorization()
        {
            userManager.LoadUsers();
        }

        public DataUserRegOrAuth DataUserAuthorization
        {
            get => dataUserAuthorization;
            set
            {
                dataUserAuthorization = value;
            }
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
        private void TimerTick(object sender, EventArgs e)
        {
            TimerNum++;
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
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
