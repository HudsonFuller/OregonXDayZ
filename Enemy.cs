using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonXDayZ
{
    public class Enemy
    {
        public int attack;
        public int defense;
        private int health;
        public int wits;
        public string name;
        private string[] nameArr = {"Zombie", "Vampire", "Wolf", "Bear", "Survivor", "Trader", "Gunman", "Witch", "Skinwalker", "Crawling Woman"};
        Random rnd = new Random();
        public Enemy(int day){
            this.attack = rnd.Next(day)+1;
            this.defense = rnd.Next(day)+1;
            this.wits = rnd.Next(day)+1;
            this.health = rnd.Next(day)+1;
            this.name = nameArr[rnd.Next(10)];           
        }
        public void goAttack(int myAttack, int enemyAttack, User user, Enemy enemy){
            int aFormula= myAttack*75;
            Console.WriteLine("Got in");
            if(Math.Abs((rnd.Next(1000)+1)-(rnd.Next(1000)+1))<50){
                enemy.health = 0;
                Console.WriteLine("Critical Hit");
            }
            else if(Math.Abs((rnd.Next(1000)+1)-(rnd.Next(1000)+1))<aFormula){
                enemy.health=enemy.health-myAttack;
                Console.WriteLine("Enemy has been hit, he now has " + enemy.health);
            }
            if(enemy.health <=0){
                int xp= rnd.Next(125);
                Console.WriteLine(this.name + " has been Slain");
            }
            else{
                user.health=user.health - enemyAttack;
                Console.WriteLine("You have taken " + enemyAttack + " damage, your health is now "+ user.health);
            }
            
        }
    }
}