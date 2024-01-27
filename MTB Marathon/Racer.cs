using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTB_Marathon
{
    internal class Racer
    {


        private int startnumber;
        private string name = string.Empty;
        private int birthYear;
        private string nation = string.Empty;
        private string racetime = string.Empty;

        public int Startnumber { get { return startnumber; } set { startnumber = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Year { get { return birthYear; } set { birthYear = value; } }
        public string Nation { get { return nation; } set { nation = value; } }
        public string Racetime { get { return racetime; } set { racetime = value; } }
        public double RaceTimeInSec { get { return TimeSpan.Parse(Racetime).TotalSeconds; } }

        public override string ToString()
        {
            return $"{Startnumber} {Name} {Year} {Nation} {Racetime} {RaceTimeInSec}";
        }
        public string ToCsv()
        {
            return $"{Startnumber};{Name};{Year};{Nation};{Racetime};{RaceTimeInSec}";
        }
        public Racer() { }
    }
}
