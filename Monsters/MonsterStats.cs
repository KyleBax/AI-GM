using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GM.Monsters
{
    internal class MonsterStats
    {
        public static Monster GetMonsterStats(MonsterName monsterName)
        {
            Monster monster = new Monster();
            switch (monsterName)
            {
                case MonsterName.Goblin:
                    monster.Name = MonsterName.Goblin.ToString();
                    monster.AttackDice = 2;
                    monster.DefendDice = 2;
                    monster.Speed = 4;
                    monster.MaxHitPoints = 1;
                    monster.AttackRange = 10;
                    break;

                case MonsterName.PoisonousSnake:
                    monster.Name = MonsterName.PoisonousSnake.ToString();
                    monster.AttackDice = 2;
                    monster.DefendDice = 1;
                    monster.Speed = 3;
                    monster.MaxHitPoints = 1;
                    monster.AttackRange = 1;
                    break;

                case MonsterName.Rat:
                    monster.Name = MonsterName.Rat.ToString();
                    monster.AttackDice = 1;
                    monster.DefendDice = 1;
                    monster.Speed = 6;
                    monster.MaxHitPoints = 1;
                    monster.AttackRange = 1;
                    break;
                case MonsterName.GiantAnt:
                    monster.Name = MonsterName.GiantAnt.ToString();
                    monster.AttackDice = 2;
                    monster.DefendDice = 3;
                    monster.Speed = 8;
                    monster.MaxHitPoints = 1;
                    monster.AttackRange = 1;
                    break;
                case MonsterName.Zombie:
                    monster.Name = MonsterName.Zombie.ToString();
                    monster.AttackDice = 3;
                    monster.DefendDice = 0;
                    monster.Speed = 2;
                    monster.MaxHitPoints = 1;
                    monster.AttackRange = 1;
                    break;
                case MonsterName.CrazedAdventurer:
                    monster.Name = MonsterName.CrazedAdventurer.ToString();
                    monster.AttackDice = 2;
                    monster.DefendDice = 2;
                    monster.Speed = 10;
                    monster.MaxHitPoints = 3;
                    monster.AttackRange = 1;
                    break;


                default:
                    break;
            }
            return monster;
        }
    }
}
