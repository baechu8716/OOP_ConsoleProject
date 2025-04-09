using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Monsters
{
    public class Bulbasaur : Monster
    {
        private string[] bulbasaur = new string[]
        {
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛🟩🟩🟩⬛⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛🟩🟩🟩⬛⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬛⬛🟩🟩🟩🟩🟩🟩🟩⬛⬛⬜⬜", 
            "⬜⬜⬜⬛⬜⬜⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛⬜",  
            "⬜⬜⬛🟦⬛⬛⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛",  
            "⬜⬜⬛🟦🟦🟦⬛⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛",
            "⬜⬜⬛🟦🟦🟦🟦🟦⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛" ,  
            "⬜⬛🟦🟦🟦🟦🟦🟦🟦⬛⬛⬛🟩🟩🟩🟩🟩🟩⬛⬜",  
            "⬛⬛🟦🟦🟦🟦🟦🟦🟦🟦🟦⬛🟩🟩🟩⬛⬛⬛⬛⬜",  
            "⬛⬛🟦🟦🟦🟦🟦🟦🟦🟦⬛🟦⬛⬛⬛🟦🟦🟦⬛⬜",  
            "⬛🟦🟦🟦🟦🟦🟦⬛⬛🟦🟦🟦🟦🟦🟦⬛🟦⬜⬛⬜",  
            "⬛🟦🟦🟦🟦🟦⬛🟥⬜⬜🟦🟦⬛🟦🟦⬛⬛⬛⬜⬜",  
            "⬜⬛🟦🟦🟦🟦⬛🟥⬜🟦🟦⬛🟦🟦⬛⬜⬜⬜⬜⬜", 
            "⬜⬜⬛⬛🟦🟦🟦🟦🟦🟦⬛🟦🟦🟦⬛⬜⬜⬜⬜⬜", 
            "⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬜🟦⬜⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜"
        };

        private string[] R_bulbasaur = new string[]
        {
            "⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬛🟩🟩🟩⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬛🟩🟩🟩⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬛⬛🟩🟩🟩🟩🟩🟩🟩⬛⬛⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛⬜⬜⬛⬜⬜⬜",
            "⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛⬛⬛🟦⬛⬜⬜",
            "⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛⬛🟦🟦🟦⬛⬜⬜",
            "⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛🟦🟦🟦🟦🟦⬛⬜⬜",
            "⬜⬛🟩🟩🟩🟩🟩🟩⬛⬛⬛🟦🟦🟦🟦🟦🟦🟦⬛⬜",
            "⬜⬛⬛⬛⬛🟩🟩🟩⬛🟦🟦🟦🟦🟦🟦🟦🟦🟦⬛⬛",
            "⬜⬛🟦🟦🟦⬛⬛⬛🟦⬛🟦🟦🟦🟦🟦🟦🟦🟦⬛⬛",
            "⬜⬛⬜🟦⬛🟦🟦🟦🟦🟦🟦⬛⬛🟦🟦🟦🟦🟦🟦⬛",
            "⬜⬜⬛⬛⬛🟦🟦⬛🟦🟦⬜⬜🟥⬛🟦🟦🟦🟦🟦⬛",
            "⬜⬜⬜⬜⬜⬛🟦🟦⬛🟦🟦⬜🟥⬛🟦🟦🟦🟦⬛⬜",
            "⬜⬜⬜⬜⬜⬛🟦🟦🟦⬛🟦🟦🟦🟦🟦🟦⬛⬛⬜⬜",
            "⬜⬜⬜⬜⬜⬛⬜🟦⬜⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜"

        };
        public Bulbasaur(Vector2 position, int level)
            : base("이상해씨", "풀", level, 10, 500, ConsoleColor.Green, 'E', position)
            // 이름, 타입, 레벨, exp, 공격력, 체력
        {
            AddSkill(new Skill("몸통 박치기", 35, 35));
            AddSkill(new Skill("덩쿨 채찍", 35, 10));
            AddSkill(new Skill("잎날 가르기", 55, 25));
            AddSkill(new Skill("솔라빔", 120, 10));
        }

        // 적일 경우 좌우 대칭하여 출력
        public override void Print(bool isEnemy)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for (int y = 0; y < bulbasaur.Length; y++)
            {
                Console.SetCursorPosition(Position.x, Position.y + y);

                if (isEnemy)
                {
                    Console.Write(bulbasaur[y]);
                }
                else
                {
                    Console.Write(R_bulbasaur[y]);

                }
                Console.WriteLine();
            }
        }
    }
}
