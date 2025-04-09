using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Scenes
{
    public class SelectScene : BaseScene
    {
        Monster startingCharmander = MonsterFactory.Create(MonsterType.Charmander, new Vector2(1, 2), 1);
        Monster startingBulbasaur = MonsterFactory.Create(MonsterType.Bulbasaur, new Vector2(48, 2), 1);
        Monster startingSquirtle = MonsterFactory.Create(MonsterType.Squirtle, new Vector2(94, 2), 1);
        public SelectScene()
        {
            name = "Select";
        }   

        public override void Render()
        {
            Console.WriteLine("스타팅 포켓몬중 하나를 선택해주세요");
            startingCharmander.Print();
            startingSquirtle.Print();
            startingBulbasaur.Print();
            Console.SetCursorPosition(1, 24);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("1.파이리\t\t\t\t\t2.이상해씨\t\t\t\t\t3.꼬부기");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------");

        }      

        public override void Update()
        {
            
        }
        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    GameManager.Player.Inventory.monsters[0]= startingCharmander;
                    GameManager.ChangeScene("Village");
                    break;
                case ConsoleKey.D2:
                    GameManager.Player.Inventory.monsters[0] = startingBulbasaur;
                    GameManager.ChangeScene("Village");
                    break;
                case ConsoleKey.D3:
                    GameManager.Player.Inventory.monsters[0] = startingSquirtle; 
                    GameManager.ChangeScene("Village");
                    break;
                default: break;

            }
        }
    }
}
