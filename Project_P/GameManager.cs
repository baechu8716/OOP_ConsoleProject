using Project_P.Monsters;
using Project_P.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P
{
    public static class GameManager
    {
        private static Dictionary<string, BaseScene> sceneDic;
        public static BaseScene curScene;
        public static string prevSceneName;
        private static bool gameOver;
        private static Player player;
        public static Player Player { get { return player; } }

        // 끝날 떄 까지 반복 실행
        public static void Run()
        {
            Start();

            while(gameOver == false)
            {    
                curScene.Render();
                curScene.Input();
                Console.WriteLine();
                curScene.Update();
                Console.WriteLine();
                curScene.Result();
                Console.WriteLine();
                Console.Clear();
            }
            

            End();
        }

        // 게임 초기 설정
        public static void Start()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(150, 30); 
            Console.SetBufferSize(150, 30);

            gameOver = false;

            player = new Player();
            player.Inventory = new Inventory(6);

            sceneDic = new Dictionary<string, BaseScene>();
            sceneDic.Add("Title", new TitleScene());
            sceneDic.Add("Village", new VillageScene());
            sceneDic.Add("Select", new SelectScene());
            sceneDic.Add("Field", new FieldScene());



            // 초기 현재씬 설정
            curScene = sceneDic["Title"];
        }

        // 씬전환
        public static void ChangeScene(string name)
        {
            prevSceneName = curScene.name;
            if (curScene.name == "Village")
            {
                sceneDic.Remove("Select");
            }
            curScene = sceneDic[name];
            curScene.Enter();
        }

        // 게임이 끝났을때
        public static void End()
        {
            gameOver = true;
        }
    }
}
