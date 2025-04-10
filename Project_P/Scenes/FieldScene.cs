using Project_P.GameObjects;
using Project_P.GameObjects.Items;
using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_P.Scenes
{
    public class FieldScene : Map
    {
        public FieldScene()
        {
            name = "Field";
            mapData = new string[]
            {
                "####################",
                "#      #     #     #",
                "#   #  #        ## #",
                "#   #  #######   # #",
                "#   #            # #",
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
            gameObjects.Add(new Place("Village", new Vector2(2, 4)));
            gameObjects.Add(new Place("Cave", new Vector2(10, 1)));
            gameObjects.Add(new MonsterBall(10, new Vector2(18, 4)));
            Monster fieldBulbasaur = MonsterFactory.Create(MonsterType.Bulbasaur, new Vector2(10, 4), ran.Next(1, 3));
            gameObjects.Add(fieldBulbasaur);
        }
        public override void Enter()
        {
            if (GameManager.prevSceneName == "Village")
            {
                GameManager.Player.Position = new Vector2(2, 4);
            }
            else if (GameManager.prevSceneName == "Battle")
            {
                GameManager.Player.Position = new Vector2(10, 4);
            }
            else if (GameManager.prevSceneName == "Cave_1")
            {
                GameManager.Player.Position = new Vector2(11, 3);
            }
            GameManager.Player.Map = map;
        }
    }
}
