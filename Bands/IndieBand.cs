using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bands
{
    public class IndieBand:Band
    {
        public IndieBand(string bandName, DateTime dateFormed, params string[] names) : base(bandName, dateFormed, names)
        {
            Genre = "Indie";
        }

        public override string ToString()
        {
            return base.ToString() + " - " + Genre;
        }
    }
}
