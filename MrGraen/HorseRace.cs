using System;
using System.Collections.Generic;
using System.Linq;

namespace HorseRace
{
    class Horse {
        public string Name { get; set; }
        public int WinWeight = (new Random()).Next(1, 100);

        public Horse(string name) {
            Name = name;
        }

        public double GetWinChance(List<Horse> horses) {
            double totalWeight = horses.Sum(h => h.WinWeight);
            return WinWeight / totalWeight;
        }
    }

    class Race {
        public List<Horse> Horses { get; set; }

        public int HorsesAmount { get; set; }

        private List<string> _names = new List<string>(){"Hans", "Grethe", "Kenneth", "Morten", "Hans", "Erape Tracer", "Ruth", "Jørgen", "Monster Cock"};

        public Race(int horsesAmount) {
            HorsesAmount = horsesAmount;

            Horses = new List<Horse>();

            List<string> unusedNames = new List<string>(_names);

            Random rnd = new Random();
            for (int i = 0; i < HorsesAmount; i++) {
                int nameIndex = rnd.Next(0, unusedNames.Count() - 1);
                string name = unusedNames[nameIndex];
                unusedNames.RemoveAt(nameIndex);

                if (unusedNames.Count() <= 0){
                    unusedNames = new List<string>(_names);
                }

                Horses.Add(new Horse(name));
            }
        }

        internal Horse GetWinner(){
            Random rnd = new Random();

            int totalWeight = 0;
            foreach (Horse horse in Horses) {
                totalWeight += horse.WinWeight;
            }

            int winnerWeight = rnd.Next(1, totalWeight);

            foreach (Horse horse in Horses) {
                if (winnerWeight <= horse.WinWeight) {
                    return horse;
                }
                winnerWeight -= horse.WinWeight;
            }

            return null;
        }

        public void run(){

        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Race race1 = new Race(5);
    //        // show horses
    //        foreach (Horse horse in race1.Horses) {
    //            Console.WriteLine(horse.Name + " " + horse.WinWeight);
    //        }
    //        Console.ReadLine();
    //        Console.WriteLine(race1.GetWinner().Name);
    //    }
    //}
}