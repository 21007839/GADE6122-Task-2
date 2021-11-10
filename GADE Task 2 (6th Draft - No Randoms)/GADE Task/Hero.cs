﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    [Serializable]
    public class Hero : Character
    {
        /// <summary>
        /// Hero constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        public Hero(int inX, int inY) : base(inX, inY, GameEngine.GetHeroSymbol)
        {
            HP = 30;
            damage = 2;
        }

        /// <summary>
        /// An amount of damage is dealt to a specified target.
        /// The method also checks if the aforementioned damage defeats the target.
        /// </summary>
        /// <param name="target"></param>
        public override void Attack(Character target)
        {
            // Checks if the target is in range of the attack
            if (CheckRange(target))
            {
                // Calculates the new HP value
                int oldHP = target.GetHP;
                int newHP = target.GetHP - this.damage;
                target.GetHP = newHP;

                // Checks if the target is defeated
                if (target.IsDead())
                {
                    // Updates the map display if the enemy is defeated
                    Game.ge.GetGameMap.GetMap[target.GetY, target.GetX] = new EmptyTile(target.GetY, target.GetX);

                    // Displays a message showing the enemy was defeated
                    MessageBox.Show("Enemy defeated!\n"
                                  + "Damage dealt: " + oldHP + " -> " + newHP);

                    target.GetSymbol = 'D';
                }
                else
                {
                    // Displays a message showing the enemy was hit but not defeated
                    MessageBox.Show("Enemy hit!\n"
                                  + "Damage dealt: " + oldHP + " -> " + newHP);
                }
            }
            else
            {
                // Displays a message showing the enemy was out of range for the attack
                MessageBox.Show("Enemy out of range!\nHit was unsuccessful.");
            }
        }

        /// <summary>
        /// Checks if a movement is valid.
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public override MovementEnum ReturnMove(MovementEnum move)
        {
            Map tempMap = Game.ge.GetGameMap;

            tempMap.UpdateVision();

            // Checks an inputted movement against the hero's vision array
            switch (move)
            {
                case MovementEnum.Up:
                    if (vision[0].GetSymbol == ' ' || vision[0].GetSymbol == '$')
                    {
                        return MovementEnum.Up;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Down:
                    if (vision[1].GetSymbol == ' ' || vision[1].GetSymbol == '$')
                    {
                        return MovementEnum.Down;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Left:
                    if (vision[2].GetSymbol == ' ' || vision[2].GetSymbol == '$')
                    {
                        return MovementEnum.Left;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case MovementEnum.Right:
                    if (vision[3].GetSymbol == ' ' || vision[3].GetSymbol == '$')
                    {
                        return MovementEnum.Right;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                default:
                    return MovementEnum.None;
            }
        }

        /// <summary>
        /// Represents the object as a formatted string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Player Stats:\n" +
                   "HP: " + HP + "\n" +
                   "Damage: " + damage + "\n" +
                   "Total Gold: " + GetPurse + "\n" +
                   "[" + x + ", " + y + "]";
        }
    }
}
