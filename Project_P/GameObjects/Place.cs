using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.GameObjects
{
    public class Place : GameObject
    {
        public string scene;
        public Place(string scene, Vector2 position) : base('◎', ConsoleColor.Blue, position, false)
        {
            this.scene = scene;
        }

        public override void Interact(Player player)
        {
            GameManager.ChangeScene(scene);
        }
    }
}
