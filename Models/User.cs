using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Lab3.Services;

namespace Lab3.Models
{
    public class User : ObservableObject
    {
        public string Name { get; set; }
        private List<Pass> _bookedPassList;
        public List<Pass> BookedPassList
        {
            get { return _bookedPassList; }
            set
            {
                _bookedPassList = value;
                OnPropertyChanged();
            }
        }

        public User(string name)
        {
            Name = name;
            BookedPassList = new List<Pass>();
        }
        
        public string BookPass(Pass input)
        {
            foreach(Pass pass in BookedPassList)
            {
                if (pass.Id == input.Id) return "You are already booked for this pass";
            }
            if (input.IsFull == false)
            {
                input.SlotsAvailable--;
                BookedPassList.Add(input);
                return "Succesfully booked you for the chosen pass";
            }
            return "No spots available for this pass";
        }

        public string UnBookPass(Pass input)
        {
            input.SlotsAvailable++;
            _bookedPassList.Remove(input);
            return "Succesfully unbooked you from this pass";
        }
    }
}
