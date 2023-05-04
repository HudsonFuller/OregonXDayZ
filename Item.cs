using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OregonXDayZ
{
    public class Item
    { // has a list of different items that can be found
        Random rnd = new Random();
        private string[] itemType = { "Clothing", "Food", "Drink", "Weapon" , "Healing" };
        private string[] foodType = { "Steak", "Hot Dog", "Twinkie", "Apple", "Canned Chicken" };
        private string[] drinkType = { "Root Beer", "Bottled Water", "Beer", "Orange Juice", "Gatorade" };
        private string[] clothingType = { "Denim Outfit", "SwimWear", "Suit", "Flannel and Jeans", "Jumper" };
        private string[] weaponType = { "Sword", "Knife", "Spiked Bat", "Mace", "Crowbar" };
        private string[] healingType = { "First Aid Kit", "Bandage", "PainKiller", "Splint", "Morphine" };
        public int restoreAmount;
        public int defenseAmount;
        public int attackAmount;
        public string typeName;
        public string name;
        public Item()
        {
            // this is a constructor that makes a random item to give ot the user.
            this.typeName = itemType[rnd.Next(5)];
            if (this.typeName == "Food" || this.typeName == "Drink" || this.typeName == "Healing")
            {
                if(this.typeName == "Food")
                    this.name = foodType[rnd.Next(5)];
                else if(this.typeName=="Drink")
                    this.name = drinkType[rnd.Next(5)];
                else
                    this.name = healingType[rnd.Next(5)];
                this.restoreAmount = (rnd.Next(5) + 1) * 10;
            }
            else if(this.typeName == "Weapon")
            {
                this.name = weaponType[rnd.Next(5)];
                this.attackAmount = rnd.Next(5) + 1;
            }
            else
            {
                this.name = clothingType[rnd.Next(5)];
                this.defenseAmount = rnd.Next(5) + 1;
            }
        }

    }
}
