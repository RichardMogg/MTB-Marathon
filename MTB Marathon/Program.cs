using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MTB_Marathon
{
    internal class Program
    {
        public int sum;
        private static Racer[] racers = [];

        private static readonly string FilepathOriginData = @"Data\MTB-Marathon.csv";
        private static string SavingFilePath = @"D:\Programieren mit Franky\MTB Marathon\MTB Marathon\Data\MTB-SortedByStartnumber.csv";
        static void Main(string[] args)
        {
            racers = Loader.LoadRacer(FilepathOriginData);

            foreach (var Racer in racers)
            {
                Console.WriteLine(@"NR  Name       Jahrgang  Nation Racetime        RaceTimeInSec");

                var results = racers.OrderBy(p => p.Startnumber);

                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            Console.WriteLine($"Die durchschnittliche Rennzeit beträgt: {Average()}");

            SaveToCsvFile(racers, SavingFilePath);
        }

        static double Average()
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




