using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_P.GameObjects.Items
{
    public class Potion : Item
    {
        public Potion(int count, Vector2 position) 
            : base("포켓몬의 체력을 30 회복시킨다.", count,"상처약",ConsoleColor.Magenta, position, true)
        {

        }

        public override void Use()
        {
            int index = -1;
            int useCount = 0;
            Console.WriteLine("포션을 사용할 몬스터를 지정해주세요");
            Console.Clear();
            GameManager.Player.Inventory.PrintAll();
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.D1: 
                    index = 0; 
                    break;
                case ConsoleKey.D2: 
                    index = 1; 
                    break;
                case ConsoleKey.D3: 
                    index = 2; 
                    break;
                case ConsoleKey.D4: 
                    index = 3; 
                    break;
                case ConsoleKey.D5: 
                    index = 4; 
                    break;
                case ConsoleKey.D6: 
                    index = 5; 
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 1~6을 선택하세요.");
                    Console.ReadKey(true);
                    return;
            }

            Monster selectMonster = GameManager.Player.Inventory.monsters[index];
            if (index < 0 || index >= GameManager.Player.Inventory.monsters.Length)
            {
                Console.WriteLine("잘못된 몬스터 슬롯입니다.");
                Console.ReadKey(true);
                return;
            }
            if (selectMonster == null)
            {
                Console.WriteLine("선택한 슬롯에 몬스터가 없습니다.");
                Console.ReadKey(true);
                return;
            }
            if (selectMonster.CurHP >= selectMonster.MaxHP)
            {
                Console.WriteLine($"{selectMonster.Name}의 HP가 이미 최대입니다.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine($"사용할 개수를 선택하세요 (1 이상) 남은 개수 : {count} 대상의 현재 체력 : {selectMonster.CurHP}");
            bool correctInput = false;
            do
            {
                if (int.TryParse(Console.ReadLine(), out useCount))
                {
                    if (useCount > 0 && useCount <= count)
                    {
                        correctInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"1에서 {count} 사이의 값을 입력하세요.");
                    }
                }
                else
                {
                    Console.WriteLine("유효한 숫자를 입력하세요.");
                }
            }
            while (!correctInput);

            for (int i = 0; i < useCount; i++)
            {
                selectMonster.Heal(30);
                count -= 1;
                if (count <= 0)
                {
                    GameManager.Player.Iteminventory.items.Remove(this);
                    break;
                }
            }
            Console.WriteLine($"{name}을 사용하였습니다. {selectMonster.Name}의 HP가 30 회복되어서 {selectMonster.CurHP}가 되었습니다.");
            Console.ReadKey(true);
        }

    }
}
