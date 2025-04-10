using Project_P.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Monsters.Pokemons
{
    public class Nidorino : Monster
    {
        private string[] my = new string[]
        {
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬜⬜⬜⬜",
            "⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛🟪⬛⬜⬜⬜",
            "⬛🟪🟪🟪⬛⬛⬜⬜⬜⬜⬜⬜⬜⬛🟪⬛⬜⬜⬜",
            "⬜⬛⬛🟪🟪🟪⬛⬜⬜⬜⬜⬜⬛🟪🟪⬛⬜⬜⬜",
            "⬛🟪🟪🟦🟦🟪🟪⬛⬜⬜⬛⬜⬛🟪🟪⬛⬜⬜⬜",
            "⬛⬛⬛🟦🟦🟦🟪🟪⬛⬛🟪⬛🟪🟪🟪⬛⬛⬛⬜",
            "⬜⬜⬛🟦🟦🟦⬛🟪⬛⬛🟪⬛⬛🟪⬛⬛🟪🟪⬛",
            "⬜⬜⬛🟦🟦🟦🟦⬛🟪⬛🟪🟪🟪⬛🟪🟪🟪⬛⬜",
            "⬜⬜⬜⬛🟦🟦🟦⬛🟪⬛🟪🟪🟪🟪🟪🟪⬛⬜⬜",
            "⬜⬜⬛🟪⬛⬛🟪🟪🟪🟪🟪🟪🟪🟪🟪⬛⬛⬜⬜",
            "⬜⬜⬛🟪🟪🟪🟪🟪🟪🟪⬛🟪🟪🟪🟪🟪⬛⬜⬜",
            "⬜⬛🟪🟪🟪🟪🟪🟪🟪🟪⬜⬛🟪🟪🟪🟪🟪⬛⬜",
            "⬜⬛🟪🟪🟪🟪🟪🟪🟪🟪⬜⬛⬛🟪🟪🟪🟪⬛⬜",
            "⬜⬛🟪🟪🟪🟪🟪🟪⬛🟪🟪🟪🟪🟪🟪🟪⬛⬜⬜",
            "⬜⬜⬛🟪⬛🟪🟪🟪🟪⬛⬜🟪⬛⬛⬛⬛⬜⬜⬜",
            "⬜⬜⬛⬜⬛⬛🟪🟪🟪🟪⬛⬛⬛⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬛⬛⬛🟪🟪⬛⬛🟪🟪⬛⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬛🟪🟪⬛🟪⬜⬛⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬛🟪🟪⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬛⬜⬜⬛⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜"



        };

        private string[] enemy = new string[]
        {
            "⬜⬜⬜⬜⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬛🟪⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜",
            "⬜⬜⬜⬛🟪⬛⬜⬜⬜⬜⬜⬜⬜⬛⬛🟪🟪🟪⬛",
            "⬜⬜⬜⬛🟪🟪⬛⬜⬜⬜⬜⬜⬛🟪🟪🟪⬛⬛⬜",
            "⬜⬜⬜⬛🟪🟪⬛⬜⬛⬜⬜⬛🟪🟪🟦🟦🟪🟪⬛",
            "⬜⬛⬛⬛🟪🟪🟪⬛🟪⬛⬛🟪🟪🟦🟦🟦⬛⬛⬛",
            "⬛🟪🟪⬛⬛🟪⬛⬛🟪⬛⬛🟪⬛🟦🟦🟦⬛⬜⬜",
            "⬜⬛🟪🟪🟪⬛🟪🟪🟪⬛🟪⬛🟦🟦🟦🟦⬛⬜⬜",
            "⬜⬜⬛🟪🟪🟪🟪🟪🟪⬛🟪⬛🟦🟦🟦⬛⬜⬜⬜",
            "⬜⬜⬛⬛🟪🟪🟪🟪🟪🟪🟪🟪🟪⬛⬛🟪⬛⬜⬜",
            "⬜⬜⬛🟪🟪🟪🟪🟪⬛🟪🟪🟪🟪🟪🟪🟪⬛⬜⬜",
            "⬜⬛🟪🟪🟪🟪🟪⬛⬜🟪🟪🟪🟪🟪🟪🟪🟪⬛⬜",
            "⬜⬛🟪🟪🟪🟪⬛⬛⬜🟪🟪🟪🟪🟪🟪🟪🟪⬛⬜",
            "⬜⬜⬛🟪🟪🟪🟪🟪🟪🟪⬛🟪🟪🟪🟪🟪🟪⬛⬜",
            "⬜⬜⬜⬛⬛⬛⬛🟪⬜⬛🟪🟪🟪🟪⬛🟪⬛⬜⬜",
            "⬜⬜⬜⬜⬜⬛⬛⬛⬛🟪🟪🟪🟪⬛⬛⬜⬛⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬛🟪🟪⬛⬛🟪🟪⬛⬛⬛⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬛⬜🟪⬛🟪🟪⬛⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛🟪🟪⬛⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬛⬜⬜⬛⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜",


        };
        public Nidorino(Vector2 position, int level)
            : base("니드리노", "독", level, 10, 500, ConsoleColor.Yellow, 'N', position)
        // 이름, 타입, 레벨, 공격력, 체력
        {
            AddSkill(new Skill("몸통박치기", 35, 35));
            AddSkill(new Skill("뿔찌르기", 65, 25));
            AddSkill(new Skill("독침", 50, 35));
            AddSkill(new Skill("두번치기", 60, 30));
        }

        // 적일 경우 좌우 대칭하여 출력
        public override void Print(bool isEnemy)
        {
            Console.OutputEncoding = Encoding.UTF8;
            for (int y = 0; y < my.Length; y++)
            {
                Console.SetCursorPosition(Position.x, Position.y + y);

                if (isEnemy)
                {
                    Console.Write(enemy[y]);
                }
                else
                {
                    Console.Write(my[y]);

                }
                Console.WriteLine();
            }
        }
    }
}
