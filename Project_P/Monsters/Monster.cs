using Project_P.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        public int MaxHP { get; set; }
        public int CurHP { get; set; }
        public Vector2 Position { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public List<Skill> Skills { get; set; }
        public string scene = "Battle";


        public Monster(string name, string type, int level, int atk, int hp, ConsoleColor color, char symbol, Vector2 position)
            :base(symbol, color, position, true)
        {
            Name = name;
            Type = type;
            Level = level;
            Exp = 100 * level;
            Atk = atk * (int)(level / 2.5);
            MaxHP = hp;
            CurHP = hp;
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
            CurHP -= damage;
            if (CurHP <= 0)
            {
                Console.WriteLine($"{Name}이(가) 쓰려졌습니다..");
                Thread.Sleep(500);
            }
        }
        public void LevelUp(Monster target)
        {
            this.Exp += target.Exp;
            Console.WriteLine($"획득 경험치 : {target.Exp}");
            Thread.Sleep(500);
            if (Level > 99)
            {
                return;
            }
            if ( Exp >= 1000)
            {
                Level += 1;
                Exp -= 1000;
                Atk += 5;
                MaxHP += 20;
                Console.WriteLine($"{Name}이(가) 레벨 {Level}로 올랐습니다!");
                Thread.Sleep(500);
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

        public void SkillList()
        {
            for (int i = 0; i < Skills.Count; i++)
            {
                Console.WriteLine($"[{i+1}] {Skills[i].Name} | 데미지 :  {Skills[i].skillDamage} | PP :{Skills[i].CurPP}/{Skills[i].MaxPP}");
            }
        }

        public void Heal(int amount)
        {
            CurHP += amount;
            if (CurHP > MaxHP)
            {
                CurHP = MaxHP;
            }
        }

        public void PP_Heal(int i)
        {
            Skills[i].CurPP += 5;
            if (Skills[i].CurPP > Skills[i].MaxPP)
            {
                Skills[i].CurPP = Skills[i].MaxPP;
            }
        }
    }
}
