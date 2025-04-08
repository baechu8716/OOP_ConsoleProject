﻿using Project_P.Scenes;
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
        private static BaseScene curScene;
        private static string prevSceneName;
        private static bool gameOver;

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
            

            End();
        }

        // 게임 초기 설정
        public static void Start()
        {
            Console.CursorVisible = false;

            gameOver = false;    

            sceneDic = new Dictionary<string, BaseScene>();
            sceneDic.Add("Title", new TitleScene());
            sceneDic.Add("Village", new VillageScene());

            // 초기 현재씬 설정
            curScene = sceneDic["Title"];
        }

        // 씬전환
        public static void ChangeScene(string name)
        {
            prevSceneName = curScene.name;

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
