using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SportsApp.DAO
{
    public class DBLayer
    {
        private SQLiteConnection connection;

        public string ErrorMessage { get; set; }

        public DBLayer()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            connection = new SQLiteConnection(Path.Combine(path, "sports.db"));
            PrepareDB();

        }

        public void PrepareDB()
        {
            try
            {
                connection.CreateTable<Profile>();
                connection.CreateTable<Country>();
                connection.CreateTable<Match>();
            }
            catch (Exception ex)
            {

            }
        }

        public bool CheckProfile(string name, string password)
        {
            List<Profile> profiles = connection.Query<Profile>("Select * from Profile");
            for (int i = 0; i < profiles.Count; i++)
            {
                if (profiles[i].ProfileName.Equals(name) && profiles[i].Password.Equals(password))
                {
                    return true;
                }

            }
            return false;
        }

        public List<Match> FetchAllMatches(string countryname)
        {
            List<Match> matches = new List<Match>();
            List<Match> datas = FetchAllMatches();
            foreach (Match match in datas)
            {
                if (match.Team1.Equals(countryname) || match.Team2.Equals(countryname))
                {
                    matches.Add(match);
                }
            }
            return matches;
        
        }

        public List<Match> FetchAllMatches(long milliseconds)
        {
            List<Match> matches = new List<Match>();
            List<Match> datas = FetchAllMatches();
            foreach (Match match in datas)
            {
                if (match.MatchDate == milliseconds)
                {
                    matches.Add(match);
                }
            }
            return matches;

        }

        public bool SaveProfile(Profile profile)
        {
            try
            {
                connection.Insert(profile);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool CheckMatchOfCountry(string countryName)
        {
            List<Match> matches = FetchAllMatches();
            if (matches != null && matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (match.Team1.Equals(countryName) || match.Team2.Equals(countryName))
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool SaveCountry(Country country)
        {
            try
            {
                connection.Insert(country);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool SaveMatch(Match match)
        {
            try
            {
                connection.Insert(match);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public List<Country> FetchAllCountries()
        {
            List<Country> countries = connection.Query<Country>("Select * from Country");
            return countries;
        }

        public List<Match> FetchAllMatches()
        {
            List<Match> matches = connection.Query<Match>("Select * from Match");
            return matches;
        }

        public bool RemoveCountry(Country country)
        {
            try
            {
                connection.Delete(country);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool RemoveMatch(Match match)
        {
            try
            {
                connection.Delete(match);
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
    }
}