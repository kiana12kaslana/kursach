using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kursach.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage :  Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            List <User> users = Core.Context.User.ToList();
            try
            {
                User curruser = users.First(u => u.Login == LoginTB.Text);
                if (curruser.Password == PasswordTB.Text)
                {
                    NavigationService.Navigate(new MainMenuPage());
                }
                else { MessageBox.Show("Неправилльный логин или пароль"); }
            }
            catch { MessageBox.Show("Неправилльный логин или пароль"); }
        }
    }
}
