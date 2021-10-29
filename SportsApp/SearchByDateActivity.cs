using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsApp
{
    [Activity(Label = "Search By Date")]
    public class SearchByDateActivity : AppCompatActivity
    {
        Button b1, b2;
        DatePicker date1;
        int year, month, day;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_search_by_date);
            
            date1 = FindViewById<DatePicker>(Resource.Id.date1);
            b1 = FindViewById<Button>(Resource.Id.b1);
            b2 = FindViewById<Button>(Resource.Id.b2);

            b1.Click += B1_Click;
            b2.Click += B2_Click;
            date1.DateChanged += Date1_DateChanged;
        }

        private void Date1_DateChanged(object sender, DatePicker.DateChangedEventArgs e)
        {
            year = e.Year;
            month = e.MonthOfYear;
            day = e.DayOfMonth;
        }

        private void B2_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void B1_Click(object sender, EventArgs e)
        {
            if (year == 0 )
            {
                Toast.MakeText(this, "Please Select Any Date", ToastLength.Long).Show();
            }
            else 
            {
               Intent intent = new Intent(this, typeof(MatchResultByDateActivity));
                DateTime matchdate = new DateTime(year, month, day);
                DateTime begin = new DateTime(1970, 1, 1);
                intent.PutExtra("MatchDate", (long)(matchdate - begin).TotalMilliseconds);
                StartActivity(intent);
            }
        }
    }
}