using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bands
{

    public abstract class Band : IComparable
    {
        //public enum Genre { Rock, Pop, HipHop, Country, RnB, Blues, Jazz, Rap, Reggae, Funk, Disco, Electronic, Metal, HeavyMetal}
        public string BandName { get; set; }
        public DateTime DateFormed { get; set; }
        public List<string> Members;
        //Genre BandsGenre;
        public string Genre{ get; set; }
        public List<Album> Albums;

        public Band(string bandName, DateTime dateFormed,/* Genre g,*/ params string[] names)//enum is taken off for the time being
        {
            BandName = bandName;
            DateFormed = dateFormed;
            Members = new List<string>();
            //BandsGenre = g;

            foreach (string n in names)
            {
                Members.Add(n);
            }

            Albums = new List<Album>();
        }

        public int CompareTo(object obj)
        {
            Band that = obj as Band;
            return BandName.CompareTo(that.BandName);
        }

        public string getInfo()//returns string with the whole band info nicely formatted
        {
            string info = string.Format($"Name: { BandName }\nFormed: {DateFormed.Year}\nMembers: ");
            for (int i = 0; i < Members.Count; i++)
            {
                info += Members[i];
                if (i < Members.Count - 1)
                {
                    info += ", ";
                }
            }
            return info;
        }

        public void addAlbums(params string[] names)// for each name typed makes own album
        {
            foreach(string n in names)
            {
                Albums.Add(new Album(n, DateFormed.Year));
            }
        }

        public override string ToString()
        {
            return BandName;
        }
    }
}
