using Project_P.GameObjects;
using Project_P.GameObjects.Items;
using Project_P.Monsters;
using Project_P.Scenes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project_P
{
    public static class GameManager
    {
        private static Dictionary<string, BaseScene>? sceneDic;
        public static BaseScene curScene;
        public static string prevSceneName;
        private static bool gameOver;
        public static Monster CurrentEnemy { get; set; }
        private static Player player;
        public static Player Player { get { return player; } }

        // 끝날 떄 까지 반복 실행
        public static void Run()
        {
            Start();

            while(gameOver == false)
            {
                Console.Clear();
                curScene.Render();
                curScene.Input();
                Console.WriteLine();
                curScene.Update();
                Console.WriteLine();
                curScene.Result();
                Console.WriteLine();  
            }
        }

        // 게임 초기 설정
        public static void Start()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(150, 50); 
            Console.SetBufferSize(150, 50);

            gameOver = false;

            player = new Player();
            player.Inventory = new Inventory(6);
            player.Iteminventory = new ItemInventory();


            sceneDic = new Dictionary<string, BaseScene>();
            sceneDic.Add("Title", new TitleScene());
            sceneDic.Add("Village", new VillageScene());
            sceneDic.Add("Select", new SelectScene());
            sceneDic.Add("Field", new FieldScene());
            sceneDic.Add("Battle", new BattleScene());
            sceneDic.Add("Cave_1", new CaveScene_1());
            sceneDic.Add("Cave_2", new CaveScene_2());
            sceneDic.Add("Boss", new BossScene());


            // 초기 현재씬 설정
            curScene = sceneDic["Title"];
        }

        // 씬전환
        public static void ChangeScene(string name, GameObject obj = null)
        {
            prevSceneName = curScene.name;
            curScene = sceneDic[name];
            if (name == "Battle" && obj is Monster monster)
            {
                CurrentEnemy = monster;
            }
            curScene.Enter();
        }

        // 게임이 끝났을때
        public static void GameOver(string reason)
        {
            Console.Clear();
            Console.WriteLine("************************");
            Console.WriteLine("*         END...       *");
            Console.WriteLine("************************");
            Console.WriteLine();
            Console.WriteLine(reason);

            gameOver = true;
        }
    }
}
