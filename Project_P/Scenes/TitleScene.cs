using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Scenes
{
    public class TitleScene : BaseScene
    {
        public TitleScene()
        {
            name = "Title";
        }
        public override void Render()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("*                                                 *");
            Console.WriteLine("*                                                 *");
            Console.WriteLine("*                                                 *");
            Console.WriteLine("*                OOP_Project_P                    *");
            Console.WriteLine("*                                                 *");
            Console.WriteLine("*                                                 *");
            Console.WriteLine("*                                                 *");
            Console.WriteLine("***************************************************");
            Console.WriteLine("                1. 게임시작");
            Console.WriteLine("                2. 게임종료");

        }

        public override void Update()
        {

        }

        public override void Result()
        {
            switch(input)
            {
                case ConsoleKey.D1:
                    GameManager.ChangeScene("Village");
                    break;
                case ConsoleKey.D2:
                    GameManager.End();
                    break;

            }
        }
        
    }
}
