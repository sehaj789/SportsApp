using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SportsApp.Adapter;
using SportsApp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsApp
{
    [Activity(Label = "New Match")]
    public class AddMatchActivity : AppCompatActivity
    {
        Button b1, b2;
        EditText et1;
        DatePicker date1;
        Spinner spinner1, spinner2;
        DBLayer layer;
        CountryListAdapter adapter1,adapter2;
        int year, month, day;
        List<Country> countries;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_match);
            layer = new DBLayer();

            et1 = FindViewById<EditText>(Resource.Id.text1);
            date1 = FindViewById<DatePicker>(Resource.Id.date1);
            spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);
            spinner2 = FindViewById<Spinner>(Resource.Id.spinner2);
            b1 = FindViewById<Button>(Resource.Id.b1);
            b2 = FindViewById<Button>(Resource.Id.b2);

            countries = layer.FetchAllCountries();
            adapter1 = new CountryListAdapter(this, countries);
            adapter2 = new CountryListAdapter(this, countries);
            spinner1.Adapter = adapter1;
            spinner2.Adapter = adapter2;

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
            string description = et1.Text.Trim();
            if (year == 0 || description.Length == 0 || countries == null || countries.Count() == 0)
            {
                Toast.MakeText(this, "Please Fill Full Form", ToastLength.Long).Show();
            }
            else if (spinner1.SelectedItemPosition != spinner2.SelectedItemPosition)
            {
                DateTime matchdate = new DateTime(year, month, day);
                DateTime begin = new DateTime(1970, 1, 1);
                Country country1 = countries[spinner1.SelectedItemPosition];
                Country country2 = countries[spinner2.SelectedItemPosition];
                Match match = new Match();
                match.Team1 = country1.CountryName;
                match.Team2 = country2.CountryName;
                match.Description = description;
                match.MatchDate = (long)(matchdate - begin).TotalMilliseconds;
                if (layer.SaveMatch(match))
                {
                    Toast.MakeText(this, "Match Details are Saved", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Match Details are not Saved", ToastLength.Long).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Match must be between two different teams", ToastLength.Long).Show();
            }
        }
    }
}