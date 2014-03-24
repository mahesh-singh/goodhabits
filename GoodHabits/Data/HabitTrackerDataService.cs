using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodHabits.Data
{
    public class HabitTrackerDataService : BaseDataService
    {
        private PetaPoco.Database db;

        public Models.HabitTracker FindHabitTrackerByDateAndHabitID(DateTime date, int HabitID)
        {
            Models.HabitTracker habitTracker;

            var sql = PetaPoco.Sql.Builder.Append("Select * From HabitTracker Where ActivityDate = @0 and HabitID = @1", date.Date.ToString("yyyy-MM-dd"), HabitID);
            using (db = new Database(SQLConnectionStringName))
            {
                habitTracker = db.Fetch<Models.HabitTracker>(sql).SingleOrDefault();
            }

            return habitTracker;
        }

        public IList<Models.HabitTracker> FindHabitTrackerByDateRange(DateTime startDate, DateTime endDate)
        {
            IList<Models.HabitTracker> habitTrackers;

            var sql = PetaPoco.Sql.Builder.Append("Select * From HabitTracker Where ActivityDate >= @0 and ActivityDate <= @1", startDate.Date.ToString("yyyy-MM-dd"), endDate.Date.ToString("yyyy-MM-dd"));
            using (db = new Database(SQLConnectionStringName))
            {
                habitTrackers = db.Fetch<Models.HabitTracker>(sql);
            }

            return habitTrackers;
        }



        public void CreateHabitTracker(Models.HabitTracker habitTracker)
        {
            using (db = new Database(SQLConnectionStringName))
            {
                db.Insert("HabitTracker", "ID", true, habitTracker);
            }
        }

        public void UpdateHabitTracker(Models.HabitTracker habitTracker)
        {
            using (db = new Database(SQLConnectionStringName))
            {
                db.Update("HabitTracker", "ID", habitTracker, habitTracker.ID);
            }
        }
    }
}