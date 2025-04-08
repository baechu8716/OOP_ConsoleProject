using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Monster
{
    public class Bulbasaur : Monster
    {
        private string[] bulbasaur = new string[]
        {
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜   ",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛🟩🟩🟩⬛⬜⬜⬜⬜  ",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛🟩🟩🟩⬛⬜⬜⬜⬜  ",
            "⬜⬜⬜⬜⬜⬜⬜⬛⬛🟩🟩🟩🟩🟩🟩🟩⬛⬛⬜⬜ ", 
            "⬜⬜⬜⬛⬜⬜⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛⬜",  
            "⬜⬜⬛🟦⬛⬛⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛",  
            "⬜⬜⬛🟦🟦🟦⬛⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩⬛",   
            "⬜⬜⬛🟦🟦🟦🟦🟦⬛🟩🟩🟩🟩🟩🟩🟩🟩🟩🟩" ,  
            "⬜⬛🟦🟦🟦🟦🟦🟦🟦⬛⬛⬛🟩🟩🟩🟩🟩🟩⬛⬜",  
            "⬛⬛🟦🟦🟦🟦🟦🟦🟦🟦🟦⬛🟩🟩🟩⬛⬛⬛⬛⬜",  
            "⬛⬛🟦🟦🟦🟦🟦🟦🟦🟦⬛🟦⬛⬛⬛🟦🟦🟦⬛⬜",  
            "⬛🟦🟦🟦🟦🟦🟦⬛⬛🟦🟦🟦🟦🟦🟦⬛🟦⬜⬛⬜",  
            "⬛🟦🟦🟦🟦🟦⬛🟥⬜⬜🟦🟦⬛🟦🟦⬛⬛⬛⬜⬜",  
            "⬜⬛🟦🟦🟦🟦⬛🟥⬜🟦🟦⬛🟦🟦⬛⬜⬜⬜⬜⬜ ", 
            "⬜⬜⬛⬛🟦🟦🟦🟦🟦🟦⬛🟦🟦🟦⬛⬜⬜⬜⬜⬜ ", 
            "⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬜🟦⬜⬛⬜⬜⬜⬜⬜   ",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜   "
        };
        public Bulbasaur(Vector2 position)
            : base("이상해씨", "풀", 1, 0, 10, 100, ConsoleColor.Green, 'E', position)
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
                    string enemy = new string(bulbasaur[y].Reverse().ToArray());
                    Console.WriteLine(enemy);
                }
                else
                {
                    Console.WriteLine(bulbasaur[y]);
                }

                Console.ResetColor();
            }
        }
    }
}
