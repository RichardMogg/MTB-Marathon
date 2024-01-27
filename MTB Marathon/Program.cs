using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MTB_Marathon
{
    internal class Program
    {
        //public int sum;
        //private static Racer[] racers = [];

        private static readonly string FilepathOriginData = @"Data\MTB-Marathon.csv";
        private static string SavingFilePath = @"D:\Programieren mit Franky\MTB Marathon\MTB Marathon\Data\MTB-SortedByStartnumber.csv";

        private static void Main(string[] args)
        {
            var racers = Loader.LoadRacer(FilepathOriginData);

            Console.WriteLine(@"NR  Name       Jahrgang  Nation Racetime        RaceTimeInSec");

            //old
            //foreach (var Racer in racers)
            //{
            //    var results = racers.OrderBy(p => p.Startnumber);

            // falsch
            //    foreach (var result in results)
            //    {
            //        Console.WriteLine(result);
            //    }
            //}

            foreach (var racer in racers.OrderBy(r => r.RaceTimeInSec).Take(3))
            {
                //var results = racers.OrderBy(p => p.Startnumber);

                Console.WriteLine(racer);
            }

            Console.WriteLine($"Die durchschnittliche Rennzeit beträgt: {Average(racers)}");

            //SaveToCsvFile(racers, SavingFilePath);
        }

        private static double Average(Racer[] racers)
        {
            double sum = 0;
            for (int i = 0; i < racers.Length; i++)
            {
                sum = sum + Convert.ToInt32(racers[i].RaceTimeInSec);
            }
            sum = sum / racers.Length;

            return Math.Round(sum, 2);
        }

        private static void SaveToCsvFile(Racer[] racers, string saveingFilePath)
        {
            var results = racers.OrderBy(p => p.Startnumber);
            List<string> lines = new List<string>();
            foreach (var result in results)
            {
                lines.Add(result.ToCsv());
            }

            File.WriteAllLines(saveingFilePath, lines);
        }
    }
}