using Project_P.GameObjects;
using Project_P.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Scenes
{
    public class VillageScene : Map
    {
        public VillageScene()
        {
            name = "Village";
            mapData = new string[]
            {
                "####################",
                "#   #  #     #     #",
                "#   #  #     #     #",
                "## ##  ### ###     #",
                "#                  #",
                "####################"
            };

            map = new bool[6 , 20];

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    map[y, x] = mapData[y][x] == '#' ? false : true;
                }
            }

            gameObjects = new List<GameObject>();
            gameObjects.Add(new Place("Field", new Vector2(16, 1)));
            gameObjects.Add(new Potion(10, new Vector2(3, 1)));
            gameObjects.Add(new Potion(10, new Vector2(10, 1)));
            gameObjects.Add(new PP_Ether(1, new Vector2(11, 1)));
            gameObjects.Add(new MonsterBall(5, new Vector2(3, 2)));
        }
        public override void Enter()
        {
            if (GameManager.prevSceneName == "Select")
            {
                GameManager.Player.Position = new Vector2(1, 2);
            }
            if (GameManager.prevSceneName == "Field")
            {
                GameManager.Player.Position = new Vector2(16, 2);
            }
            GameManager.Player.Map = map;
        }
    }
}
