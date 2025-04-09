using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Monsters
{
    public class Charmander : Monster
    {
        private string[] charmander = new string[]
        {
            "⬜⬜⬜⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬛🟥⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬛🟥🟥⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬛🟥🟥⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬜⬜⬜⬜",
            "⬛🟥🟨🟨🟥⬛⬜⬜⬜⬜⬜⬜⬜⬛🟧🟧🟧🟧⬛⬜⬜⬜",
            "⬛🟥🟨🟨🟥⬛⬜⬜⬜⬜⬜⬜⬛🟧🟧🟧🟧🟧🟧⬛⬜⬜", 
            "⬛🟥🟨🟨🟥⬛⬜⬜⬜⬜⬜⬜⬛🟧🟧🟧🟧🟧🟧⬛⬜⬜", 
            "⬜⬛🟥🟥⬛⬜⬜⬜⬜⬜⬜⬛🟧🟧🟧🟧🟧🟧🟧🟧⬛⬜", 
            "⬜⬜⬛🟧⬛⬜⬜⬜⬜⬜⬜⬛🟧🟧🟧🟧⬛⬜🟧🟧🟧⬛",
            "⬜⬜⬛🟧🟧⬛⬜⬜⬜⬜⬛🟧🟧🟧🟧🟧⬛⬛🟧🟧🟧⬛", 
            "⬜⬜⬛🟧🟧⬛⬜⬜⬜⬜⬛🟧🟧🟧🟧🟧⬛⬛🟧🟧🟧⬛", 
            "⬜⬜⬜⬛🟧🟧⬛⬜⬜⬛🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧⬛⬜", 
            "⬜⬜⬜⬛🟧🟧🟧⬛⬛🟧🟧🟧🟧🟧🟧🟧🟧🟧⬛⬛⬜⬜", 
            "⬜⬜⬜⬜⬛🟧🟧⬛⬛🟧🟧🟧⬛🟧🟧⬛⬛⬛⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬛🟧⬛🟧🟧🟧🟧🟧⬛🟧🟨⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬛⬛🟧🟧🟧⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬛🟧🟧🟧🟧🟨🟨🟨⬛⬜⬛⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬛⬛🟧🟧🟧🟧🟧⬛⬛⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛🟧⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬛⬜🟧⬜⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜"
        };

        private string[] R_charmander = new string[]
        {
             "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬜⬜⬜",
             "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛🟥⬛⬜⬜",
             "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛🟥🟥⬛⬜",
             "⬜⬜⬜⬜⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛🟥🟥⬛⬜",
             "⬜⬜⬜⬛🟧🟧🟧🟧⬛⬜⬜⬜⬜⬜⬜⬜⬛🟥🟨🟨🟥⬛",
             "⬜⬜⬛🟧🟧🟧🟧🟧🟧⬛⬜⬜⬜⬜⬜⬜⬛🟥🟨🟨🟥⬛",
             "⬜⬜⬛🟧🟧🟧🟧🟧🟧⬛⬜⬜⬜⬜⬜⬜⬛🟥🟨🟨🟥⬛",
             "⬜⬛🟧🟧🟧🟧🟧🟧🟧🟧⬛⬜⬜⬜⬜⬜⬜⬛🟥🟥⬛⬜",
             "⬛🟧🟧🟧⬜⬛🟧🟧🟧🟧⬛⬜⬜⬜⬜⬜⬜⬛🟧⬛⬜⬜",
             "⬛🟧🟧🟧⬛⬛🟧🟧🟧🟧🟧⬛⬜⬜⬜⬜⬛🟧🟧⬛⬜⬜",
             "⬛🟧🟧🟧⬛⬛🟧🟧🟧🟧🟧⬛⬜⬜⬜⬜⬛🟧🟧⬛⬜⬜",
             "⬜⬛🟧🟧🟧🟧🟧🟧🟧🟧🟧🟧⬛⬜⬜⬛🟧🟧⬛⬜⬜⬜",
             "⬜⬜⬛⬛🟧🟧🟧🟧🟧🟧🟧🟧🟧⬛⬛🟧🟧🟧⬛⬜⬜⬜",
             "⬜⬜⬜⬜⬛⬛⬛🟧🟧⬛🟧🟧🟧⬛⬛🟧🟧⬛⬜⬜⬜⬜",
             "⬜⬜⬜⬜⬜⬛🟨🟧⬛🟧🟧🟧🟧🟧⬛🟧⬛⬜⬜⬜⬜⬜",
             "⬜⬜⬜⬜⬜⬛🟨🟨🟨⬛⬛🟧🟧🟧⬛⬛⬜⬜⬜⬜⬜⬜",
             "⬜⬜⬜⬜⬛⬜⬛🟨🟨🟨🟧🟧🟧🟧⬛⬜⬜⬜⬜⬜⬜⬜",
             "⬜⬜⬜⬜⬜⬛⬛⬛🟧🟧🟧🟧🟧⬛⬛⬜⬜⬜⬜⬜⬜⬜",
             "⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛🟧⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜",
             "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬜🟧⬜⬛⬜⬜⬜⬜⬜⬜⬜⬜",
             "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜"
        };
        public Charmander(Vector2 position, int level)
            :base("파이리", "불꽃", level, 10, 500, ConsoleColor.Red, 'F', position)
        // 이름, 타입, 레벨, exp, 공격력, 체력
        {
            AddSkill(new Skill("불꽃 세례", 40, 25));
            AddSkill(new Skill("불꽃 방사", 90, 15));
            AddSkill(new Skill("할퀴기", 40, 35));
            AddSkill(new Skill("베어가르기", 70, 15));
        }

        // 적일 경우 좌우 대칭하여 출력
        public override void Print(bool isEnemy)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for (int y = 0; y < charmander.Length; y++)
            {
                Console.SetCursorPosition(Position.x, Position.y + y);

                if (isEnemy)
                {
                    Console.Write(R_charmander[y]);
                }
                else
                {
                    Console.Write(charmander[y]);
                }
                Console.WriteLine();
            }
        }
    }
}
