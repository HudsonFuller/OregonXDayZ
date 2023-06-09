using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private string[] nameArr = { "Zombie", "Vampire", "Wolf", "Bear", "Survivor", "Trader", "Gunman", "Witch", "Skinwalker", "Crawling Woman" };
        Random rnd = new Random();
        public Enemy(int day)
        {
            this.attack = rnd.Next(day) + 1;
            this.defense = rnd.Next(day) + 1;
            this.wits = rnd.Next(day) + 1;
            this.health = rnd.Next(day) + 1;
            this.name = nameArr[rnd.Next(10)];
        }
        public void goAttack(int myAttack, int enemyAttack, User user, Enemy enemy)
        {
            // aFormula is based on the difference between your attack and enemy defense, and this determines our standard deviation
            int aFormula = myAttack * 50;
            if (aFormula <= 0)
            {
                aFormula = 50;
            }
            int infin = 0;
            while (infin == 0)
            {
                //this is a critical hit, if the two random rolls are less than 25 apart
                if (Math.Abs((rnd.Next(1000) + 1) - (rnd.Next(1000) + 1)) < 25)
                {
                    enemy.health = 0;
                    Console.WriteLine("Critical Hit");

                }
                else if (Math.Abs((rnd.Next(1000) + 1) - (rnd.Next(1000) + 1)) < aFormula)
                {
                    // checks if two numbers are aFormula apart
                    if (myAttack <= 0)
                    {
                        myAttack = 1;
                    }
                    enemy.health = enemy.health - myAttack;
                    Console.WriteLine("Enemy has been hit, he now has " + enemy.health);

                }
                if (enemy.health <= 0)
                {
                    int xp = rnd.Next(125) + 100;
                    Console.WriteLine(this.name + " has been Slain");
                    user.gainXp(xp);
                    return;
                }
                else
                {
                    if (enemyAttack <= 0)
                    {
                        enemyAttack = 1;
                    }
                    user.changeHealth(enemyAttack*10);
                    int HP = user.getHealth();
                    Console.WriteLine("You have taken " + enemyAttack*10 + " damage, your health is now " + HP);
                    Console.ReadLine();
                    if (HP <= 0)
                    {
                        return;
                    }
                }
            }



        }
        public void sneak(int sneakDif, User user, Enemy enemy, int myAttack)
        {
            // the difference for you to sneak against the enemy
            int sFormula = sneakDif * 250;
            if (Math.Abs((rnd.Next(1000) + 1) - (rnd.Next(1000) + 1)) < sFormula)
            {

                Console.WriteLine("You have snuck past the " + enemy.name);
                int xp = rnd.Next(125) + 100;
                user.gainXp(xp);
            }
            else
            {
                Console.WriteLine("You failed the sneak");
                user.changeHealth(enemy.attack*10);
                int HP = user.getHealth();
                Console.WriteLine("You have taken " + enemy.attack*10 + " damage, your health is now " + HP);
                Console.WriteLine("You must now fight");
                Console.ReadLine();
                enemy.goAttack(myAttack, enemy.attack, user, enemy);
            }
            return;
        }
    }
}