using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            enemy = GameManager.CurrentEnemy;
        }

        public override void Render()
        {
            Console.WriteLine($"야생의 {enemy.Name}가 나타났다!");
            Console.WriteLine("어떻게 할까?");
            Console.WriteLine("1. 싸운다");
            Console.WriteLine("2. 도망간다.");
            Console.WriteLine();
        }    

        public override void Update()
        {
            switch(input)
            {
                case ConsoleKey.D1:
                    BattleStart();
                    break;
                case ConsoleKey.D2:
                    GameManager.ChangeScene("Field");
                    break;
                default: break;
            }
        }
        public override void Result()
        {

        }

        public void BattleStart()
        {
            stack.Push("SelectMenu");

            switch (stack.Peek())
            {
                case "SelectMenu":
                    SelectMenu();
                    break;
                case "Battle":
                    Battle();
                    break;
            }
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
                stack.Pop();
                GameManager.ChangeScene("Field");
                return;
            }

            Console.Clear();
            Console.WriteLine("어느 몬스터를 내보내겠습니까?");
            GameManager.Player.Inventory.PrintAll();
            Console.WriteLine("전투종료를 하시려면 0번");

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
                case ConsoleKey.D0:
                    battleOver = true;
                    stack.Pop();
                    GameManager.ChangeScene("Field");
                    return;
                default:
                    Console.WriteLine("잘못된 입력입니다. 1~6 또는 0을 선택하세요.");
                    break; ;

            }

            if (index >= 0 && index < GameManager.Player.Inventory.monsters.Length)
            {
                Monster selectedMonster = GameManager.Player.Inventory.monsters[index];
                if (selectedMonster != null && selectedMonster.HP > 0)
                {
                    playerMonster = selectedMonster;
                    stack.Pop();
                    stack.Push("Battle");
                    turnCount = 1;
                }
                else
                {
                    Console.WriteLine("해당 몬스터가 전투 불능 상태입니다.");
                }
            }
        }

        public void Battle()
        {
            Console.WriteLine($"턴 {turnCount}: {playerMonster.Name} vs {enemy.Name}");
            playerMonster.UseSkill(0, enemy); // 플레이어 몬스터가 적을 공격
            if (enemy.HP <= 0)
            {
                Console.WriteLine($"{enemy.Name}을(를) 쓰러뜨렸습니다!");
                stack.Pop();
                GameManager.ChangeScene("Field");
                return;
            }
            enemy.UseSkill(0, playerMonster); // 적이 플레이어를 공격
            if (playerMonster.HP <= 0)
            {
                Console.WriteLine($"{playerMonster.Name}이(가) 전투 불능이 되었습니다!");
                stack.Pop();
                SelectMenu(); // 다른 몬스터 선택으로 돌아감
            }
            turnCount++;
        }
    }
}
