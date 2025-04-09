using Project_P.Monsters;

namespace Project_P.Scenes
{
    public class BattleScene : BaseScene
    {
        public int turnCount;
        private bool battleOver;
        private Stack<string> stack;
        private Monster enemy;
        private Monster playerMonster;
        int index = -1;

        public BattleScene()
        {
            name = "Battle";
            turnCount = 0;
            battleOver = false;
            stack = new Stack<string>();
        }
        public override void Enter()
        {
            enemy = GameManager.CurrentEnemy;
            Console.Clear();
        }

        public override void Render()
        {
            if (stack.Count == 0)
            {
                stack.Push("Meet");
            }
            switch (stack.Peek())
            {
                case "Meet":
                    Meet();
                    break;
                case "SelectMenu":
                    SelectMenu();
                    break;
                case "SelectConfirm":
                    SelectConfirm();
                    break;
                case "Battle":
                    Battle();
                    break;

                default: break;
            }
        }

        public override void Update()
        {
            if (stack.Count == 0)
            {
                stack.Push("Meet");
            }
            switch (stack.Peek())
            {
                case "Meet":
                    if (input == ConsoleKey.D1)
                    {
                        stack.Pop();
                        stack.Push("SelectMenu");
                    }
                    else if (input == ConsoleKey.D2)
                    {
                        Console.WriteLine("도망갑니다...");
                        stack.Pop();
                        GameManager.ChangeScene("Field");
                    }
                    break;
                case "SelectMenu":
                    ;
                    if (input == ConsoleKey.D0)
                    {
                        Console.WriteLine("전투를 종료합니다...");
                        stack.Pop();
                        GameManager.ChangeScene("Field");
                    }
                    else
                    {
                        int select = (int)input - (int)ConsoleKey.D1;

                        if (select < 0 || select >= GameManager.Player.Inventory.monsters.Length)
                        {
                            Console.WriteLine("잘못된 입력입니다. 1~6 또는 0을 선택하세요.");
                            Console.ReadKey(true);
                        }
                        else if (GameManager.Player.Inventory.monsters[select] == null)
                        {
                            Console.WriteLine("빈 슬롯입니다. 다시 선택해 주세요");
                            Console.ReadKey(true);
                        }
                        else
                        {

                            index = select;
                            stack.Push("SelectConfirm");
                        }
                    }
                    break;
                case "SelectConfirm":
                    if (input == ConsoleKey.Y)
                    {
                        if (index >= 0 && index < GameManager.Player.Inventory.monsters.Length)
                        {
                            Monster selectedMonster = GameManager.Player.Inventory.monsters[index];
                            if (selectedMonster != null && selectedMonster.HP > 0)
                            {
                                playerMonster = selectedMonster;
                                playerMonster.Position = new Vector2(1, 1);
                                Console.WriteLine($"{playerMonster.Name}. 너로 정했다!");
                                enemy.Position = new Vector2(60, 1);
                                Console.ReadKey(true);
                                stack.Push("Battle");
                            }
                            else if (selectedMonster?.HP <= 0)
                            {
                                Console.WriteLine("해당 몬스터가 전투 불능 상태입니다.");
                                Console.ReadKey(true);
                            }
                        }
                    }
                    else if (input == ConsoleKey.N)
                    {
                        stack.Pop();
                    }
                    else { Console.WriteLine("잘못된 선택입니다."); Console.ReadKey(true); }
                    break;
                case "Battle":
                    if (input == ConsoleKey.D1)
                    {
                        playerMonster.UseSkill(0, enemy);
                        ProcessTurn();
                        Console.ReadKey();
                    }
                    else if (input == ConsoleKey.D2)
                    {
                        playerMonster.UseSkill(1, enemy); ;
                        ProcessTurn();
                        Console.ReadKey();
                    }
                    else if (input == ConsoleKey.D3)
                    {
                        playerMonster.UseSkill(2, enemy);
                        ProcessTurn();
                        Console.ReadKey();
                    }
                    else if (input == ConsoleKey.D4)
                    {
                        playerMonster.UseSkill(3, enemy);
                        ProcessTurn();
                        Console.ReadKey();
                    }
                    break;
                default: break;
            }
        }


        public override void Result()
        {

        }

        public void Meet()
        {
            Console.WriteLine($"야생의 {enemy.Name}(이)가 나타났다!");
            enemy.Position = new Vector2(1, 2);
            enemy.Print(true);
            Console.SetCursorPosition(1, 20);
            Console.WriteLine("어떻게 할까?");
            Console.WriteLine("1. 싸운다");
            Console.WriteLine("2. 도망간다.");
        }

        private bool AreAllMonstersFainted()
        {
            foreach (var monster in GameManager.Player.Inventory.monsters)
            {
                if (monster != null && monster.HP > 0)
                    return false;

            }
            return true;
        }

        public void SelectMenu()
        {

            if (AreAllMonstersFainted())
            {
                Console.WriteLine("모든 몬스터가 전투불능 상태입니다.");
                stack.Clear();
                GameManager.ChangeScene("Field");
                return;
            }
            Console.WriteLine("어느 몬스터를 내보내겠습니까?");
            GameManager.Player.Inventory.PrintAll();
            Console.WriteLine("전투종료를 하시려면 0번");


        }
        public void SelectConfirm()
        {
            Console.WriteLine($"{GameManager.Player.Inventory.monsters[index].Name}를(을) 내보내시겠습니까?");
            Console.WriteLine("Y / N");

        }

        public void Battle()
        {
            playerMonster.Print();
            enemy.Print(true);

            Console.SetCursorPosition(0, 23);
            Console.WriteLine($"턴 {turnCount + 1}: {playerMonster.Name} vs {enemy.Name}");

            Console.SetCursorPosition(0, 25);
            Console.WriteLine($"{playerMonster.Name}");
            Console.WriteLine($"HP : {playerMonster.HP}");

            Console.SetCursorPosition(60, 25);
            Console.WriteLine($"{enemy.Name}");
            Console.SetCursorPosition(60, 26);
            Console.WriteLine($"HP : {enemy.HP}");

            Console.SetCursorPosition(0, 30);
            playerMonster.SkillList();
            Console.WriteLine("사용할 기술을 선택하세요");
            Console.ReadKey(true);  
        }

        public void ProcessTurn()
        {
            Random randomInt = new Random();
            if (enemy.HP <= 0)
            {
                Console.SetCursorPosition(0, 25);
                Console.WriteLine($"{enemy.Name}을(를) 쓰러뜨렸습니다!");
                playerMonster.LevelUp(enemy);
                Console.ReadKey(true);
                stack.Clear();
                GameManager.ChangeScene("Field");
                return;
            }

            enemy.UseSkill(randomInt.Next(3), playerMonster);
            if (playerMonster.HP <= 0)
            {
                Console.SetCursorPosition(0, 25);
                Console.WriteLine($"{playerMonster.Name}이(가) 전투 불능이 되었습니다!");
                Console.ReadKey(true);
                stack.Pop();
                stack.Push("SelectMenu");
                return;
            }

            turnCount++;
        }
    }
}
