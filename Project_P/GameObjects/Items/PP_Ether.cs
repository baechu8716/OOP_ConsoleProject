using Project_P.Monsters;

namespace Project_P.GameObjects.Items
{
    public class PP_Ether : Item
    {
        public PP_Ether(int count, Vector2 position)
            : base("포켓몬의 PP를 5 회복시킨다.", count, "PP에이드", ConsoleColor.Magenta, position, true)
        {

        }

        public override void Use()
        {
            int index = -1;
            int useCount = 0;
            Console.WriteLine("PP에이드를 사용할 몬스터를 지정해주세요");
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
            Console.Clear();
            Console.WriteLine($"아이템을 사용할 스킬을 선택하세요 (1 ~ 4)");
            selectMonster.SkillList();
            bool correctInput = false;
            do
            {
                if (int.TryParse(Console.ReadLine(), out useCount))
                {
                    if (useCount > 0 && useCount <= selectMonster.Skills.Count)
                    {
                        correctInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"1에서 {selectMonster.Skills.Count} 사이의 값을 입력하세요.");
                    }
                }
                else
                {
                    Console.WriteLine("유효한 숫자를 입력하세요.");
                }
            }
            while (!correctInput);
            if (selectMonster.Skills[useCount].CurPP >= selectMonster.Skills[useCount].MaxPP)
            {
                Console.WriteLine($"{selectMonster.Name}의 PP가 이미 최대입니다.");
                Console.ReadKey(true);
                return;
            }

            selectMonster.PP_Heal(useCount-1);
            count -= 1;
            if (count <= 0)
            {
                GameManager.Player.Iteminventory.items.Remove(this);

            }

            Console.WriteLine($"{name}을 사용하였습니다. {selectMonster.Skills[useCount].Name}의 PP가 5 회복되어서 {selectMonster.Skills[useCount].CurPP}가 되었습니다.");
            Console.ReadKey(true);
        }
    }
}
