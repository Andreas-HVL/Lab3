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
using Lab3.Models;
using Lab3.Viewmodels;

namespace Lab3.Views
{
    public partial class Booking : Page
    {
        public Booking(User user, BookingManager bookingManager) 
        {
            InitializeComponent();
            DataContext = new BookingViewModel(user, bookingManager);
        }
    }
}
