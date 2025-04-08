using Project_P.GameObjects;
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
        protected List<GameObject> gameObjects;

        public override void Render()
        {
            Console.WriteLine($"{GameManager.curScene.name}");
            PrintMap();
            foreach(GameObject gameobject in gameObjects)
            {
                gameobject.Print();
            }
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
            foreach(GameObject gameobject in gameObjects)
            {
                if(gameobject.position.x == GameManager.Player.Postiion.x &&
                    gameobject.position.y == GameManager.Player.Postiion.y)
                {
                    gameobject.Interact(GameManager.Player);
                    if (gameobject.isOnce == true)
                    {
                        gameObjects.Remove(gameobject);
                    }
                }
            }
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
