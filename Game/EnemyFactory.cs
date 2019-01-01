using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class EnemyFactory
    {
        public Enemy Create(string name, bool IsBoss = false)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (IsBoss)
            {
                if (!IsValidBossName(name))
                {
                    throw new EnemyCreationException("{name} is not valid name for a Boss enemy,Boss name must end with King or Queen!!!", name);
                }
                return new BossEnemy()
                {
                    Name = name
                };


            }
            return new NormalEnemy()
            {
                Name = name
            };
        }

            private bool IsValidBossName(string name) => name.EndsWith("King") || name.EndsWith("Queen");

    }
}
   
