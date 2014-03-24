using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodHabits.Models
{
    public class Habit
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool? Daily { get; set; }

        public int? DaysPerWeek { get; set; }

        public bool Mon { get; set; }

        public bool Tue { get; set; }

        public bool Wed { get; set; }

        public bool Thr { get; set; }

        public bool Fri { get; set; }

        public bool Sat { get; set; }

        public bool Sun { get; set; }

        public bool? WeekEnds { get; set; }

        public DateTime CreatedDate { get; set; }

        [PetaPoco.Ignore]
        public HabitTracker SelectedDateTrackerData { get; set; }
    }
}