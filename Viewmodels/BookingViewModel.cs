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
        public ObservableCollection<Pass> Passes { get; set; }
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
                BookPass_Click(_selectedPass);
                OnPropertyChanged();
            }
        }

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
        
        private void BookPass_Click(Pass _selectedPass)
        {
            if (_selectedPass != null)
            {
            BookingNotification(_user.BookPass(_selectedPass));
            }
        }

        private void SearchName(object parameter)
        {
            if (string.IsNullOrEmpty(SearchQuery))
            {
                FilteredResults = new ObservableCollection<Pass>(Passes);
            }
            else
            {
                FilteredResults = new ObservableCollection<Pass>(
                   Passes.Where(e => e.WorkoutType.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)));
            }
        }

        private void SearchTime(TimeSpan timeResult)
        {
            FilteredResults = new ObservableCollection<Pass>(
                Passes.Where(e => e.Time.TimeOfDay.Hours == timeResult.Hours));
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

        private void BookingNotification(string input)
        {
                MessageBox.Show(input);
        }

    }
}
