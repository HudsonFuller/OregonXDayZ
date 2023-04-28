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
                while(myCharacter.getHealth()>=0){
                this.newDay();
                day++;
            }
            Console.WriteLine("Your Game has ended on day "+day);
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
            int itemAmount = rnd.Next(3);
            while(itemAmount > 0)
            {
                Item itemFind= new Item();

            }

        }
    }

}