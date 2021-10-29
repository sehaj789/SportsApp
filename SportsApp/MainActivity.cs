using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using SportsApp.DAO;
using Android.Content;

namespace SportsApp
{
    [Activity(Label = "Login Screen", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Button b1;
        EditText et1, et2;
        TextView tv1;
        DBLayer layer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            layer = new DBLayer();
            et1 = FindViewById<EditText>(Resource.Id.text1);
            et2 = FindViewById<EditText>(Resource.Id.text2);

            b1 = FindViewById<Button>(Resource.Id.b1);
            tv1 = FindViewById<TextView>(Resource.Id.text3);
            b1.Click += B1_Click;
            tv1.Click += Tv1_Click;
        }

        private void Tv1_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
            Finish();
        }

        private void B1_Click(object sender, System.EventArgs e)
        {
            string profilename = et1.Text.Trim();
            string password = et2.Text;
            if (profilename.Length == 0 || password.Length == 0)
            {
                Toast.MakeText(this, "Please Fill All Boxes", ToastLength.Long).Show();
            }
            else
            {
                if(profilename.Equals("sehaj") && password.Equals("sehaj@1234"))
                {
                    Intent intent = new Intent(this, typeof(AdminActivity));
                    StartActivity(intent);
                    Finish();
                }
                else if (layer.CheckProfile(profilename, password))
                {
                    Intent intent = new Intent(this, typeof(HomeActivity));
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Invalid Profile Name and Password", ToastLength.Long).Show();
                }
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}