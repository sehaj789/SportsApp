using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsApp.DAO
{
    public class Profile
    {
        [PrimaryKey, AutoIncrement]
        public int UID { get; set; }

        [Unique]
        public string ProfileName { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }
    }
}