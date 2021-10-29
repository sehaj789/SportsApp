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
    [Activity(Label = "Search By Country")]
    public class SearchByCountryActivity : AppCompatActivity
    {
        Button b1, b2;
        Spinner spinner;
        DBLayer layer;
        CountryListAdapter adapter;
        List<Country> countries;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_search_by_country);

            layer = new DBLayer();
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            b1 = FindViewById<Button>(Resource.Id.b1);
            b2 = FindViewById<Button>(Resource.Id.b2);

            countries = layer.FetchAllCountries();
            adapter = new CountryListAdapter(this, countries);
            spinner.Adapter = adapter;

            b1.Click += B1_Click;
            b2.Click += B2_Click;
        }

        private void B2_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void B1_Click(object sender, EventArgs e)
        {
            string message = "";
            if (countries != null && countries.Count() > 0)
            {
                Country country = countries[spinner.SelectedItemPosition];
                Intent intent = new Intent(this, typeof(MatchResultByCountryActivity));
                intent.PutExtra("CountryName", country.CountryName);
                StartActivity(intent);
            }
            else
            {
                message = "There is NO Such Country Available For Search.";
                Toast.MakeText(this, message, ToastLength.Long).Show();
            }
            
        }
    }
}