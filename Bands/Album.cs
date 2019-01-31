using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bands
{
    public class Album
    {
        public string AlbumName { get; set; }
        public DateTime YearReleased { get; set; }
        public int Sales { get; set; }
        Random rand = new Random();
        int yearsOut;

        public Album(string name, int startingYear)
        {
            AlbumName = name;
            YearReleased = new DateTime(rand.Next(startingYear, DateTime.Now.Year+1), 10, 20);//random year from the starting year of the band to now
            Sales = rand.Next(0, 1000001);
        }

        public string getInfo()
        {
            string info = string.Format($"Name: {AlbumName}\nYear released: {YearReleased.Year.ToString()}\nSales: {Sales.ToString()}");
            return info;
        }

        int getYearsSinceReleased()
        {
            DateTime now;
            now = DateTime.Now;
            yearsOut = now.Year - YearReleased.Year;
            return yearsOut;
        }

        public override string ToString()
        {
            return string.Format($"{AlbumName} Years out: { getYearsSinceReleased()}");
        }
    }
}
