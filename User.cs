using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonXDayZ
{
    public class User
    {
        Stats userStats = new Stats();
        Vitals userVitals = new Vitals();
        Inventory userInventory = new Inventory();
        public int getHealth(){
            return userVitals.Health;
        }
        public int getStrength(){
            return userStats.strength;
        }
        public int getDefense(){
            return userStats.defense;
        }
        public int getStealth(){
            return userStats.stealth;
        }
        public void changeHealth(int damage)
        {
            userVitals.Health= userVitals.Health-damage;
            return;
        }
    }
    
}