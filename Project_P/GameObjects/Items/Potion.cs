using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_P.GameObjects.Items
{
    public class Potion : Item
    {
        public Potion(int count, Vector2 position) 
            : base("포켓몬의 체력을 30 회복시킨다.", count,"상처약",ConsoleColor.Magenta, position, true)
        {

        }

        public override void Use()
        {
            
        }
        public override void Use(Monster monster, int useCount)
        {
            for (int i = 0; i < useCount; i++)
            {
                monster.Heal(30);
                count -= 1;
                if (count <= 0)
                {
                    GameManager.Player.Iteminventory.Remove(this);
                    break;
                }
            }
        }
    }
}
