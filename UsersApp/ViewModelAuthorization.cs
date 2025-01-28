using System.Windows.Threading;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using UsercСhanges;
using System.Diagnostics;
using System.IO;
using System.Windows.Shapes;

namespace UsersApp
{
    public class ViewModelAuthorization : INotifyPropertyChanged
    {
        private UserManagerSQLite userManager = new UserManagerSQLite();
        //private UserManager userManager = new UserManager();
        private DataUserRegOrAuth dataUserAuthorization = new DataUserRegOrAuth();

        DispatcherTimer timer = new DispatcherTimer();
        private int timerNum = 0;
        private string timetButtonText = "Start timer";
        private bool inputAccess = true;
        Stopwatch sw = new Stopwatch();

        public ViewModelAuthorization()
        {
            userManager.LoadUsers();
            sw.Start();
            userManager.SerializeBinary();
           //userManager.SerializeXML();
            sw.Stop();
            //userManager.PasToHash();

            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            using (StreamWriter writer = new StreamWriter("Timer.txt"))
                writer.WriteLine(elapsedTime);
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

        public ICommand ButtonSerialize
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
               
                });
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
