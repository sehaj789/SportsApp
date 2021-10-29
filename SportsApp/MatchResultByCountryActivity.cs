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
    [Activity(Label = "Match By Country")]
    public class MatchResultByCountryActivity : AppCompatActivity
    {
        Button b1;
        ListView list1;
        DBLayer layer;
        MatchListAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_view_all_country);

            b1 = FindViewById<Button>(Resource.Id.b1);
            list1 = FindViewById<ListView>(Resource.Id.list1);

            layer = new DBLayer();

            b1.Click += B1_Click; ;

            adapter = new MatchListAdapter(this, layer.FetchAllMatches());

            string countryname = Intent.GetStringExtra("CountryName");
            if(countryname!=null)
            {
                adapter = new MatchListAdapter(this, layer.FetchAllMatches(countryname));
            }

            list1.Adapter = adapter;

        }

        private void B1_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}