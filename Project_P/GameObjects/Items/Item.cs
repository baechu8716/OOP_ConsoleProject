using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.GameObjects.Items
{
    public abstract class Item : GameObject
    {
        public string name;
        public int count;
        public string info;
        public Item(string info, int count, string name, ConsoleColor color, Vector2 position, bool isOnce) : base('I', color, position, isOnce)
        {
            this.name = name;
            this.count = count;
            this.info = info;
        }

        public override void Interact(Player player)
        {
            player.Iteminventory.Add(this);
        }
        public virtual void Interact(Player player, int count)
        {
            this.count = count;
            player.Iteminventory.Add(this);
        }

        public abstract void Use();
    }
}
