using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Expressions
{
    /// <summary>
    /// Classes for all game objects to draw from
    /// </summary>
    public class GameObject
    {
        public int ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public int PlayerID { get; set; }
    }

    /// <summary>
    /// Ship class that gets values from the Gameobject Class
    /// </summary>
    public class Ship : GameObject { }

    /// <summary>
    /// Class to build and store Player object
    /// </summary>
    public class Player
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string TeamColor { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Uses list to create and store a number of enemy ships using as game objects
            List<GameObject> gameObjects = new List<GameObject>();
            gameObjects.Add(new Ship { ID = 1, CurrentHP = 50, MaxHP = 100, PlayerID = 1 });
            gameObjects.Add(new Ship { ID = 2, CurrentHP = 75, MaxHP = 100, PlayerID = 1 });
            gameObjects.Add(new Ship { ID = 3, CurrentHP = 0, MaxHP = 100, PlayerID = 2 });
            gameObjects.Add(new Ship { ID = 3, CurrentHP = 100, MaxHP = 100, PlayerID = 2 });

            //Uses List to create and store a number to players for the game 
            List<Player> players = new List<Player>();
            players.Add(new Player { ID = 1, UserName = "Player 1", TeamColor = "Red" });
            players.Add(new Player { ID = 2, UserName = "Player 2", TeamColor = "Blue" });

            //Collection of all the game objects that have full health
            IEnumerable<GameObject> fullHealthObject = from o in gameObjects
                                                       where o.CurrentHP >= o.MaxHP
                                                       select o;


            //Collection of all the game objects that have full health by ID
            IEnumerable<int> fullHealthIds = from o in gameObjects
                                                    where o.CurrentHP >= o.MaxHP
                                                    select o.ID;

            ///Linq to call and group game objects by ID
            var results = from o in gameObjects
                          orderby o.CurrentHP / o.MaxHP
                          group o by o.PlayerID;

            //Goes though the gameobjects and prints that out in order based on currentHP
            foreach (var group in results)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                    Console.WriteLine("    " + item.CurrentHP + "/" + item.MaxHP +
                        " (" + (int)((item.CurrentHP / item.MaxHP) * 100) + "%)");
            }


        }
    }
}
