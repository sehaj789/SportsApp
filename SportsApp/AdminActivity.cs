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
    [Activity(Label = "Admin Screen")]
    public class AdminActivity : AppCompatActivity
    {
        Button b1, b2, b3, b4, b5, b6, b7;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_admin);

            b1 = FindViewById<Button>(Resource.Id.b1);
            b2 = FindViewById<Button>(Resource.Id.b2);
            b3 = FindViewById<Button>(Resource.Id.b3);
            b4 = FindViewById<Button>(Resource.Id.b4);
            b5 = FindViewById<Button>(Resource.Id.b5);
            b6 = FindViewById<Button>(Resource.Id.b6);
            b7 = FindViewById<Button>(Resource.Id.b7);

            b1.Click += B1_Click;
            b2.Click += B2_Click;
            b3.Click += B3_Click;
            b4.Click += B4_Click;
            b5.Click += B5_Click;
            b6.Click += B6_Click;
            b7.Click += B7_Click;
        }

        private void B7_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            Finish();
        }

        private void B6_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(DeleteMatchActivity));            
            StartActivity(intent);
        }

        private void B5_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ViewAllMatchActivity));
            StartActivity(intent);
        }

        private void B4_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AddMatchActivity));
            StartActivity(intent);
        }

        private void B3_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(DeleteCountryActivity));
            StartActivity(intent);
        }

        private void B2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ViewAllCountryActivity));
            StartActivity(intent);
        }

        private void B1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AddCountryActivity));
            StartActivity(intent);
        }
    }
}