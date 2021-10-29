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
    [Activity(Label = "Delete Match Details")]
    public class DeleteMatchActivity : AppCompatActivity
    {
        Button b1, b2;
        Spinner spinner;
        DBLayer layer;
        MatchSpinnerAdapter adapter;
        List<Match> matches;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_delete_match);

            layer = new DBLayer();

            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            b1 = FindViewById<Button>(Resource.Id.b1);
            b2 = FindViewById<Button>(Resource.Id.b2);

            matches = layer.FetchAllMatches();
            adapter = new MatchSpinnerAdapter(this, matches);
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
            if (matches != null && matches.Count() > 0)
            {
                Match match = matches[spinner.SelectedItemPosition];
                    if (layer.RemoveMatch(match))
                    {
                        message = "Match Details is Removed";
                        matches.RemoveAt(spinner.SelectedItemPosition);
                        adapter.NotifyDataSetChanged();
                    }
                    else
                    {
                        message = "Match Details is not Removed";
                    }
                
            }
            else
            {
                message = "There is Match Details is not Available For Delete.";
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}