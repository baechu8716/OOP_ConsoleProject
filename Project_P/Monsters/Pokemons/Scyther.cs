using Project_P.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Monsters.Pokemons
{
    public class Scyther : Monster
    {
        private string[] my = new string[]
        {
            "⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬛⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬛🟩🟩⬛⬛🟩⬛⬜⬜⬜⬜",
            "⬛⬛⬜⬜⬜⬛⬛⬛⬛🟩🟩🟩🟩⬛🟩⬛⬜⬜⬜",
            "⬛🟩⬛⬛⬜⬛🟩🟩🟩⬛🟩🟩🟩⬛🟩⬛⬛⬜⬜",
            "⬛🏻🟩🟩⬛⬜⬛🟩🟩🟩⬛🟩🟩🟩⬛🟩⬛⬜⬜",
            "⬛🟧🏻🟩🟩⬛⬛⬛⬛🟩🟩🟩🟩🟩🟩🟩⬛⬜⬜",
            "⬜⬛🏻🏻🟩⬛🟩🟩🟩⬛🟩🟩🟩🟩🟩🟩🟩⬛⬜",
            "⬜⬛🟧🏻🟩⬛⬛🟩🟩⬜⬛⬛🟩🟩🟩🟩🟩⬛⬜",
            "⬜⬜⬛🟧⬛🟩🟩⬛🟩⬜⬛⬜⬛🟩🟩🟩⬛⬜⬜",
            "⬜⬜⬜⬛⬛⬛🟩🟩⬛⬛⬜🟩🟩🟩🟩🟩⬛⬛⬜",
            "⬜⬜⬛🟩🟩🟩⬛🟩⬛🟧⬛⬛🟩🟩🟩⬛🏽🟩⬛",
            "⬜⬜⬛⬜⬜🟩⬛⬛🟩🟩🟩🟩⬛⬛⬛⬛🏽🟩⬛",
            "⬜⬜⬜⬛⬜⬜🟩⬛🟧🟧⬛⬛🟩🟩⬛⬛🏽🏽⬛",
            "⬜⬜⬜⬜⬛⬜⬜🟩⬛⬛🟩🟩⬛⬛⬜⬛⬛🏽⬛",
            "⬜⬜⬜⬛⬛🏽⬜🟩⬛🟩⬛⬛🟩🟩⬛⬜⬛🏽⬛",
            "⬜⬜⬜⬛🟩⬛⬜⬛⬛⬛⬛🟩🟩🏽⬛⬜⬜⬛⬜",
            "⬜⬜⬛🟩🟩⬛⬜⬛⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬛🏽🟩🏽⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜"

        };

        private string[] enemy = new string[]
        {
            "⬜⬜⬜⬜⬜⬛⬛⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬛🟩⬛⬛🟩🟩⬛⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬛🟩⬛🟩🟩🟩🟩⬛⬛⬛⬛⬜⬜⬜⬛⬛",
            "⬜⬜⬛⬛🟩⬛🟩🟩🟩⬛🟩🟩🟩⬛⬜⬛⬛🟩⬛",
            "⬜⬜⬛🟩⬛🟩🟩🟩⬛🟩🟩🟩⬛⬜⬛🟩🟩🏻⬛",
            "⬜⬜⬛🟩🟩🟩🟩🟩🟩🟩⬛⬛⬛⬛🟩🟩🏻🟧⬛",
            "⬜⬛🟩🟩🟩🟩🟩🟩🟩⬛🟩🟩🟩⬛🟩🏻🏻⬛⬜",
            "⬜⬛🟩🟩🟩🟩🟩⬛⬛⬜🟩🟩⬛⬛🟩🏻🟧⬛⬜",
            "⬜⬜⬛🟩🟩🟩⬛⬜⬛⬜🟩⬛🟩🟩⬛🟧⬛⬜⬜",
            "⬜⬛⬛🟩🟩🟩🟩🟩⬜⬛⬛🟩🟩⬛⬛⬛⬜⬜⬜",
            "⬛🟩🏽⬛🟩🟩🟩⬛⬛🟧⬛🟩⬛🟩🟩🟩⬛⬜⬜",
            "⬛🟩🏽⬛⬛⬛⬛🟩🟩🟩🟩⬛⬛🟩⬜⬜⬛⬜⬜",
            "⬛🏽🏽⬛⬛🟩🟩⬛⬛🟧🟧⬛🟩⬜⬜⬛⬜⬜⬜",
            "⬛🏽⬛⬛⬜⬛⬛🟩🟩⬛⬛🟩⬜⬜⬛⬜⬜⬜⬜",
            "⬛🏽⬛⬜⬛🟩🟩⬛⬛🟩⬛🟩⬜🏽⬛⬛⬜⬜⬜",
            "⬜⬛⬜⬜⬛🏽🟩🟩⬛⬛⬛⬛⬜⬛🟩⬛⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬛⬜⬛🟩🟩⬛⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛🏽🟩🏽⬛⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜"


        };
        public Scyther(Vector2 position, int level)
            : base("스라크", "벌레", level, 10, 500, ConsoleColor.Green, 'S', position)
        // 이름, 타입, 레벨, 공격력, 체력
        {
            AddSkill(new Skill("전광석화", 40, 30));
            AddSkill(new Skill("베어가르기", 70, 20));
            AddSkill(new Skill("로케트박치기", 100, 15));
            AddSkill(new Skill("날개치기", 35, 35));
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
