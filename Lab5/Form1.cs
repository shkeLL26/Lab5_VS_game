using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Lab5
{
    public partial class Form1 : Form
    {
        private bool isMenuClosed = false;

        private int levels = 0;

        private GameScreen screen;
        private TextureBrush textureGrass;

        Player player;

        private bool isFinishing = false;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Или FormBorderStyle.Fixed3D
            this.MaximizeBox = false; // Запрет на максимизацию

            buttonPause.Visible = false;
            Tools.centerXY = new Point(0, gamePanel.Height);
            textureGrass = new TextureBrush(Tools.Resizer(Properties.Resources.GrassBlock, 50, 50));
            textureGrass.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            gamePanel.BackgroundImage = Properties.Resources.BackScreen;

            timerAnimation.Interval = 60;
            timerMenu.Interval = 10;

            labelCredits.Text = "A game by shkeLL26 \nAssets by Mattz Art, \nSlavArbuz, Verdant Green, \nFreekins and adwitr \nBig THX XD \n Ver.1.0 2024";

            textBox2.Enabled = false;

            SoundHandler.InitHandler();
            SoundHandler.PlayMusic(0);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            SoundHandler.PlayMusic(2);
            SoundHandler.PlayEffect(4);
            if (screen == null || screen.trialMode == true)
            {
                GameModeInit();
                screen = new GameScreen(player, false);
                player.screen = screen;
            }
            else
            {
                buttonPause.Visible = isMenuClosed = true;
                buttonStart.Enabled = buttonTrial.Enabled = buttonSettings.Enabled = buttonExit.Enabled = false;
                timerMenu.Start();
                timerAnimation.Start();
                gamePanel.Invalidate();
            }
            player.panelPosition = Tools.MatrixToPanel(screen.GetPlayerPosition());
            player.matrixPosition = screen.GetPlayerPosition();
        }

        private void buttonTrial_Click(object sender, EventArgs e)
        {
            SoundHandler.PlayMusic(3);
            SoundHandler.PlayEffect(4);
            if (screen == null || screen.trialMode == false)
            {
                GameModeInit();
                screen = new GameScreen(player, true);
                player.screen = screen;
            }
            else
            {
                buttonPause.Visible = isMenuClosed = true;
                buttonStart.Enabled = buttonTrial.Enabled = buttonSettings.Enabled = buttonExit.Enabled = false;
                timerMenu.Start();
                timerAnimation.Start();
                gamePanel.Invalidate();
            }
            player.panelPosition = Tools.MatrixToPanel(screen.GetPlayerPosition());
            player.matrixPosition = screen.GetPlayerPosition();
        }

        private void GameModeInit()
        {
            levels = 1;

            EntitiesHandler.entities.Clear();
            player = new Player(100, 100, true, true, 96, 29);
            player.deathHandler += GameFinisher;

            progressBar1.Value = player.HP;
            textBox2.Text = levels.ToString();

            timerAnimation.Start();
            timerMenu.Start();

            buttonPause.Visible = isMenuClosed = true;
            buttonStart.Enabled = buttonTrial.Enabled = buttonSettings.Enabled = buttonExit.Enabled = false;
            labelGuide.Text = "A и D - бег. Пробел - прыжок. \nНажатие кнопки мыши - атака.";

            gamePanel.Invalidate();
        }

        private void GameFinisher()
        {
            isFinishing = true;
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SoundHandler.PlayEffect(4);
            FormSettings settings = new FormSettings();
            settings.ShowDialog();
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = Properties.Resources.btnSelected;
            SoundHandler.PlayEffect(3);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackgroundImage = Properties.Resources.Btn;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            SoundHandler.PlayEffect(4);
            timerAnimation.Stop();
            this.Close();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            Pause();
        }

        private void Pause()
        {
            SoundHandler.PlayMusic(0);
            timerMenu.Start();
            timerAnimation.Stop();
            buttonPause.Visible = isMenuClosed = false;
            buttonStart.Enabled = buttonTrial.Enabled = buttonSettings.Enabled = buttonExit.Enabled = true;
        }

        private void timerMenu_Tick(object sender, EventArgs e)
        {
            if (isMenuClosed)
            {
                Size size = new Size(800, mainMenuBox.Size.Height - 10);
                mainMenuBox.Size = size;
                if (mainMenuBox.Size.Height == 0) timerMenu.Stop();
            }
            else
            {
                Size size = new Size(800, mainMenuBox.Size.Height + 10);
                mainMenuBox.Size = size;
                if (mainMenuBox.Size.Height == 450)
                {
                    timerMenu.Stop();
                    buttonStart.Enabled = buttonExit.Enabled = true;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (screen != null) {
                if (e.KeyCode == Keys.P && isMenuClosed) Pause();
                if (e.KeyCode == Keys.D && isMenuClosed && !player.movingLeft && !player.isAttacking) player.Run(true);
                if (e.KeyCode == Keys.E && isMenuClosed) 
                {
                    foreach (IEntity entity in EntitiesHandler.entities) if (entity.screenIndex == screen.currentScreenIndex && entity.IsAlive)
                        {
                            if (player.matrixPosition.X <= entity.matrixPosition.X + 1 && entity.matrixPosition.X - 1 <= player.matrixPosition.X) (entity as Friend).Interact();
                        }
                }
                if (e.KeyCode == Keys.A && isMenuClosed && !player.movingRight && !player.isAttacking) player.Run(false);
                if (e.KeyCode == Keys.L && isMenuClosed && !player.movingLeft && !player.movingRight && !player.isAttacking)
                {
                    player.Hurt();
                }
                if (e.KeyCode == Keys.Space && isMenuClosed && !player.isAttacking && !player.isJumping)
                {
                    player.isJumping = true;
                    player.jumpSpeed = -20;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (isMenuClosed)
            {
                if (e.KeyCode == Keys.Space) return;
                player.Idle();
            }
        }

        private void gamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (isMenuClosed) player.Attack();
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            if (isMenuClosed)
            {
                int[][] matrixScreen = screen.GetFullMatrixScreen();
                for (int i = 0; i < matrixScreen.Length; i++)
                {
                    for (int j = 0; j < matrixScreen[i].Length; j++)
                    {
                        if (matrixScreen[i][j] == 1) DrawBlock(new Point(i, j), textureGrass, e.Graphics, Color.Black, 50, 50);
                        if (matrixScreen[i][j] / 10 == 5 || matrixScreen[i][j] == 5) e.Graphics.DrawImage(Tools.Resizer(Tools.GetFrame(153, 112, new Point(0, 0), Properties.Resources.Cart), 200, 150), Tools.MatrixToPanel(new Point(i, j)));
                        if (matrixScreen[i][j] / 10 == 6 || matrixScreen[i][j] == 6) e.Graphics.DrawImage(Tools.Resizer(Tools.GetFrame(463, 303, new Point(0, 0), Properties.Resources.Arc), 150, 150), Tools.MatrixToPanel(new Point(i, j)));
                    }
                }
                foreach (IEntity entity in EntitiesHandler.entities) 
                    if (entity.screenIndex == screen.currentScreenIndex && entity.IsAlive)
                    {
                        DrawEntity(e.Graphics, entity, true);
                        //DrawBlock(entity.matrixPosition, null, e.Graphics, Color.Red, 50, 100);
                        if (entity is Friend)
                        {
                            if (player.matrixPosition.X <= entity.matrixPosition.X + 1 && entity.matrixPosition.X - 1 <= player.matrixPosition.X)
                            {
                                e.Graphics.DrawImage(Tools.Resizer(Properties.Resources.interact, 80, 100), new Point(Tools.MatrixToPanel(entity.matrixPosition).X - 15, Tools.MatrixToPanel(entity.matrixPosition).Y));
                                //labelGuide.Visible = true;
                                labelGuide.Text = "Нажмите E для взаимодействия. \nВосполнение здоровья стоит 3 монеты.";
                            }
                            else labelGuide.Text = "A и D - бег. Пробел - прыжок. \nНажатие кнопки мыши - атака.";
                        }
                    }
                if (player.IsAlive)
                {
                    DrawEntity(e.Graphics, player, false);
                    //DrawBlock(player.matrixPosition, null, e.Graphics, Color.Red, 50, 100);
                    //e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(player.panelPosition.X, player.panelPosition.Y, 50, 100));
                }
            }
        }

        private void DrawBlock(Point position, Brush fillingBrush, Graphics g, Color recievedColor, int width, int height)
        {
            if (position.X < 0 || position.X > 15 || position.Y < 0 || position.Y > 8) return;
            Size rectSize = new Size(width, height);
            Point positionOnPanel = Tools.MatrixToPanel(position);
            //g.DrawRectangle(new Pen(recievedColor), new Rectangle(positionOnPanel, rectSize));
            if (fillingBrush != null) g.FillRectangle(fillingBrush, new Rectangle(positionOnPanel, rectSize));
        }

        private void DrawEntity(Graphics g, IEntity entity, bool needFlip)
        {
            Bitmap bmp = entity.GetFrame();
            RectangleF destRect;
            if (entity.isLookingRight) destRect = new RectangleF(entity.panelPosition.X + entity.rightPanelCorrection, entity.panelPosition.Y, entity.panelWidth, entity.panelHeight);
            else destRect = new RectangleF(entity.panelPosition.X + entity.leftPanelCorrection, entity.panelPosition.Y, entity.panelWidth, entity.panelHeight);
            if (needFlip) bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            g.DrawImage(bmp, destRect);
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            player.Update();
            textBox2.Text = player.Points.ToString();
            progressBar1.Value = player.HP;
            foreach (IEntity entity in EntitiesHandler.entities) if (screen.currentScreenIndex == entity.screenIndex && entity.IsAlive)
                {
                    entity.Update();
                }
            if (player.IsAlive) player.MovingHandler();
            gamePanel.Invalidate();
            if (isFinishing) 
            {
                timerAnimation.Stop();
                isFinishing = isMenuClosed = false;
                player = null;
                screen = null;
                EntitiesHandler.entities.Clear();
                levels = 0;
                Pause();
                gamePanel.Invalidate();
            }
        }
    }
}
