using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P
{
    public class Player
    {
        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }


        private bool[,] map;
        public bool[,] Map
        {
            get { return map; }
            set { map = value; }
        }


        private Inventory inventory;
        public Inventory Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }

        private ItemInventory iteminventory;
        public ItemInventory Iteminventory
        {
            get { return iteminventory; }
            set { iteminventory = value; }
        }
        public void Print()
        {
            Console.SetCursorPosition(position.x, position.y + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("P");
            Console.ResetColor();
        }

        public void Action(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.W:
                case ConsoleKey.S:
                case ConsoleKey.D:
                case ConsoleKey.A:
                    Move(input);
                    break;
                case ConsoleKey.E:
                    Iteminventory.Open();
                    break;
                default:
                    break;
            }
        }

        public void Move(ConsoleKey input)
        {
            Vector2 targetPos = position;

            switch (input)
            {
                case ConsoleKey.W:
                    targetPos.y--;
                    break;
                case ConsoleKey.S:
                    targetPos.y++;
                    break;
                case ConsoleKey.D:
                    targetPos.x++;
                    break;
                case ConsoleKey.A:
                    targetPos.x--;
                    break;
                default:
                    break;
            }
            if(map[targetPos.y, targetPos.x] == true)
            {
                position = targetPos;
            }
        }
    }
}
