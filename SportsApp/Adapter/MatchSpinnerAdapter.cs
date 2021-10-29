using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SportsApp.DAO;
using SportsApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsApp.Adapter
{
    class MatchSpinnerAdapter : BaseAdapter<Match>
    {
        private readonly Activity context;
        private readonly List<Match> matches;

        public MatchSpinnerAdapter(Activity context, List<Match> matches)
        {
            this.matches = matches;
            this.context = context;
        }

        public override int Count
        {
            get { return matches.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Match this[int position]
        {
            get { return matches[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.list_row_country, null, false);
            }

            TextView txt1 = row.FindViewById<TextView>(Resource.Id.text1);
            DateTime date = Common.DateFromMilliseconds(matches[position].MatchDate);
            txt1.Text = matches[position].Team1 + " vs " + matches[position].Team2 + " On " + date.ToShortDateString();
            return row;
        }
    }
}