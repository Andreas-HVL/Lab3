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
        private BookingManager _bookingManager { get; set; }
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

        public string SearchQuery
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
            this._bookingManager = bookingManager;
            this._user = user;
            BookedPasses = new ObservableCollection<Pass>(_user.BookedPassList);
            this._filteredResults = BookedPasses;
        }

        private void UnBookPass_Click(Pass _selectedPass)
        {
            if (_selectedPass != null)
            {
                UnbookingNotification(_user.UnBookPass(_selectedPass));

                BookedPasses.Remove(_selectedPass);
                FilteredResults.Remove(_selectedPass);
                
                Search(SearchQuery);
            }
            
        }
        private void SearchName(object parameter)
        {
            if (string.IsNullOrEmpty(SearchQuery))
            {
                FilteredResults = new ObservableCollection<Pass>(BookedPasses);
            }
            else
            {
                FilteredResults = new ObservableCollection<Pass>(
                   BookedPasses.Where(e => e.WorkoutType.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)));
            }
        }

        private void SearchTime(TimeSpan timeResult)
        {
            FilteredResults = new ObservableCollection<Pass>(
                BookedPasses.Where(e => e.Time.TimeOfDay.Hours == timeResult.Hours));
        }

        public void Search(object parameter)
        {
            if (DateTime.TryParseExact(SearchQuery, "HH", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                SearchTime(result.TimeOfDay);
            }
            else
            {
                SearchName(SearchQuery);
            }
        }

        private void UnbookingNotification(string input)
        {
            MessageBox.Show(input);
        }
    }
}
