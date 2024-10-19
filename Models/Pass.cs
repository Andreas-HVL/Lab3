using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Services;
namespace Lab3.Models
{
    public class Pass : ObservableObject
    {
        public Guid Id { get; set; } // GUID Used to ensure user does not book the same training pass twice
        public string WorkoutType { get; set; }
        public DateTime Time { get; set; }
        public int TotalSlots { get; set; }
        public bool IsFull { get { return SlotsAvailable <= 0; } }
        
        // ObservableObject to ensure each pass is correctly updated when receiving data from the UI
        private int _slotsAvailable;
        public int SlotsAvailable 
        {
            get { return _slotsAvailable; }
            set
            {
                _slotsAvailable = value;
                OnPropertyChanged(); 
            }
        }

        public Pass(string workout, DateTime time, int slots, int totalSlots = 5)
        {
            WorkoutType = workout;
            Time = time;
            SlotsAvailable = slots;
            TotalSlots = totalSlots;
            this.Id = Guid.NewGuid();
        }

        
    }
}
