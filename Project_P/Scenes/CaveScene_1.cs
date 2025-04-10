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
    public class CaveScene_1 : Map
    {
        public CaveScene_1()
        {
            name = "Cave_1";
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
            gameObjects.Add(new Place("Field", new Vector2(10, 4)));
            Monster caveBulbasaur = MonsterFactory.Create(MonsterType.Bulbasaur, new Vector2(ran.Next(2,19), 1), ran.Next(5, 10));
            Monster caveCharmander = MonsterFactory.Create(MonsterType.Charmander, new Vector2(ran.Next(2, 19), 2), ran.Next(5, 10));
            Monster caveSquirtle = MonsterFactory.Create(MonsterType.Squirtle, new Vector2(ran.Next(2, 19), 2), ran.Next(5, 10));
            gameObjects.Add(caveBulbasaur);
            gameObjects.Add(caveCharmander);
            gameObjects.Add(caveSquirtle);
            gameObjects.Add(caveBulbasaur);
            gameObjects.Add(caveCharmander);
            gameObjects.Add(caveSquirtle);
        }
        public override void Enter()
        {
            if (GameManager.prevSceneName == "Field")
            {
                GameManager.Player.Position = new Vector2(10, 5);
            }
            else if (GameManager.prevSceneName == "Battle")
            {
                GameManager.Player.Position = new Vector2(10, 5);
            }
            GameManager.Player.Map = map;
        }
    }
}
