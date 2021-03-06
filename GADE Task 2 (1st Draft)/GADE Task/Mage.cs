using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Mage : Enemy
    {
        public Mage (int inX, int inY, int inMaxHP, int inDamage) : base(inX, inY, inMaxHP, inDamage, GameEngine.GetMageSymbol)
        {

        }

        public override MovementEnum ReturnMove(MovementEnum move)
        {
            return MovementEnum.None;
        }

        public override bool CheckRange(Character target)
        {
            if (DistanceTo(target) <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DistanceTo(Character target)
        {
            // Distances between the x and y positions are calculated separately
            double distanceX = Math.Abs(this.GetX - target.GetX);
            double distanceY = Math.Abs(this.GetY - target.GetY);

            // Overall distance is calculated via Pythagoras' theorem
            int distance = Convert.ToInt32(Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2)));

            return distance;
        }


    }
}
