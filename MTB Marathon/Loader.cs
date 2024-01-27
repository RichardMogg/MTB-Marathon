using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MTB_Marathon
{
    internal class Loader
    {

        internal static Racer[] LoadRacer(string filepath)
        {

            {
                return File.ReadAllLines(filepath)
                           .Select(l => l.Split(';'))
                           .Select(d =>
                           {
                               return new Racer()
                               {
                                   Startnumber = Convert.ToInt32(d[0]),
                                   Name = d[1],
                                   Year = Convert.ToInt32(d[2]),
                                   Nation = d[3],
                                   Racetime = d[4],
                               };
                           }).ToArray();
            }




        }
    }
}
