using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Services
{
    // Implementation of INotifyPropertyChanged interface, letting the UI know when a property's value has changed, so the UI can be updated
    public class ObservableObject : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
