using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bands
{
    public class PopBand : Band
    {
        public PopBand(string bandName, DateTime dateFormed, params string[] names) : base(bandName, dateFormed, names)
        {
            Genre = "Pop";
        }
        public override string ToString()
        {
            return base.ToString() + " - " + Genre;
        }
    }
}
