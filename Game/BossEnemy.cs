using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BossEnemy:Enemy
    {
        public override double TotalSpecialPower => 1000;
        public override double SpecialPowerUses
        {
            get
            {
                return 6;
            }
        }
    }
}
