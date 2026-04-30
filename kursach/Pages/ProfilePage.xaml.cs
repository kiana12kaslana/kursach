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
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            Loaded += ProfilePage_Loaded;
        }

        private void ProfilePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (State.curr_user_id == 0)
            {
                MessageBox.Show("Вы не авторизованы");
                NavigationService.Navigate(new MainMenuPage());
                return;
            }

            var currentUser = Core.Context.User.FirstOrDefault(u => u.UserID == State.curr_user_id);
            if (currentUser != null)
            {
                LoginTB.Text = currentUser.Login;
                EmailTB.Text = currentUser.Email;
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
                NavigationService.Navigate(new MainMenuPage());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}