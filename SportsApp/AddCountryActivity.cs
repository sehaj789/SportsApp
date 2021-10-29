using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SportsApp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsApp
{
    [Activity(Label = "New Country")]
    public class AddCountryActivity : AppCompatActivity
    {
        EditText et1, et2;
        Button b1, b2;
        DBLayer layer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_country);
            layer = new DBLayer();
            et1 = FindViewById<EditText>(Resource.Id.text1);
            et2 = FindViewById<EditText>(Resource.Id.text2);

            b1 = FindViewById<Button>(Resource.Id.b1);
            b2 = FindViewById<Button>(Resource.Id.b2);
            b1.Click += B1_Click;
            b2.Click += B2_Click;
        }

        private void B2_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void B1_Click(object sender, EventArgs e)
        {
            string countryid = et1.Text.Trim();
            string countryname = et2.Text.Trim();
            string message = "";
            if (countryid.Length == 0 || countryname.Length == 0)
            {
                message = "Please Enter Some Value in Boxes";
            }
            else
            {
                Country country = new Country();
                country.CountryID = countryid;
                country.CountryName = countryname;
                if (layer.SaveCountry(country))
                {
                    message = "Country Details are Saved!!!";
                    et1.Text = "";
                    et2.Text = "";
                }
                else
                {
                    message = layer.ErrorMessage;
                }
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}