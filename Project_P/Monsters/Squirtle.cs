using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Monsters
{
    public class Squirtle : Monster
    {
        private string[] squirtle = new string[]
        {
            "⬜⬜⬜⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬜⬜",
            "⬜⬜⬛🟦🟦🟦🟦⬛⬛⬜⬜⬜⬜⬜⬜⬛🟦🟦🟦🟦⬛⬜",
            "⬜⬛🟦🟦🟦🟦🟦🟦🟦⬛⬛⬜⬜⬜⬛⬛🟦🟦🟦🟦🟦⬛",
            "⬜⬛🟦🟦🟦🟦🟦🟦🟦⬛⬜⬛⬛⬜⬛🟦🟦🟦⬛🟦🟦⬛",
            "⬛🟫🟦🟦🟦🟦🟦🟦🟦🟦⬜🟫⬜⬛🟦🟦🟦⬛🟦🟦🟦⬛",
            "⬛🟦🟦🟦🟦⬜⬛🟦🟦🟦⬜🟫🟫⬜⬛🟦🟦⬛🟦🟦⬛⬜",
            "⬛🟦🟦🟦🟦⬛🟫🟦🟦🟦⬜🟫🟫🟫⬛🟦⬛⬛⬛⬛⬜⬜",
            "⬜⬛🟦🟦🟦⬛🟫🟦🟦🟦⬛⬜⬜🟫🟫⬛⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬛⬛🟦🟦🟦🟦⬛⬛🟦🟦⬜🟫🟫⬛⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬛🟦⬛⬛⬛⬛🟦🟦🟦🟦⬜🟫🟫⬛⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬛⬛🟨🟨⬛🟦🟦🟦⬛⬜🟫🟫⬛⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬛🟨🟨⬛⬛⬛⬛⬜🟫🟫⬛⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬛🟦⬛🟫🟨🟨🟨🟫⬛⬜⬛⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬛⬛⬛⬛🟫🟫🟦⬛⬜⬛⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛🟦⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛🟦🟦🟦⬛⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜"
        };

        private string[] R_squirtle = new string[]
        {
            "⬜⬜⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬜⬜⬜",
            "⬜⬛🟦🟦🟦🟦⬛⬜⬜⬜⬜⬜⬜⬛⬛🟦🟦🟦🟦⬛⬜⬜",
            "⬛🟦🟦🟦🟦🟦⬛⬛⬜⬜⬜⬛⬛🟦🟦🟦🟦🟦🟦🟦⬛⬜",
            "⬛🟦🟦⬛🟦🟦🟦⬛⬜⬛⬛⬜⬛🟦🟦🟦🟦🟦🟦🟦⬛⬜",
            "⬛🟦🟦🟦⬛🟦🟦🟦⬛⬜🟫⬜🟦🟦🟦🟦🟦🟦🟦🟦🟫⬛",
            "⬜⬛🟦🟦⬛🟦🟦⬛⬜🟫🟫⬜🟦🟦🟦⬛⬜🟦🟦🟦🟦⬛",
            "⬜⬜⬛⬛⬛⬛🟦⬛🟫🟫🟫⬜🟦🟦🟦🟫⬛🟦🟦🟦🟦⬛",
            "⬜⬜⬜⬜⬜⬛⬛🟫🟫⬜⬜⬛🟦🟦🟦🟫⬛🟦🟦🟦⬛⬜",
            "⬜⬜⬜⬜⬜⬜⬛🟫🟫⬜🟦🟦⬛⬛🟦🟦🟦🟦⬛⬛⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬛🟫🟫⬜🟦🟦🟦🟦⬛⬛⬛⬛🟦⬛⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬛🟫🟫⬜⬛🟦🟦🟦⬛🟨🟨⬛⬛⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬛🟫🟫⬜⬛⬛⬛⬛🟨🟨⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬛⬜⬛🟫🟨🟨🟨🟫⬛🟦⬛⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬛⬜⬛🟦🟫🟫⬛⬛⬛⬛⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛🟦⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬛🟦🟦🟦⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜",
            "⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜"


        };
        public Squirtle(Vector2 position)
            : base("꼬부기", "물", 1, 0, 10, 100, ConsoleColor.Blue, 'G', position)
        {
            AddSkill(new Skill("몸통 박치기", 35, 35));
            AddSkill(new Skill("거품", 20, 30));
            AddSkill(new Skill("물 대포", 40, 25));
            AddSkill(new Skill("하이드로 펌프", 120, 5));
        }

        // 적일 경우 좌우 대칭하여 출력
        public override void Print(bool isEnemy)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for (int y = 0; y < squirtle.Length; y++)
            {
                Console.SetCursorPosition(Position.x, Position.y + y);

                if (isEnemy)
                {
                    Console.Write(squirtle[y]);                   
                }
                else
                {
                    Console.Write(R_squirtle[y]);
                }
                Console.WriteLine();
            }
        }
    }
}
