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
        public int getLevel()
        {
            return userStats.level;
        }
        public void changeHealth(int damage)
        {
            userVitals.Health= userVitals.Health-damage;
            return;
        }
        public void gainXp(int xp)
        {
            userStats.xpGain(xp);
            return;
        }
        public void gainHealth(int restore)
        {
            userVitals.Health += restore;
            if(userVitals.Health> 100)
            {
                userVitals.Health = 100;
            }
            return;
        }
        public void gainHunger(int restore)
        {
            userVitals.Hunger += restore;
            if (userVitals.Hunger > 100)
            {
                userVitals.Hunger = 100;
            }
            return;
        }
        public void gainDrink(int restore)
        {
            userVitals.Thirst += restore;
            if (userVitals.Thirst > 100)
            {
                userVitals.Thirst = 100;
            }
            return;
        }
        public void printVitals()
        {
            Console.WriteLine("Health: " + userVitals.Health);
            Console.WriteLine("Hunger: " + userVitals.Hunger);
            Console.WriteLine("Thirst: " + userVitals.Thirst);
            if (userVitals.Hunger <= 0)
                this.changeHealth(userVitals.Health);
            else if (userVitals.Thirst <= 0)
                this.changeHealth(userVitals.Health);
            return;
        }
        public void newDayChange()
        {
            userVitals.Thirst -= 10;
            userVitals.Hunger -= 10;
        }
        public void printEquipables()
        {
            if (userInventory.clothing == null)
                Console.WriteLine("No Clothing Worn");
            else
            {
                Item curClothing = userInventory.clothing;
                Console.WriteLine(curClothing.name + " " + curClothing.defenseAmount + " defense");
            }
            if (userInventory.hands[0] == null)
                Console.WriteLine("Nothing in Hand 1");
            else
            {
                Item hand1 = userInventory.hands[0];
                Console.WriteLine(hand1.name + " " + hand1.attackAmount + " attack");
            }
            if (userInventory.hands[1] == null)
                Console.WriteLine("Nothing in Hand 2");
            else
            {
                Item hand2 = userInventory.hands[1];
                Console.WriteLine(hand2.name + " " + hand2.attackAmount + " attack");
            }
            return;
        }
        public void equipItem(Item item)
        {
            if (item.typeName == "Clothing")
            {
                if (userInventory.clothing != null)
                {
                    Item oldClothing = userInventory.clothing;
                    userStats.defense -= oldClothing.defenseAmount;
                }
                userInventory.clothing = item;
                userStats.defense += item.defenseAmount;
            }
            else
            {
                if (userInventory.hands[0]==null)
                {
                    userInventory.hands[0]= item;
                    userStats.strength += item.attackAmount;
                }
                else if (userInventory.hands[1]==null)
                {
                    userInventory.hands[1]= item;
                    userStats.strength += item.attackAmount;
                }
                else
                {
                    Item itemCheck1 =  userInventory.hands[0];
                    Item itemCheck2 = userInventory.hands[1];
                    if (itemCheck1.attackAmount < itemCheck2.attackAmount)
                    {
                        userStats.strength -= itemCheck1.attackAmount;
                        userInventory.hands[0] = item;
                        userStats.strength += item.attackAmount;
                    }
                    else
                    {
                        userStats.strength -= itemCheck2.attackAmount;
                        userInventory.hands[1] = item;
                        userStats.strength += item.attackAmount;
                    }

                }
            }
            return;
        }

    }
    
}