using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    [Serializable]
    public abstract class Item : Tile
    {
        public Item (int inX, int inY, char symbol) : base(inX, inY, symbol)
        {

        }

        public abstract string ToString();
    }
}
