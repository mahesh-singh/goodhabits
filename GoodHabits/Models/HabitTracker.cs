using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodHabits.Models
{
    public class HabitTracker
    {
        public int ID { get; set; }

        public int HabitID { get; set; }

        public int Status { get; set; }

        public DateTime ActivityDate { get; set; }
    }
}