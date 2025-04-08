using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Monster
{
    public class Skill
    {
        public string Name { get; set; }
        public int skillDamage { get; set; }

        public Skill(string name, int skillDamage)
        {
            Name = name;
            this.skillDamage = skillDamage;
        }

        public void Use(Monster mine, Monster target)
        {
            int totalDamage = mine.Atk + skillDamage;
            target.TakeDamaged(totalDamage);
            Console.WriteLine($"{mine.Name}. {Name}!");
            Console.WriteLine($"{target.Name}에게 {totalDamage} 데미지를 입혔습니다.");
        }
    }
}
