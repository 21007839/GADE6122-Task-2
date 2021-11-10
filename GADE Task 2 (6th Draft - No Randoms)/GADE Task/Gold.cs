using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    [Serializable]
    public class Gold : Item
    {
        private int numGold;
        public int GetNumGold { get { return numGold; } set { numGold = value; } }

        //private Random rnd = new Random();

        public Gold(int inX, int inY) : base(inX, inY, GameEngine.GetGoldSymbol)
        {
            //numGold = rnd.Next(1, 6);
            numGold = 1;
        }

        public override string ToString()
        {
            return null;
        }
    }
}
