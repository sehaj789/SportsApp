using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsApp.Utility
{
    public static class Common
    {
        public static DateTime DateFromMilliseconds(long milliseconds)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(milliseconds);
            DateTime date = new DateTime(1970, 1, 1) + time;
            return date;
        }
    }
}