using UsercСhanges;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;


namespace UsersApp
{
    public class ViewModelRegistration
    {
        private DataUserRegOrAuth dataUsersRegistration = new DataUserRegOrAuth();
        private UserManagerSQLite userRegistrate = new UserManagerSQLite();
        //private UserManager userRegistrate = new UserManager();
        Stopwatch sw = new Stopwatch();

        public ViewModelRegistration(UserManagerSQLite userManager)
        {
            this.userRegistrate = userManager;
        }

        //public ViewModelRegistration(UserManager userManager)
        //{
        //    this.userRegistrate = userManager;
        //}

        public DataUserRegOrAuth DataUsersRegistration
        {
            get => dataUsersRegistration;
            set
            {
                dataUsersRegistration = value;
            }
        }

        public ICommand ButtonSignUpClick
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    sw.Start();
                    int error = userRegistrate.RegistrationUser(dataUsersRegistration);
                    sw.Stop();

                    switch (error)
                    {
                        case 1:
                            MessageBox.Show("login must be longer than 5 characters.");
                            break;
                        case 2:
                            MessageBox.Show("Password must be longer than 6 characters and contain lowercase and uppercase letters, a numeric value and special character.", "Message");
                            break;
                        case 3:
                            MessageBox.Show("Passwords don't match", "Message");
                            break;
                        case 4:
                            MessageBox.Show("Email was entered incorrectly", "Message");
                            break;
                        case 5:
                            MessageBox.Show("This login or email is already registered", "Message");
                            break;
                        case 0:
                            MessageBox.Show("Registrations is done", "Message");
                            //this.Close();
                            TimeSpan ts = sw.Elapsed;

                            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds / 10);
                            using (StreamWriter writer = new StreamWriter("Timer.txt"))
                                writer.WriteLine(elapsedTime);
                            break;

                    }
                });
            }
        }
    }
}
