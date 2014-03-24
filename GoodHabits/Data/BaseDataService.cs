using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace GoodHabits.Data
{
    public abstract class BaseDataService
    {
        protected const string SQLConnectionStringName = "GoodHabits.SQLDB";
    }
}