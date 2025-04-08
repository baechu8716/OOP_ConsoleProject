using Project_P.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.GameObjects
{
    public abstract class GameObject : Iinteractable
    {
        public char symbol;
        public ConsoleColor color;
        public Vector2 position;
        public bool isOnce;

        public GameObject(char symbol, ConsoleColor color, Vector2 position, bool IsOnce)
        {
            this.symbol = symbol;
            this.color = color;
            this.position = position;
            this.isOnce = isOnce;
        }

        public void Print()
        {
            Console.SetCursorPosition(position.x, position.y + 1);
            Console.ForegroundColor = color;
            Console.WriteLine(symbol);
            Console.ResetColor();
        }

        public abstract void Interact(Player player);
    }
}
