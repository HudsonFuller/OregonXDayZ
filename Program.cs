﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OregonXDayZ
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Starting Game
            string user = "3";
            Console.WriteLine("1: New Game");
            Console.WriteLine("0: Quit");
            while(user != "0"){
                user = Console.ReadLine();
                switch(user){
                    case "1":
                        Location location = new Location();
                        location.Begin();
                        user = "0";
                        break;
                    case "0":
                        break;
                    default: 
                        Console.WriteLine("Error");
                        break;
                        
                }
            }
            Console.ReadLine();

            
        }
    }
}
