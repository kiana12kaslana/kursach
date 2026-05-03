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
    /// Логика взаимодействия для HotelPage.xaml
    /// </summary>
    public partial class HotelPage : Page
    {
        public Hotel1 selectHotel { get; set; }

        public HotelPage(Hotel1 selectHotel)
        {
            InitializeComponent();
            this.selectHotel = selectHotel;
            string hotelname = selectHotel.Name;
            hoteln.Text = hotelname;

            List<HotelApartment> hotelApartments = Core.Context.HotelApartment.Where(x => x.HotelID == selectHotel.HotelID).ToList();

            List<Apartment> apartments = new List<Apartment>();

            foreach (HotelApartment hotelApartment in hotelApartments)
            {
                foreach (Apartment a in Core.Context.Apartment.ToList())
                {
                    if (hotelApartment.ApartmentID == a.ApartmentID) { apartments.Add(a); }
                }
            }
            AprtmentsLB.ItemsSource = apartments;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void AprtmentsLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedApartment = AprtmentsLB.SelectedItem as Apartment;

            if (selectedApartment == null) return;

            NavigationService.Navigate(new BookingPage(this.selectHotel, selectedApartment));
        }


        //private void BookingPageLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    var selectBookingPage = AprtmentsLB.SelectedItem as Hotel1;

        //    if (selectHotel == null) return;
        //    BookingPage page = new BookingPage(selectBookingPage);
        //    NavigationService.Navigate(page);
        //}
    }
}
