using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bands
{
    public class RockBand : Band
    {        
        public RockBand(string bandName, DateTime dateFormed, params string[] names):base(bandName, dateFormed, names)
        {
            Genre = "Rock";
        }
        public override string ToString()
        {
            return base.ToString() + " - " + Genre;
        }
    }
}
