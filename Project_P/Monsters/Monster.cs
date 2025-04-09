using Project_P.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project_P.Monsters
{
    public class Monster : GameObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Atk { get; set; }
        public int HP { get; set; }
        public Vector2 Position { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        protected List<Skill> Skills { get; set; }
        public string scene = "Battle";


        public Monster(string name, string type, int level, int exp, int atk, int hp, ConsoleColor color, char symbol, Vector2 position)
            :base(symbol, color, position, true)
        {
            Name = name;
            Type = type;
            Level = level;
            Exp = exp;
            Atk = atk;
            HP = hp;
            Symbol = symbol;
            Color = color;
            Position = position;
            Skills = new List<Skill>();
        }

        public void AddSkill(Skill skill)
        {
            Skills.Add(skill);
        }

        public void UseSkill(int skillIndex, Monster target)
        {
            if (skillIndex >= 0 && skillIndex < Skills.Count)
            {
                if (Skills[skillIndex].CanUse())
                {
                    Skills[skillIndex].Use(this, target);
                }        
            }
            else 
            {
                Console.WriteLine("잘못된 값");
            }
        }

        public void TakeDamaged(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                Console.WriteLine($"{Name}이(가) 쓰려졌습니다..");
            }
        }
        public void LevelUp()
        {
            
            if ( Exp >= 1000)
            {
                Level += 1;
                Exp -= 1000;
                Atk += 5;
                HP += 20;
                Console.WriteLine($"{Name}이(가) 레벨 {Level}로 올랐습니다!");
            }
        }

        public virtual void Print(bool isEnemy = false)
        {
            Console.SetCursorPosition(Position.x, Position.y);
            Console.Write(Symbol);
        }

        public override void Interact(Player player)
        {
            GameManager.ChangeScene(scene, this);
        }
    }
}
