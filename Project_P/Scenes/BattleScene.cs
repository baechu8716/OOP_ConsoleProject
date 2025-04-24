using Project_P.Monsters;

namespace Project_P.Scenes
{
    public class BattleScene : BaseScene
    {
        public int turnCount;
        private Stack<string> stack;
        public Monster enemy;
        private Monster playerMonster;
        int index = -1;
        private bool isItemUsed = false;

        public BattleScene()
        {
            name = "Battle";
            turnCount = 0;
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
                case "Inventory":
                    GameManager.Player.Iteminventory.Open();
                    stack.Pop();
                    isItemUsed = GameManager.Player.Iteminventory.isItemUsed;
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
                        GameManager.isBattleOn = false;
                        Console.ReadKey(true);
                        stack.Pop();
                        GameManager.ChangeScene(GameManager.prevSceneName);
                    }
                    break;
                case "SelectMenu":
                    ;
                    if (input == ConsoleKey.D0)
                    {
                        Console.WriteLine("전투를 종료합니다...");
                        Console.ReadKey(true);
                        GameManager.isBattleOn = false;
                        stack.Pop();
                        GameManager.ChangeScene(GameManager.prevSceneName);
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
                            if (selectedMonster != null && selectedMonster.CurHP > 0)
                            {
                                playerMonster = selectedMonster;
                                playerMonster.Position = new Vector2(1, 1);
                                Console.WriteLine($"{playerMonster.Name}. 너로 정했다!");
                                enemy.Position = new Vector2(60, 1);
                                Console.ReadKey(true);
                                stack.Push("Battle");
                            }
                            else if (selectedMonster?.CurHP <= 0)
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
                    if (!isItemUsed) 
                    {
                        if (input == ConsoleKey.D1)
                        {
                            playerMonster.UseSkill(0, enemy);
                            ProcessTurn();
                            Console.ReadKey();
                        }
                        else if (input == ConsoleKey.D2)
                        {
                            playerMonster.UseSkill(1, enemy);
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
                        else if (input == ConsoleKey.E)
                        {
                            stack.Push("Inventory");
                        }
                        else if (input == ConsoleKey.D0)
                        {
                            Console.WriteLine("전투를 종료합니다...");
                            GameManager.isBattleOn = false;
                            Console.ReadKey(true);
                            stack.Pop();
                            GameManager.ChangeScene(GameManager.prevSceneName);
                        }
                    }

                    else
                    {
                        ProcessTurn();
                        Console.ReadKey(true);
                        isItemUsed = false;
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
            Console.WriteLine($"{GameManager.curScene.name} 이전씬 {GameManager.prevSceneName}");
            Console.WriteLine($"야생의 {enemy.Name}(이)가 나타났다!");
            Thread.Sleep(500);
            enemy.Position = new Vector2(1, 2);
            enemy.Print(true);
            Console.SetCursorPosition(1, 30);
            Console.WriteLine("어떻게 할까?");
            Console.WriteLine("1. 싸운다");
            Console.WriteLine("2. 도망간다.");
        }

        private bool AreAllMonstersFainted()
        {
            foreach (var monster in GameManager.Player.Inventory.monsters)
            {
                if (monster != null && monster.CurHP > 0)
                    return false;

            }
            return true;
        }

        public void SelectMenu()
        {

            if (AreAllMonstersFainted())
            {
                Console.WriteLine("모든 몬스터가 전투불능 상태입니다.");
                GameManager.isBattleOn = false;
                Console.ReadKey(true);
                stack.Clear();
                GameManager.ChangeScene(GameManager.prevSceneName);
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

            Console.SetCursorPosition(0, 27);
            Console.WriteLine($"턴 {turnCount + 1}: {playerMonster.Name} vs {enemy.Name}");

            Console.SetCursorPosition(0, 29);
            Console.WriteLine($"{playerMonster.Name}");
            Console.WriteLine($"HP : {playerMonster.CurHP} / {playerMonster.MaxHP} ");

            Console.SetCursorPosition(60, 29);
            Console.WriteLine($"{enemy.Name}");
            Console.SetCursorPosition(60, 29);
            Console.WriteLine($"HP : {enemy.CurHP} / {enemy.MaxHP}");

            Console.SetCursorPosition(0, 34);
            playerMonster.SkillList();
            Console.WriteLine("사용할 기술을 선택하세요(1~4) | E : 인벤토리 열기 | 도망가기는 0");
        }

        public void ProcessTurn()
        {
            Random randomInt = new Random();
            if (enemy.CurHP <= 0)
            {
                Console.SetCursorPosition(0, 44);
                Console.WriteLine($"{enemy.Name}을(를) 쓰러뜨렸습니다!");
                Thread.Sleep(500);
                Console.SetCursorPosition(0, 45);
                playerMonster.LevelUp(enemy);
                Console.ReadKey(true);
                GameManager.isBattleOn = false;
                stack.Clear();
                if (enemy.Name == "칠색조")
                {
                    GameManager.GameOver("보스 몬스터를 잡았습니다. 게임 클리어!");
                }
                else
                {
                    GameManager.ChangeScene(GameManager.prevSceneName);
                }
                this.isItemUsed = false;
                return;
            }
            enemy.UseSkill(randomInt.Next(3), playerMonster);
            if (playerMonster.CurHP <= 0 || (playerMonster.Skills[0].CurPP == 0
                && playerMonster.Skills[1].CurPP == 0
                && playerMonster.Skills[2].CurPP == 0
                && playerMonster.Skills[3].CurPP == 0))
            {
                Console.SetCursorPosition(0, 44);
                Console.WriteLine($"{playerMonster.Name}이(가) 전투 불능이 되었습니다!");
                Thread.Sleep(500);
                Console.ReadKey(true);
                stack.Pop();
                stack.Push("SelectMenu");
                this.isItemUsed = false;
                return;
            }
            turnCount++;
            this.isItemUsed = false;
        }
    }
}
