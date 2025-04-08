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
        }
        public override void Enter()
        {
            if (GameManager.prevSceneName == "Select")
            {
                GameManager.Player.position = new Vector2(1, 2);
            }
            GameManager.Player.map = map;
        }
    }
}
