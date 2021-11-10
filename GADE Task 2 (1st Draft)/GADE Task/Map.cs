using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    public class Map
    {
        /// <summary>
        /// Local fields and their respective public accessors
        /// </summary>
        private Tile[,] map;
        public Tile[,] GetMap { get { return map; } set { map = value; } }

        private Hero hero;
        public Hero GetHero { get { return hero; } set { hero = value; } }

        private Enemy[] enemies;
        public Enemy[] GetEnemies { get { return enemies; } set { enemies = value; } }

        private int count = 0;

        private int width;
        public int GetWidth { get { return width; } set { width = value; } }

        private int height;
        public int GetHeight { get { return height; } set { height = value; } }

        private Random rnd;
        public Random GetRnd { get { return rnd; } set { rnd = value; } }

        /// <summary>
        /// Map constructor
        /// </summary>
        /// <param name="minWidth"></param>
        /// <param name="maxWidth"></param>
        /// <param name="minHeight"></param>
        /// <param name="maxHeight"></param>
        /// <param name="numEnemies"></param>
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies)
        {
            // Randomises the size of the map based on the given parameters
            rnd = new Random();

            width = rnd.Next(minWidth, maxWidth + 1);
            height = rnd.Next(minHeight, maxHeight + 1);

            map = new Tile[height, width];

            // Instantiates the enemy array
            enemies = new Enemy[numEnemies];

            // Fills the map with EmptyTile objects
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = new EmptyTile(i, j);
                }
            }

            // Borders the map with Obstacle objects
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height- 1)
                    {
                        map[i, j] = new Obstacle(i, j);
                    }
                    else
                    {
                        if (j == 0 || j == width - 1)
                        {
                            map[i, j] = new Obstacle(i, j);
                        }
                    }
                }
            }

            // Creates a Hero object
            Tile temp = Create(Tile.TileType.Hero);
            map[hero.GetY, hero.GetX] = temp;

            // Creates a specified number of Enemy objects
            for (int i = 0; i < numEnemies; i++)
            {
                temp = Create(Tile.TileType.Enemy);
                map[enemies[i].GetY, enemies[i].GetX] = temp;
            }

            // Updates the visions arrays of the hero and enemies
            UpdateVision();
        }

        /// <summary>
        /// Updates the vision arrays of all the characters on the map
        /// </summary>
        public void UpdateVision()
        {
            // Updates the hero's vision array
            Tile[] currentHeroVision = new Tile[4];

            int currentHeroX = hero.GetX;
            int currentHeroY = hero.GetY;

            currentHeroVision[0] = map[currentHeroY - 1, currentHeroX];
            currentHeroVision[1] = map[currentHeroY + 1, currentHeroX];
            currentHeroVision[2] = map[currentHeroY, currentHeroX - 1];
            currentHeroVision[3] = map[currentHeroY, currentHeroX + 1];

            hero.GetVision = currentHeroVision;

            // Updates the enemies' vision arrays
            Tile[] currentEnemyVision = new Tile[4];

            int currentEnemyX;
            int currentEnemyY;

            for (int i = 0; i < enemies.Length; i++)
            {
                currentEnemyX = enemies[i].GetX;
                currentEnemyY = enemies[i].GetY;

                currentEnemyVision[0] = map[currentEnemyY - 1, currentEnemyX];
                currentEnemyVision[1] = map[currentEnemyY + 1, currentEnemyX];
                currentEnemyVision[2] = map[currentEnemyY, currentEnemyX - 1];
                currentEnemyVision[3] = map[currentEnemyY, currentEnemyX + 1];

                enemies[i].GetVision = currentEnemyVision;
            }
        }

        /// <summary>
        /// Creates a Tile object of a specified type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Tile Create(Tile.TileType type)
        {
            int posX;
            int posY;

            bool found = false;

            // Checks what type is being created
            if (("" + type).Equals("Hero"))
            {
                // Assigns a value to the Hero object
                posX = rnd.Next(1, width - 1);
                posY = rnd.Next(1, height - 1);

                hero = new Hero(posX, posY);

                return hero;
            }
            else if (("" + type).Equals("Enemy"))
            {
                // Assigns values to the Goblin objects
                // Also checks that unique co-oridinates are chosen so that no character is overridden
                do
                {
                    posX = rnd.Next(1, width - 1);
                    posY = rnd.Next(1, height - 1);

                    if (map[posY, posX].GetSymbol == ' ')
                    {
                        enemies[count] = new Goblin(posX, posY, 10, 1);
                        count++;
                        found = true;
                    }
                }
                while (!found);

                return enemies[count - 1];
            }
            else
            {
                return null;
            }
        }
    }
}
