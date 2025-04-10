using Project_P.GameObjects;
using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Scenes
{
    public class CaveScene_2 : Map
    {
        public CaveScene_2()
        {
            name = "Cave_2";
            mapData = new string[]
            {
                "####################",
                "#                  #",
                "#                  #",
                "#                  #",
                "#                  #",
                "####################"
            };

            map = new bool[6, 20];

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    map[y, x] = mapData[y][x] == '#' ? false : true;
                }
            }
            Random ran = new Random();
            gameObjects = new List<GameObject>();
            gameObjects.Add(new Place("Cave_1", new Vector2(10, 4)));
            gameObjects.Add(new Place("Boss", new Vector2(10, 1)));
            Monster caveButterfree = MonsterFactory.Create(MonsterType.Butterfree, new Vector2(ran.Next(2, 19), 1), ran.Next(10, 15));
            Monster caveNidorino = MonsterFactory.Create(MonsterType.Nidorino, new Vector2(ran.Next(2, 19), 2), ran.Next(10, 15));
            Monster caveScyther = MonsterFactory.Create(MonsterType.Scyther, new Vector2(ran.Next(2, 19), 2), ran.Next(10, 15));
            gameObjects.Add(caveButterfree);
            gameObjects.Add(caveNidorino);
            gameObjects.Add(caveScyther);
        }
        public override void Enter()
        {
            if (GameManager.prevSceneName == "Cave_1")
            {
                GameManager.Player.Position = new Vector2(10, 3);
            }
            else if (GameManager.prevSceneName == "Battle")
            {
                GameManager.Player.Position = new Vector2(10, 3);
            }
            else if (GameManager.prevSceneName == "Boss")
            {
                GameManager.Player.Position = new Vector2(10, 2);
            }
            GameManager.Player.Map = map;
        }
    }
}
