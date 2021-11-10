using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Gold : Item
    {
        private int numGold;
        public int GetNumGold { get { return numGold; } set { numGold = value; } }

        private Random rnd;

        public Gold(int inX, int inY) : base(inX, inY, GameEngine.GetGoldSymbol)
        {
            numGold = rnd.Next(1, 6);
        }

        public override string ToString()
        {
            return null;
        }
    }
}
