using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SportsApp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsApp.Adapter
{
    public class CountryListAdapter : BaseAdapter<Country>
    {
        private readonly Activity context;
        private readonly List<Country> countries;

        public CountryListAdapter(Activity context, List<Country> countries)
        {
            this.countries = countries;
            this.context = context;
        }

        public override int Count
        {
            get { return countries.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Country this[int position]
        {
            get { return countries[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.list_row_country, null, false);
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.text1);

            txt1.Text = countries[position].CountryName + " (" + countries[position].CountryID + ")";

            return row;
        }
    }
}