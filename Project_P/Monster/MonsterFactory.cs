using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Monster
{
    public static class MonsterFactory
    {
        public static Monster Create(MonsterType type, Vector2 position)
        {
            switch(type)
            {
                case MonsterType.Charmander:
                    return new Charmander(position);
                default:
                    throw new ArgumentException("알 수 없는 몬스터 타입");
            }
        }
    }
}
