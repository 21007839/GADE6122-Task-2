using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class GameEngine
    {
        /// <summary>
        /// Local fields and their respective public accessors
        /// </summary>
        private Map gameMap;
        public Map GetGameMap { get { return gameMap; } set { gameMap = value; } }

        private static char heroSymbol = 'H';
        public static char GetHeroSymbol { get { return heroSymbol; } }

        private static char emptySymbol = ' ';
        public static char GetEmptySymbol { get { return emptySymbol; } }

        private static char goblinSymbol = 'G';
        public static char GetGoblinSymbol { get { return goblinSymbol; } }

        private static char obstacleSymbol = '#';
        public static char GetObstacleSymbol { get { return obstacleSymbol; } }

        private static char goldSymbol = 'G';
        public static char GetGoldSymbol { get { return goldSymbol; } }

        private static char mageSymbol = 'M';
        public static char GetMageSymbol { get { return mageSymbol; } }

        /// <summary>
        /// GameEngine constructor
        /// </summary>
        /// <param name="minWidth"></param>
        /// <param name="maxWidth"></param>
        /// <param name="minHeight"></param>
        /// <param name="maxHeight"></param>
        /// <param name="numEnemies"></param>
        public GameEngine(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies)
        {
            gameMap = new Map(minWidth, maxWidth, minHeight, maxHeight, numEnemies);
        }

        /// <summary>
        /// Moves the player in a specified direction and all the enemies in random directions
        /// </summary>
        /// <param name="direction"></param>
        public void MovePlayer(Character.MovementEnum direction)
        {
            gameMap.GetHero.Move(gameMap.GetHero.ReturnMove(direction));
            gameMap.UpdateVision();
        }

        /// <summary>
        /// Represents the map in a formatted string
        /// </summary>
        /// <returns></returns>
        override
        public string ToString()
        {
            string st = "";

            for (int i = 0; i < gameMap.GetHeight; i++)
            {
                for (int j = 0; j < gameMap.GetWidth; j++)
                {
                    st += gameMap.GetMap[i, j].GetSymbol + " ";
                }
                st += "\n";
            }
            return st;
        }
    }
}
