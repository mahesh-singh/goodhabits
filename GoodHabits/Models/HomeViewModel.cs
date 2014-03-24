using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodHabits.Models
{
    public class HomeViewModel
    {
        public IList<Habit> Habits { get; set; }

        public Dictionary<DateTime, IList<HabitTracker>> TrackerData { get; set; }
    }
}