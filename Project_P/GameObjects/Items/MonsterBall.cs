using Project_P.Monsters;
using Project_P.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.GameObjects.Items
{
    public class MonsterBall : Item
    {
        public MonsterBall(int count, Vector2 position) 
            : base("야생 포켓몬을 잡을 수 있다.", count, "몬스터볼", ConsoleColor.Yellow, position, true)
        {

        }

        public override void Use()
        {
            if (GameManager.curScene is BattleScene battleScene)
            {
                Monster target = battleScene.enemy;
                Console.WriteLine($"{target.Name}을(를) 포획하려고 시도합니다..");
                Thread.Sleep(500);
                if(TryCapture(target))
                {
                    Console.WriteLine($"{target.Name}을(를) 포획했습니다!");
                    for (int i = 0; i < GameManager.Player.Inventory.monsters.Length; i++)
                    {
                        if (GameManager.Player.Inventory.monsters[i] == null)
                        {
                            GameManager.Player.Inventory.monsters[i] = target;
                            break;
                        }
                    }
                    count -= 1;
                    if (count <= 0)
                    {
                        GameManager.Player.Iteminventory.Remove(this);
                    }
                    Console.ReadKey(true);
                    GameManager.ChangeScene("Field");
                    return;
                }
                else
                {
                    Console.WriteLine($"{target.Name}이(가) 몬스터볼에서 빠져나왔습니다");
                    count -= 1;
                    if (count <= 0)
                    {
                        GameManager.Player.Iteminventory.Remove(this);
                    }
                    Console.ReadKey(true);
                }
            }
            else
            {
                Console.WriteLine("몬스터볼은 전투 중에만 사용할 수 있습니다.");
                Console.ReadKey(true);
            }
        }

        private bool TryCapture(Monster target)
        {
            Random ran = new Random();
            int captureChance = (int)((target.MaxHP - target.CurHP) * 100 / target.MaxHP);
            int roll = ran.Next(1, 100);
            return roll <= captureChance;
        }
    }
}
