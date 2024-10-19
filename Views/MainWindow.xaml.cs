using Lab3.Models;
using Lab3.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User CurrentUser { get; set; }
        public BookingManager _bookingManager { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            CurrentUser = new User("John Doe");
            _bookingManager = new BookingManager();
        }
        private void GoToBooking_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Booking Page
            MainFrame.NavigationService.Navigate(new Booking(CurrentUser, _bookingManager));
        }
        private void GoToUnbooking_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Unbooking Page
            MainFrame.NavigationService.Navigate(new Unbooking(CurrentUser, _bookingManager));
        }

    }
}