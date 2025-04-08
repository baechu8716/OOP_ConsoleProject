using Project_P.GameObjects;
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
                "#   #  #     #     #",
                "#   #  #     #     #",
                "## ##  ### ###     #",
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

            gameObjects = new List<GameObject>();
            gameObjects.Add(new Place("Village", new Vector2(2, 1)));
        }
        public override void Enter()
        {
            if (GameManager.prevSceneName == "Village")
            {
                GameManager.Player.Postiion = new Vector2(2, 1);
            }
            GameManager.Player.Map = map;
        }
    }
}
