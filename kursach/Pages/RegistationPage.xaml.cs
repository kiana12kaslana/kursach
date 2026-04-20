using kursach;
using kursach.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для RegistationPage.xaml
    /// </summary>
    public partial class RegistationPage : Page
    {
        public RegistationPage()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
        private void Regitr_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = Core.Context.User.ToList();
            if (LoginTB.Text != "" && PasswordTB.Text != "" && EmailTB.Text != "")
            {
                try
                {
                    User failUser = users.First(x => x.Login == LoginTB.Text);
                    MessageBox.Show("Пользователь с данным логином уже существует");
                }
                catch
                {
                    User newUser = new User()
                    {
                        Login = LoginTB.Text,
                        Password = PasswordTB.Text,
                        Email = EmailTB.Text,
                    };
                    Core.Context.User.Add(newUser);
                    Core.Context.SaveChanges();

                    users = Core.Context.User.ToList();
                }
            }
            else { MessageBox.Show("Данные не заполнены!"); }
        }
    }
}
