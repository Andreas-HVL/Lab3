using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Views;
using Lab3.Models;
using Lab3.Services;
using Lab3.Viewmodels;
using System.Windows;
using System.Windows.Input;
using System.Windows.Data;
using System.Security.Policy;
using System.Globalization;

namespace Lab3.Viewmodels
{
    public class BookingViewModel : ObservableObject
    {
        public User _user {  get; set; }
        public BookingManager _bookingManager { get; set; }
        public ObservableCollection<Pass> Passes { get; set; } // Holds a list of all passes creadted by the BookingManager
        private string _searchQuery;
        private ObservableCollection<Pass> _filteredResults; // List to be edited based on user input, which will receive it's data from the Passes list.
        public ICommand SearchCommand { get; set; }

        private Pass _selectedPass;
        public Pass SelectedPass
        {
            get { return _selectedPass; }
            set
            {
                _selectedPass = value;
                BookPass_Click(_selectedPass);
                OnPropertyChanged();
            }
        }

        // Container for input from the SearchBar in the view
        public string SearchQuery 
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
            }
        }
        
        public ObservableCollection<Pass> FilteredResults
        {
            get { return _filteredResults; }
            set
            {
                _filteredResults = value;
                OnPropertyChanged(nameof(FilteredResults));
            }
        }
        
        public BookingViewModel(User user, BookingManager bookingManager)
        {
            SearchCommand = new RelayCommand(Search);
            this._bookingManager = bookingManager;
            this._user = user;
            this.Passes = new ObservableCollection<Pass>(_bookingManager.PassList);
            this._filteredResults = Passes;
        }

        // Books a pass when clicked in the ListView in the Booking View, and prints out a selected message based on wether a pass was booked or not.
        private void BookPass_Click(Pass _selectedPass) 
        {
            if (_selectedPass != null)
            {
            BookingNotification(_user.BookPass(_selectedPass));
            }
        }


        // Takes input from the search bar and invokes either the SearchName function or SearchTime Function depending on the input
        public void Search(object parameter)
        {
            if (DateTime.TryParseExact(SearchQuery, "HH", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                FilteredResults = PassSearchHelper.SearchByTime(Passes, result.TimeOfDay);
            }
            else
            {
                FilteredResults = PassSearchHelper.SearchByName(Passes, SearchQuery);
            }
        }

        //Used to print a MessageBox based on whether a pass was booked or not
        private void BookingNotification(string input) 
        {
                MessageBox.Show(input);
        }

    }
}
