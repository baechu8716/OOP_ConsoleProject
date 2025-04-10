using Project_P.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project_P
{
    public class Inventory
    {
        public Monster[] monsters { get; set; }
        
        public Inventory(int size)
        {
            monsters = new Monster[size];
        }


        public void PrintAll()
        {
            Console.WriteLine("========포켓몬 목록========");
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] != null)
                {
                    if (monsters[i].CurHP <= 0 )
                    {
                        Console.WriteLine($"{i + 1}. {monsters[i].Name}\t기절상태");
                    }
                    else if ((monsters[i].Skills[0].CurPP == 0
                        && monsters[i].Skills[1].CurPP == 0
                        && monsters[i].Skills[2].CurPP == 0
                        && monsters[i].Skills[3].CurPP == 0))
                    {
                        Console.WriteLine($"{i + 1}. {monsters[i].Name}\t전투불가");
                    }
                    Console.WriteLine($"{i + 1}. {monsters[i].Name}");
                }
                else
                {
                    Console.WriteLine("빈 슬롯");
                }
            }
            Console.WriteLine("==========================");
        }
    }
}
