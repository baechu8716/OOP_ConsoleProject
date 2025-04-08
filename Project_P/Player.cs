using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P
{
    public class Player
    {
        public Vector2 position;
        public bool[,] map;

        public void Print()
        {
            Console.SetCursorPosition(position.x, position.y + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("P");
            Console.ResetColor();
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
            if (map[targetPos.y, targetPos.x] == true)
            {
                position = targetPos;
            }
        }
    }
}
