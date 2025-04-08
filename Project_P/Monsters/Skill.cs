using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Monsters
{
    public class Skill
    {
        public string Name { get; set; }
        public int skillDamage { get; set; }
        public int MaxPP { get; set; }
        public int CurPP { get; set; }

        public Skill(string name, int skillDamage, int maxPP)
        {
            Name = name;
            this.skillDamage = skillDamage;
            MaxPP = maxPP;
            CurPP = maxPP;
        }

        // 현재 PP(기술 사용을 위한 포인트)가 없다면 false반환
        public bool CanUse()
        {
            return CurPP > 0;
        }


        public void Use(Monster mine, Monster target)
        {
            if(!CanUse())
            {
                Console.WriteLine($"{Name}의 PP가 부족하여 사용 불가");
                return;
            }
            CurPP--;
            int totalDamage = mine.Atk + skillDamage;
            target.TakeDamaged(totalDamage);
            Console.WriteLine($"{mine.Name}. {Name}!");
            Console.WriteLine($"{target.Name}에게 {totalDamage} 데미지를 입혔습니다.");
            Console.WriteLine($"{Name} (남은 PP: {CurPP}/{MaxPP})");
        }
    }
}
