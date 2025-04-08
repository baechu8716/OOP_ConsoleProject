using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Scenes
{
    public class Map : BaseScene
    {
        protected string[] mapData;
        protected bool[,] map;

        public override void Render()
        {
            Console.WriteLine($"{GameManager.curScene.name}");
            PrintMap();
            // Console.WriteLine($"초기 위치: ({GameManager.Player.position.x}, {GameManager.Player.position.y}");
            GameManager.Player.Print();
            Console.SetCursorPosition(0, map.GetLength(0) + 2);
            GameManager.Player.Inventory.PrintAll();
        }

        public override void Update()
        {
            GameManager.Player.Move(input);
        }
        public override void Result()
        {

        }  

        public void PrintMap()
        {
            Console.SetCursorPosition(0, 1);
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == true)
                    {
                        Console.Write(' ');
                    }
                    else if (map[y, x] == false)
                    {
                        Console.Write('#');
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
