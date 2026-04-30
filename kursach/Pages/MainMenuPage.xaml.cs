using System;
using System.Collections;
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
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
            List<string> Cities = new List<string>
            { 
                "Москва",
                "Питер",
                "Калининград",
                "Куда-то"
            };
            SearchBar.ItemsSource = Cities;

            List<string> Guest = new List<string>
            {
                "1",
                "2",
                "3",
                "4"
            };
            Quality.ItemsSource = Guest;

            List<Hotel1> hotel = Core.Context.Hotel1.Where(h => h.IsActive == true).ToList();
            HotelsLB.ItemsSource = hotel;
        }

        private void HotelsLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectHotel = HotelsLB.SelectedItem as Hotel1;

            if (selectHotel == null) return;

            HotelPage page = new HotelPage(selectHotel);

            NavigationService.Navigate(page);
        }

        private void SearchBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectHotel = SearchBar.SelectedItem as string;

            if (selectHotel == "Куда-то")
            {
                List<Hotel1> hotel = Core.Context.Hotel1.Where(h => h.IsActive == true).ToList();
                HotelsLB.ItemsSource = hotel;
            }
            else
            {
                List<Hotel1> selectedHotels = Core.Context.Hotel1.Where(x => x.City.Name == selectHotel && x.IsActive == true).ToList();
                HotelsLB.ItemsSource = selectedHotels;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
        }
    }
}
