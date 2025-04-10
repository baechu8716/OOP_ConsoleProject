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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("조작키 : W, A, S, D = 상하좌우 이동 / E = 인벤토리 키");
            Console.WriteLine("도트가 깨질 수도 있으니 전체화면으로 플레이 해주세요.");

        }

        public override void Update()
        {

        }

        public override void Result()
        {
            switch(input)
            {
                case ConsoleKey.D1:
                    GameManager.ChangeScene("Select");
                    break;
                case ConsoleKey.D2:
                    GameManager.GameOver("게임 종료");
                    break;

            }
        }
        
    }
}
