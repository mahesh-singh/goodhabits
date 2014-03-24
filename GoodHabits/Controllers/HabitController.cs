using GoodHabits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GoodHabits.Services;

namespace GoodHabits.Controllers
{
    public class HabitController : Controller
    {
        //
        // GET: /Habit/
        private HabitService habitService;
        public HabitController()
        {
            habitService = new HabitService();
        }


        public ActionResult Index()
        {

            Models.HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.Habits = habitService.GetAllHabits();

            IList<Models.HabitTracker> HabitTrackers = habitService.GetHabitTrackerByDateRange(DateTime.Now.AddDays(-30), DateTime.Now);

            homeViewModel.TrackerData = new Dictionary<DateTime, IList<HabitTracker>>();

            if (HabitTrackers!=null)
            {
                foreach(Models.HabitTracker tracker in HabitTrackers)
                {
                    if(!homeViewModel.TrackerData.ContainsKey(tracker.ActivityDate))
                    {
                        IList<Models.HabitTracker> lstTracker = new List<Models.HabitTracker>();
                        lstTracker.Add(tracker);
                        homeViewModel.TrackerData.Add(tracker.ActivityDate, lstTracker);
                    }
                    else
                    {
                        homeViewModel.TrackerData[tracker.ActivityDate].Add(tracker);
                    }

                }
            }



            return View(homeViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("SaveHabit");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Habit habit = habitService.GetHabitByID(ID);
            return View("SaveHabit", habit);
        }

        [HttpPost]
        public ActionResult SaveHabit(Habit habit)
        {
            habitService.Save(habit);
            return RedirectToAction("All");
        }


        [HttpGet]
        public ActionResult All()
        {
            IList<Habit> habits = habitService.GetAllHabits();

            return View("Habits", habits);
        }

        [HttpGet]
        public ActionResult Track(DateTime? date)
        {
            IList<Habit> habits = new List<Habit>();
            if (date.HasValue)
            {
                ViewBag.date = date.Value;
                habits = habitService.GetHabitByDate(date.Value);
            }
            else
            {
                ViewBag.date = DateTime.Now;
                habits = habitService.GetHabitByDate(DateTime.Now);
            }

            return View("TrackHabit", habits);
        }

        [HttpPost]
        public ActionResult SaveHabitTracker(IList<HabitTracker>  HabitTrackers)
        {

            habitService.SaveTrackers(HabitTrackers);

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

    }
}
