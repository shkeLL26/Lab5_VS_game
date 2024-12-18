using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    internal class GameScreen
    {

        List<int[][]> screensList = new List<int[][]>();

        public int currentScreenIndex = 0;

        Random random = new Random();

        public Player player;

        public bool trialMode;

        public GameScreen(Player player, bool needTrial) 
        {
            trialMode = needTrial;
            this.player = player;
            this.player.matrixPosition = new Point(5, 5);
            if (trialMode) TrialScreenInit();
            else StartScreenInit();
        }

        private int[][] GenerateScreen()
        {
            int[][] Screen = new int[16][];
            for (int i = 0; i < Screen.Length; i++)
            {
                Screen[i] = new int[9];
                for (int j = 0; j < Screen[i].Length; j++)
                {
                    if (j == 0)
                    {
                        Screen[i][j] = 0;
                        continue;
                    }
                    else if (i == 0 && j == 8)
                    {
                        Screen[i][j] = -1;
                        continue;
                    }
                    else if (i == 15 && j == 8)
                    {
                        Screen[i][j] = -1;
                        continue;
                    }
                    Screen[i][j] = 0;
                }
            }
            return Screen;
        }

        private bool CheckSpawnConditions(int[][] currentScreen, int row, int col, int objectType)
        {
            switch (objectType)
            {
                case 3: // Кузнец
                    return currentScreen[row][col] == 1 && currentScreen[row - 1][col] == 1 && currentScreen[row][col + 1] == 0 && currentScreen[row - 1][col + 1] == 0;
                case 4: // Enemy
                    return currentScreen[row][col] == 1 && currentScreen[row][col + 1] == 0;
                case 5: // Телега и арка
                    return currentScreen[row][col] == 1 && currentScreen[row - 1][col] == 1 && currentScreen[row - 2][col] == 1 && currentScreen[row][col + 1] == 0 
                        && currentScreen[row - 1][col + 1] == 0 && currentScreen[row - 2][col + 1] == 0 
                        && currentScreen[row - 2][col + 3] != 5 && currentScreen[row - 2][col + 3] != 6
                        && currentScreen[row - 1][col + 3] != 5 && currentScreen[row - 1][col + 3] != 6
                        && currentScreen[row][col + 3] != 5 && currentScreen[row][col + 3] != 6;
                default:
                    return false;
            }
        }

        private void GenerateLevel()
        {
            bool smithSpawned = false;
            bool enemySpawned = false;
            bool cartSpawned = false;
            bool arcSpawned = false;
            int[][] currentScreen = GenerateScreen();
            currentScreen[0][3] = 1;
            currentScreen[1][3] = 1;
            for (int i = 2; i < 14; i++)
            {
                if (currentScreen[i - 1][3] == 0 && currentScreen[i - 2][3] == 0)
                {
                    currentScreen[i][3] = 1;
                    continue;
                }
                currentScreen[i][3] = Spawner(1);
                if (currentScreen[i][3] == 1 && (currentScreen[i - 1][3] == 1 || currentScreen[i - 2][4] == 1))
                {
                    currentScreen[i][4] = Spawner(1);
                }

                if (CheckSpawnConditions(currentScreen, i, 4, 3) && !smithSpawned)
                {
                    currentScreen[i - 1][6] = currentScreen[i - 1][5] = Spawner(3);
                    if (currentScreen[i - 1][5] == 3)
                    {
                        smithSpawned = true;
                        EntitiesHandler.entities.Add(new Friend(100, 100, true, false, 96, 9, currentScreenIndex + 1));
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].screen = this;
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition = new Point(i - 1, 6);
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].panelPosition =
                            Tools.MatrixToPanel(EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition);
                    }
                }
                else if (CheckSpawnConditions(currentScreen, i, 3, 3) && !smithSpawned)
                {
                    currentScreen[i - 1][5] = currentScreen[i - 1][4] = Spawner(3);
                    if (currentScreen[i - 1][5] == 3)
                    {
                        smithSpawned = true;
                        EntitiesHandler.entities.Add(new Friend(100, 100, true, false, 96, 9, currentScreenIndex + 1));
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].screen = this;
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition = new Point(i - 1, 5);
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].panelPosition =
                            Tools.MatrixToPanel(EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition);
                    }
                }

                if (CheckSpawnConditions(currentScreen, i, 4, 4) && !enemySpawned)
                {
                    currentScreen[i][6] = currentScreen[i][5] = Spawner(3);
                    if (currentScreen[i][5] == 3)
                    {
                        enemySpawned = true;
                        EntitiesHandler.entities.Add(new Enemy(100, 100, true, true, 96, 9, currentScreenIndex + 1));
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].screen = this;
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition = new Point(i, 6);
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].panelPosition =
                            Tools.MatrixToPanel(EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition);
                    }
                }
                else if (CheckSpawnConditions(currentScreen, i, 3, 4) && !enemySpawned)
                {
                    currentScreen[i][5] = currentScreen[i][4] = Spawner(3);
                    if (currentScreen[i][5] == 3)
                    {
                        enemySpawned = true;
                        EntitiesHandler.entities.Add(new Enemy(100, 100, true, true, 96, 9, currentScreenIndex + 1));
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].screen = this;
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition = new Point(i, 5);
                        EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].panelPosition =
                            Tools.MatrixToPanel(EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition);
                    }
                }

                if (CheckSpawnConditions(currentScreen, i, 4, 5) && (!cartSpawned && !arcSpawned))
                {
                    int index = random.Next(0, 2) + 5;
                    if (index == 5) cartSpawned = true;
                    else arcSpawned = true;
                    currentScreen[i - 2][7] = Spawner(index);
                }
                else if (CheckSpawnConditions(currentScreen, i, 3, 5) && (!cartSpawned && !arcSpawned))
                {
                    int index = random.Next(0, 2) + 5;
                    if (index == 5) cartSpawned = true;
                    else arcSpawned = true;
                    currentScreen[i - 2][6] = Spawner(index);
                }

            }
            currentScreen[14][3] = 1;
            currentScreen[15][3] = 1;
            screensList.Add(currentScreen);
            //player.Points++;
        }

        private int Spawner(int choice)
        {
            int index = 0;
            switch (choice)
            {
                case 1:
                    index = random.Next(0, 5);
                    if (index == 4) index = 0;
                    else index = 1;
                    return index;
                case 3:
                    index = random.Next(0, 5);
                    if (index == 4) index = 3;
                    else index = 0;
                    return index;
                case 4:
                    index = random.Next(0, 5);
                    if (index == 4) index = 4;
                    else index = 0;
                    return index;
                case 5:
                    index = random.Next(0, 2);
                    if (index == 1) index = 5;
                    else index = 0;
                    return index;
                case 6:
                    index = random.Next(0, 2);
                    if (index == 1) index = 6;
                    else index = 0;
                    return index;
            }
            return 0;
        }

        private void TrialScreenInit()
        {
            //-1 - end screen flag
            //-2 - die zone
            //0 - nothing
            //1 - ground
            //2 - 
            //3 - smith
            //4 - enemy
            //5 - cart
            //6 - arc
            for (int i = 0; i < 3; i++) 
            {
                int[][] currentScreen = GenerateScreen();
                if (i == 0)
                {
                    EntitiesHandler.entities.Add(new Friend(100, 100, true, false, 96, 9, 0));
                    EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].screen = this;
                    EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition = new Point(2, 4);
                    EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].panelPosition =
                        Tools.MatrixToPanel(EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition);
                    currentScreen[2][2] = 1;
                    currentScreen[3][2] = 1;
                    currentScreen[4][2] = 1;
                    currentScreen[5][2] = 1;
                    currentScreen[6][2] = 1;
                    currentScreen[7][3] = 1;

                    currentScreen[10][3] = 1;
                    currentScreen[11][3] = 1;
                    currentScreen[11][6] = 5;
                    currentScreen[12][3] = 1;
                    currentScreen[13][3] = 1;
                    currentScreen[14][3] = 1;
                    currentScreen[15][3] = 1;
                }
                else if (i == 1)
                {
                    currentScreen[0][3] = 1;
                    currentScreen[1][3] = 1;
                    currentScreen[2][3] = 1;
                        
                    currentScreen[5][3] = 1;
                    currentScreen[6][3] = 1;

                    currentScreen[9][3] = 1;
                    currentScreen[10][3] = 1;
                    currentScreen[11][3] = 1;
                    currentScreen[11][6] = 6;
                    currentScreen[12][3] = 1;
                    EntitiesHandler.entities.Add(new Enemy(100, 100, true, true, 96, 9, 1));
                    EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].screen = this;
                    EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition = new Point(12, 5);
                    EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].panelPosition =
                        Tools.MatrixToPanel(EntitiesHandler.entities[EntitiesHandler.entities.Count - 1].matrixPosition);
                    currentScreen[13][3] = 1;
                    currentScreen[14][3] = 1;
                    currentScreen[15][3] = 1;

                    currentScreen[7][6] = 1;
                    currentScreen[8][6] = 1;
                    currentScreen[8][7] = 1;
                    currentScreen[9][6] = 1;
                }
                else if (i == 2)
                {
                    currentScreen[0][3] = 1;
                    currentScreen[1][3] = 1;
                    currentScreen[2][3] = 1;

                    currentScreen[5][3] = 1;
                    currentScreen[6][3] = 1;

                    currentScreen[9][3] = 1;
                    currentScreen[10][3] = 1;
                    currentScreen[11][3] = 1;
                    currentScreen[12][3] = 1;
                    currentScreen[12][4] = 1;
                    currentScreen[13][3] = 1;
                    currentScreen[13][4] = 1;
                    currentScreen[13][5] = 1;
                }
                screensList.Add(currentScreen);
            }
        }

        private void StartScreenInit()
        {
            int[][] currentScreen = GenerateScreen();
            currentScreen[4][3] = 1;
            currentScreen[5][3] = 1;
            currentScreen[6][3] = 1;
            currentScreen[7][3] = 1;

            currentScreen[10][3] = 1;
            currentScreen[10][6] = 6;
            currentScreen[11][3] = 1;
            currentScreen[12][3] = 1;
            currentScreen[13][3] = 1;
            currentScreen[14][3] = 1;
            currentScreen[15][3] = 1;

            screensList.Add(currentScreen);

            //SetPlayerPosition(player.MatrixPosition);
        }

        public int[][] GetFullMatrixScreen()
        {
            return screensList[currentScreenIndex];
        }

        public int GetPositionObject(int x, int y)
        {
            if (x < 0 || x > 15 || y < 0 || y > 8) return -2;
            return screensList[currentScreenIndex][x][y];
        }
        public Point GetPlayerPosition()
        {
            return player.matrixPosition;
        }

        public void NextScreen()
        {
            if (!trialMode && currentScreenIndex + 1 >= screensList.Count) GenerateLevel();
            currentScreenIndex++;
        }

        public void PreviosScreen()
        {
            currentScreenIndex--;
        }

        public int GetCollision(Point newPosition)
        {
            if (newPosition.X > 15 || newPosition.X < 0) return 0;
            if (newPosition.Y > 8 || newPosition.Y - 1 < 0) return -1;
            if (screensList[currentScreenIndex][newPosition.X][newPosition.Y] == 1 || screensList[currentScreenIndex][newPosition.X][newPosition.Y - 1] == 1) return 1;
            else if (screensList[currentScreenIndex][newPosition.X][newPosition.Y] == -2 || screensList[currentScreenIndex][newPosition.X][newPosition.Y - 1] == -2) return 2;
            return 0;
        }

    }
}
