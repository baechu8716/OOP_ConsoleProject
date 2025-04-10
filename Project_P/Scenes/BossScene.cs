using Project_P.GameObjects.Items;
using Project_P.GameObjects;
using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Scenes
{
    public class BossScene : Map
    {
        public BossScene()
        {
            name = "Boss";
            mapData = new string[]
            {
                "####################",
                "#####  #     #  ####",
                "#####  #     #  ####",
                "#####  #     #  ####",
                "#####           ####",
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
            gameObjects = new List<GameObject>();
            gameObjects.Add(new Place("Cave_2", new Vector2(10, 4)));
            Monster BossHo_oh = MonsterFactory.Create(MonsterType.Ho_oh, new Vector2(10, 1), 50);
            gameObjects.Add(BossHo_oh);
        }

        public override void Enter()
        {
            if (GameManager.prevSceneName == "Cave_2")
            {
                GameManager.Player.Position = new Vector2(10, 3);
            }
            else if (GameManager.prevSceneName == "Battle")
            {
                GameManager.Player.Position = new Vector2(10, 3);
            }
            GameManager.Player.Map = map;
        }
    }
}
