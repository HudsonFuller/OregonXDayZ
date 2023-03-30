using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonXDayZ
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string user = "3";
            Console.WriteLine("1: New Game");
            Console.WriteLine("0: Quit");
            while(user != "0"){
                user = Console.ReadLine();
                switch(user){
                    case "1":
                        User myCharacter = new User();
                        Location location = new Location();
                        break;
                    case "0":
                        break;
                    default: 
                        Console.WriteLine("Error");
                        break;
                        
                }
            }

            
        }
    }
}
