using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Scenes
{
    public class BattleScene : BaseScene
    {
        public int turnCount;

        public BattleScene()
        {
            name = "Battle";
        }

        public override void Render()
        {
            Console.WriteLine("야생의 {}");
        }

        public override void Result()
        {
            
        }

        public override void Update()
        {
            
        }

        public void SelectMonster()
        {
            
        }
    }
}
