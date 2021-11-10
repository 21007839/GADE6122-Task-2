using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    public abstract class Character : Tile
    {
        /// <summary>
        /// Local variables and their respective public accessors
        /// </summary>
        protected int HP;
        public int GetHP { get { return HP; } set { HP = value; } }

        protected int maxHP;
        public int GetMaxHP { get { return maxHP; } set { maxHP = value; } }

        protected int damage;
        public int GetDamage { get { return damage; } set { damage = value; } }

        protected Tile[] vision = new Tile[4];
        public Tile[] GetVision { get { return vision; } set { vision = value; } }

        public enum MovementEnum { None, Up, Down, Left, Right}

        /// <summary>
        /// Character constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        /// <param name="inSymbol"></param>
        public Character(int inX, int inY, char inSymbol) : base(inX, inY, inSymbol)
        {

        }

        /// <summary>
        /// An amount of damage is dealt to a specified target.
        /// The method also checks if the aforementioned damage defeats the target.
        /// (Method overridden by child classes).
        /// </summary>
        /// <param name="target"></param>
        public virtual void Attack(Character target) {}

        /// <summary>
        /// Checks if a target is defeated by an attack
        /// </summary>
        /// <returns></returns>
        public bool IsDead()
        {
            if (HP == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a target is in range of an attack
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public virtual bool CheckRange(Character target)
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

        /// <summary>
        /// Calculates the distance between two characters
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private int DistanceTo(Character target)
        {
            // Distances between the x and y positions are calculated separately
            double distanceX = Math.Abs(this.GetX - target.GetX);
            double distanceY = Math.Abs(this.GetY - target.GetY);

            // Overall distance is calculated via Pythagoras' theorem
            int distance = Convert.ToInt32(Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2)));

            return distance;
        }

        /// <summary>
        /// The hero and enemies are moved one space in the specified direction(s)
        /// </summary>
        /// <param name="move"></param>
        public void Move(MovementEnum move)
        {
            // Checks if a move is possible
            if (move != MovementEnum.None)
            {
                // Creates a temporary Map object
                Map tempMap = Game.ge.GetGameMap;

                // Creates variables for the current position and destination
                int heroX = tempMap.GetHero.GetX;
                int heroY = tempMap.GetHero.GetY;

                int destX = heroX;
                int destY = heroY;

                // Alters the destination co-ordinates according to the parsed direction
                switch (move)
                {
                    case MovementEnum.Up:
                        destY--;
                        break;

                    case MovementEnum.Down:
                        destY++;
                        break;

                    case MovementEnum.Left:
                        destX--;
                        break;

                    case MovementEnum.Right:
                        destX++;
                        break;

                    default:
                        break;
                }

                // New hero position is added to the map array
                tempMap.GetMap[destY, destX] = tempMap.GetMap[heroY, heroX];
                tempMap.GetMap[destY, destX].GetX = destX;
                tempMap.GetMap[destY, destX].GetY = destY;

                // Old position is replaced with an EmptyTile object
                tempMap.GetMap[heroY, heroX] = new EmptyTile(heroY, heroX);

                // Enemies are moved
                // (Code block currently non-functional)
                /*for (int i = 0; i < tempMap.GetEnemies.Length; i++)
                {
                    MovementEnum enemyMove = tempMap.GetEnemies[i].ReturnMove(MovementEnum.None);

                    int enemyX = tempMap.GetEnemies[i].GetX;
                    int enemyY = tempMap.GetEnemies[i].GetY;

                    int enemyDestX = enemyX;
                    int enemyDestY = enemyY;

                    switch (enemyMove)
                    {
                        case MovementEnum.Up:
                            enemyDestY--;
                            break;

                        case MovementEnum.Down:
                            enemyDestY++;
                            break;

                        case MovementEnum.Left:
                            enemyDestX--;
                            break;

                        case MovementEnum.Right:
                            enemyDestX++;
                            break;

                        default:
                            break;
                    }

                    tempMap.GetMap[enemyDestY, enemyDestX] = tempMap.GetMap[enemyY, enemyX];
                    tempMap.GetMap[enemyDestY, enemyDestX].GetX = enemyDestX;
                    tempMap.GetMap[enemyDestY, enemyDestX].GetY = enemyDestY;

                    tempMap.GetMap[enemyY, enemyX] = new EmptyTile(enemyY, enemyX);
                }*/
            }
        }

        /// <summary>
        /// Checks if a movement is valid.
        /// (Method defined by child classes).
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public abstract MovementEnum ReturnMove(MovementEnum move);

        /// <summary>
        /// Represents the object as a formatted string.
        /// (Method defined by child classes).
        /// </summary>
        /// <returns></returns>
        override
        public abstract string ToString();
    }
}
