using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_P.Monsters
{
    public static class MonsterFactory
    {
        public static Monster Create(MonsterType type, Vector2 position, int level)
        {
            switch(type)
            {
                case MonsterType.Charmander:
                    return new Charmander(position, level);
                case MonsterType.Bulbasaur:
                    return new Bulbasaur(position, level);
                case MonsterType.Squirtle:
                    return new Squirtle(position, level);
                default:
                    throw new ArgumentException("알 수 없는 몬스터 타입");
            }
        }
    }
}
