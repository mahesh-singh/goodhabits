using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
namespace GoodHabits.Data
{
    public class HabitDataService : BaseDataService
    {
        private PetaPoco.Database db;

        

        public void CreateHabit(Models.Habit habit)
        {
            using (db = new Database(SQLConnectionStringName))
            {
                db.Insert("Habit", "ID", true, habit);
            }
        }

        public void UpdateHabit(Models.Habit habit)
        {
            using (db = new Database(SQLConnectionStringName))
            {
                db.Update("Habit", "ID", habit, habit.ID);
            }
        }

        public Models.Habit FindHabitByID(int HabitID)
        {
            Models.Habit habit;

            var sql = PetaPoco.Sql.Builder.Append("Select * From Habit Where ID = @0", HabitID);
            using (db = new Database(SQLConnectionStringName))
            {
                habit = db.Fetch<Models.Habit>(sql).SingleOrDefault();
            }

            return habit;
        }

        public IList<Models.Habit> FindAll()
        {
            List<Models.Habit> habits = new List<Models.Habit>();

            var sql = PetaPoco.Sql.Builder.Append("Select * From Habit");
            using (db = new Database(SQLConnectionStringName))
            {
                habits = db.Fetch<Models.Habit>(sql);
            }

            return habits;
        }
    }
}