using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class NormalEnemy:Enemy
    {

        public override double TotalSpecialPower => 100;
            public override double SpecialPowerUses
            {
                get
                {
                    return 3;
                }
            }
        }
    
}
