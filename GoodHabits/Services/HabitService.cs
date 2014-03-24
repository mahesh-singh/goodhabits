using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoodHabits.Data;

namespace GoodHabits.Services
{
    public class HabitService
    {
        private HabitDataService habitDataService;
        private HabitTrackerDataService habitTrackerDataService;

        public HabitService()
        {
            habitDataService = new HabitDataService();
            habitTrackerDataService = new HabitTrackerDataService();
        }

        public IList<Models.Habit> GetAllHabits()
        {
            return habitDataService.FindAll();
        }

        public void Save(Models.Habit habit)
        {
            if(habit.ID>0)
            {
                //Update
                Models.Habit currentHabit = habitDataService.FindHabitByID(habit.ID);
                habit.CreatedDate = currentHabit.CreatedDate;

                habitDataService.UpdateHabit(habit);
            }
            else
            {
                habit.CreatedDate = DateTime.Now;
                habitDataService.CreateHabit(habit);
            }
        }

        public Models.Habit GetHabitByID(int ID)
        {
            return habitDataService.FindHabitByID(ID);
        }

        public IList<Models.Habit> GetHabitByDate(DateTime date)
        {
            IList<Models.Habit> habits = habitDataService.FindAll();

            Dictionary<int, Models.Habit> habitsForTheDay = new Dictionary<int, Models.Habit>();

            foreach(Models.Habit habit in habits)
            {
                Models.HabitTracker habitTracker = habitTrackerDataService.FindHabitTrackerByDateAndHabitID(date, habit.ID);

                habit.SelectedDateTrackerData = habitTracker;

                if(date.DayOfWeek == DayOfWeek.Monday && habit.Mon && !habitsForTheDay.ContainsKey(habit.ID))
                {
                    habitsForTheDay.Add(habit.ID, habit);
                }

                if (date.DayOfWeek == DayOfWeek.Tuesday && habit.Tue && !habitsForTheDay.ContainsKey(habit.ID))
                {
                    habitsForTheDay.Add(habit.ID, habit);
                }

                if (date.DayOfWeek == DayOfWeek.Wednesday && habit.Wed && !habitsForTheDay.ContainsKey(habit.ID))
                {
                    habitsForTheDay.Add(habit.ID, habit);
                }

                if (date.DayOfWeek == DayOfWeek.Thursday && habit.Thr && !habitsForTheDay.ContainsKey(habit.ID))
                {
                    habitsForTheDay.Add(habit.ID, habit);
                }

                if (date.DayOfWeek == DayOfWeek.Friday && habit.Fri && !habitsForTheDay.ContainsKey(habit.ID))
                {
                    habitsForTheDay.Add(habit.ID, habit);
                }

                if (date.DayOfWeek == DayOfWeek.Saturday && habit.Sat && !habitsForTheDay.ContainsKey(habit.ID))
                {
                    habitsForTheDay.Add(habit.ID, habit);
                }

                if (date.DayOfWeek == DayOfWeek.Sunday && habit.Sun && !habitsForTheDay.ContainsKey(habit.ID))
                {
                    habitsForTheDay.Add(habit.ID, habit);
                }
            }


            return habitsForTheDay.Values.ToList();
        }

        public void SaveTrackers(IList<Models.HabitTracker> HabitTrackers)
        {
            foreach(Models.HabitTracker tracker in  HabitTrackers)
            {
                

                Models.HabitTracker currentTracker = habitTrackerDataService.FindHabitTrackerByDateAndHabitID(tracker.ActivityDate, tracker.HabitID);
                if(currentTracker == null)
                {
                    
                    habitTrackerDataService.CreateHabitTracker(tracker);
                }
                else
                {
                    tracker.ID = currentTracker.ID;
                    habitTrackerDataService.UpdateHabitTracker(tracker);
                }
            }    
        }


        public IList<Models.HabitTracker> GetHabitTrackerByDateRange(DateTime startDate, DateTime endDate)
        {
            return habitTrackerDataService.FindHabitTrackerByDateRange(startDate, endDate);
        }


    }

}