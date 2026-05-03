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
    public partial class BookingPage : Page
    {
        Hotel1 _hotel;
        Apartment _apartment;

        public BookingPage(Hotel1 selectedHotel, Apartment selectedApartment)
        {
            InitializeComponent();
            _hotel = selectedHotel;
            _apartment = selectedApartment;

            HotelNameTB.Text = _hotel.Name;
            ApartmentNameTB.Text = _apartment.Name;
            PriceTB.Text = _apartment.Price.ToString();

            DateStartDP.SelectedDate = DateTime.Now;
            DateEndDP.SelectedDate = DateTime.Now.AddDays(1);
        }

        private void ConfirmBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Бронирование успешно оформлено!");
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

}
