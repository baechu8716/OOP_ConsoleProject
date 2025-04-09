using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Scenes
{
    public abstract class BaseScene
    {
        public string name;
        protected ConsoleKey input;

        public abstract void Render();

        public void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public void ResetInput()
        {
            input = default(ConsoleKey);
        }
        public abstract void Update();

        public abstract void Result();

        public virtual void Enter() { }
    }
}
