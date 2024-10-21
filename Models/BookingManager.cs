using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class BookingManager
    {
        // Quick n' dirty creation of random training passes to be available in the BookingManager class
        public List<Pass> PassList { get; set; } = new List<Pass>();
        private List<string> workoutTypes = new List<string> 
        {
            "Pilates",
            "Yoga",
            "Spinning",
            "Dance",
            "Zumba",
            "Core",
        };
        public BookingManager()
        {
            Random rnd = new Random();
            for (int i = 0; i <= 25; i++)
            {
                PassList.Add(new Pass(
                    workoutTypes[rnd.Next(0, 6)],
                    DateTime.Now.AddHours(rnd.Next(1, 5)),
                    rnd.Next(0, 5)
                ));
            }
            PassList = PassList
                .OrderBy(x => x.Time)
                .ThenBy(x => x.WorkoutType)
                .ThenByDescending(x => x.SlotsAvailable)
                .ToList();
        }
    }
}
