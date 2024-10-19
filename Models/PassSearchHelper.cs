using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public static class PassSearchHelper
    {
        public static ObservableCollection<Pass> SearchByName(IEnumerable<Pass> passes, string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return new ObservableCollection<Pass>(passes);
            }
            else
            {
                return new ObservableCollection<Pass>(
                    passes.Where(e => e.WorkoutType.Contains(query, StringComparison.OrdinalIgnoreCase)));
            }
        }

        public static ObservableCollection<Pass> SearchByTime(IEnumerable<Pass> passes, TimeSpan time)
        {
            return new ObservableCollection<Pass>(
                passes.Where(e => e.Time.TimeOfDay.Hours == time.Hours));
        }
    }
}
