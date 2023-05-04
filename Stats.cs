using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonXDayZ
{
    public class Stats
    {
        public int strength = 1;
        public int defense = 1;
        public int stealth = 1;
        public int xp = 0;
        public int level = 1;
        public void xpGain(int xp)
        {
            this.xp += xp;
            int x = 1;
            while (x == 1)
            {
                // this checks an exponential counter to see if you level up, based on xp gain.
                // the x++ is in this to deteremine if you could possibly level up twice
                if (this.xp > level * 100 * Math.Pow(1.01, level))
                {
                    this.level++;
                    Console.WriteLine("You have reached Level " + level);
                    this.levelGain();
                    x++;
                }
                x--;
            }
        }
        public void levelGain() {
            string user = "yes";
            while (user != "done")
            {
                Console.WriteLine("1: up Strength , current "+ this.strength);
                Console.WriteLine("2: up defense, current "+ this.defense);
                Console.WriteLine("3: up stealth, current "+this.stealth);
                user = Console.ReadLine();
                // every level up you get to add a stat to your character. 
                switch (user)
                {
                    case "1":
                        this.strength++;
                        user = "done";
                        break;
                    case "2":
                        this.defense++;
                        user = "done";
                        break;
                    case "3":
                        this.stealth++;
                        user = "done";
                        break;
                    default:
                        Console.WriteLine("No number found");
                        break;
                }
            }
        }
    }
}