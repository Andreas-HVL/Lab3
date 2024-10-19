using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Services;
using System.Windows;
using System.Globalization;
using System.Windows.Input;

namespace Lab3.Viewmodels
{
    public class UnbookingViewModel : ObservableObject
    {
        private User _user {  get; set; }
        public ObservableCollection<Pass> BookedPasses { get; set; }
        private string _searchQuery;
        private ObservableCollection<Pass> _filteredResults;
        public ICommand SearchCommand { get; set; }

        private Pass _selectedPass;
        public Pass SelectedPass
        {
            get { return _selectedPass; }
            set
            {
                _selectedPass = value;
                UnBookPass_Click(_selectedPass);
                OnPropertyChanged();
            }
        }

        public string SearchQuery // Container for the input from the searchbar
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Pass> FilteredResults
        {
            get { return _filteredResults; }
            set
            {
                _filteredResults = value;
                OnPropertyChanged();
            }
        }

        public UnbookingViewModel(User user, BookingManager bookingManager)
        {
            SearchCommand = new RelayCommand(Search);
            this._user = user;
            BookedPasses = new ObservableCollection<Pass>(_user.BookedPassList);
            this._filteredResults = BookedPasses;
        }

        private void UnBookPass_Click(Pass _selectedPass) //Unbooks the clicked pass, and updates the list to remove it from the list
        {
            if (_selectedPass != null)
            {
                UnbookingNotification(_user.UnBookPass(_selectedPass));

                BookedPasses.Remove(_selectedPass);
                FilteredResults.Remove(_selectedPass);
                
                Search(SearchQuery);
            }
            
        }

        // Takes input from the search bar and invokes either the SearchName function or SearchTime Function depending on the input
        public void Search(object parameter)
        {
            if (DateTime.TryParseExact(SearchQuery, "HH", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                FilteredResults = PassSearchHelper.SearchByTime(BookedPasses, result.TimeOfDay);
            }
            else
            {
                FilteredResults = PassSearchHelper.SearchByName(BookedPasses, SearchQuery);
            }
        }


        private void UnbookingNotification(string input) //Used to print a MessageBox based on whether a pass was unbooked or not
        {
            MessageBox.Show(input);
        }
    }
}
