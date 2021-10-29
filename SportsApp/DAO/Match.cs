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
    public class Match
    {
        [PrimaryKey, AutoIncrement]
        public int MatchID { get; set; }

        public string Team1 { get; set; }

        public string Team2 { get; set; }

        public string Description { get; set; }

        public long MatchDate { get; set; }
    }
}