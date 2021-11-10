﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    [Serializable]
    public abstract class Enemy : Character
    {
        /// <summary>
        /// Local fields and their respective public accessors
        /// </summary>
        //protected Random rnd = new Random();
        //public Random GetRnd { get { return GetRnd; } set { GetRnd = value; } }

        protected string enemyClass;
        public string GetEnemyClass { get { return enemyClass; } set { enemyClass = value; } }

        /// <summary>
        /// Enemy constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        /// <param name="inMaxHP"></param>
        /// <param name="inDamage"></param>
        /// <param name="inSymbol"></param>
        public Enemy(int inX, int inY, int inMaxHP, int inDamage, char inSymbol) : base(inX, inY, inSymbol)
        {
            HP = inMaxHP;
            maxHP = inMaxHP;
            damage = inDamage;
        }

        /// <summary>
        /// Represents the object as a formatted string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (("" + this.GetSymbol).Equals("G"))
            {
                enemyClass = "Goblin";
            } else if (("" + this.GetSymbol).Equals("M")) {
                enemyClass = "Mage";
            }
            else
            {
                enemyClass = "Undefined";
            }

            return enemyClass + " at [" + GetX + ", " + GetY + "] (HP: " + HP + ") (Damage: " + damage + ")";
        }
    }
}
