using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class BookingManager
    {
        public List<Pass> PassList { get; set; } = new List<Pass>();
        private List<string> workoutTypes = new List<string>
        {
            "Pilates",
            "Yoga",
            "Spinning",
            "Dance",
            "Zumba",
        };
        public BookingManager()
        {
            Random rnd = new Random();
            for (int i = 0; i <= 10; i++)
            {
                PassList.Add(new Pass(
                    workoutTypes[rnd.Next(0, 5)],
                    DateTime.Now.AddHours(rnd.Next(1, 5)),
                    rnd.Next(0, 5)
                ));
            }
            PassList = PassList.OrderBy(x => x.WorkoutType).ToList();
        }

        












        /*
        public List<Pass> SearchPass(string workout, DateTime? time)
        {
            return PassList
                .Where(p => (string.IsNullOrEmpty(workout) || p.Workout == workout)
                         && (!time.HasValue || p.Time == time.Value))
                .ToList();
        }
        */
    }
}
