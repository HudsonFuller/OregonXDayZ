using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonXDayZ
{
    public class Location
    {
        private int day = 1;
        private string[] places = {"Farmhouse", "Barn", "Cemetary", "Bakery", "Mansion", "Firehouse", "PoliceStation", "WatchTower", "Hospital", "GroceryStore"};
        Random rnd = new Random();
        User myCharacter = new User();
        public void Begin(){
                while(myCharacter.getHealth()>0){
                this.newDay();
                day++;
            }
            Console.WriteLine("Your Game has ended on day "+day);
            return; 
        }
        private void newDay(){
            Console.WriteLine("Day " + day);
            Console.WriteLine("You have stumbled upon a " + places[rnd.Next(10)]);
            int enemyQ = 1;
            bool enemyBool=false;
            if(rnd.Next(3)==enemyQ)
                enemyBool=true;
            if(enemyBool == true){

                Enemy enemy = new Enemy(myCharacter.getLevel());
                int myAttackDif = myCharacter.getStrength() - enemy.defense;
                int enemyAttackDif = enemy.attack - myCharacter.getDefense()+1;
                int sneakDif = myCharacter.getStealth() - enemy.wits;
                string user="7";
                
                while(user!="complete"){
                    Console.WriteLine("1: Attack the " + enemy.name);
                    Console.WriteLine("2: Try to Sneak past the Enemy");
                    user = Console.ReadLine();
                    switch (user)
                    {
                        case "1":
                            enemy.goAttack(myAttackDif, enemyAttackDif, myCharacter, enemy);
                            user= "complete";
                            break;
                        case "2":
                            enemy.sneak(sneakDif, myCharacter, enemy, myAttackDif);
                            user = "complete";
                            break;
                        default:
                            Console.WriteLine("Number Not Found");
                            break;
                    }
                }
            }
            if (myCharacter.getHealth() <= 0)
                return;
            int itemAmount = rnd.Next(3)+1;
            int x = 0;
            while (x < itemAmount)
            {
                x++;
                Item itemFind = new Item();
                Console.WriteLine("You found a " + itemFind.name);
                string choice = "bruh";
                if (itemFind.typeName == "Clothing" || itemFind.typeName == "Weapon")
                {
                    while (choice != "equip")
                    {
                        Console.WriteLine("Current Clothing and Weapons");
                        myCharacter.printEquipables();
                        if (itemFind.typeName == "Weapon")
                        {
                            Console.WriteLine("1: equip " + itemFind.name + " " + itemFind.attackAmount + " attack amount");
                        }
                        if (itemFind.typeName == "Clothing")
                        {
                            Console.WriteLine("1: equip " + itemFind.name + " " + itemFind.defenseAmount + " defense amount");
                        }
                        Console.WriteLine("2: leave item");
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                myCharacter.equipItem(itemFind);
                                choice = "equip";
                                break;
                            case "2":
                                choice = "equip";
                                break;
                            default:
                                Console.WriteLine("No Choice Found");
                                break;
                        }
                    }
                }
                else
                {
                    if (itemFind.typeName == "Food")
                    {
                        Console.WriteLine("You have Consumed the " + itemFind.name);
                        myCharacter.gainHunger(itemFind.restoreAmount);
                    }
                    else if (itemFind.typeName == "Drink")
                    {
                        Console.WriteLine("You have Drank the " + itemFind.name);
                        myCharacter.gainDrink(itemFind.restoreAmount);
                    }
                    else
                    {
                        Console.WriteLine("You have used the " + itemFind.name);
                        myCharacter.gainHealth(itemFind.restoreAmount);
                    }
                }

            }
            myCharacter.printVitals();
            myCharacter.newDayChange();
            Console.ReadLine();
        }
    }

}