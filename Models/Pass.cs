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
        public Guid Id { get; set; }
        public string WorkoutType { get; set; }
        public DateTime Time { get; set; }
        public int TotalSlots { get; set; }
        public bool IsFull { get { return SlotsAvailable <= 0; } }
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
