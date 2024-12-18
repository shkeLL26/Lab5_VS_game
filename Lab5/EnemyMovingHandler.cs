using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    partial class Enemy : IEntity
    {
        public Action deathHandler { get; set; }
        public Point matrixPosition { get; set; }
        public Point panelPosition { get; set; }
        public int screenIndex { get; set; }
        public GameScreen screen { get; set; }
        public bool isLookingRight { get; set; }

        public bool movingLeft { get; set; }
        public bool movingRight { get; set; }
        public bool isJumping { get; set; }
        public bool isAttacking { get; set; }
        public bool isHurting { get; set; }
        //public bool isDead { get; set; }

        private int attackDelayer = 0;
        public int jumpSpeed = 0;

        public void MovingHandler()
        {
            Point matrixPoint;
            if (screen.GetCollision(Tools.PanelToMatrix(new Point(panelPosition.X + 25, panelPosition.Y + jumpSpeed))) == 0)
            {
                panelPosition = new Point(panelPosition.X, panelPosition.Y + jumpSpeed);
                jumpSpeed += 4;
            }
            else if (screen.GetCollision(Tools.PanelToMatrix(new Point(panelPosition.X + 25, panelPosition.Y + jumpSpeed))) == -1)
            {
                currentFrame = 0;
                IsAlive = false;
                movingLeft = movingRight = isAttacking = isJumping = false;
                SoundHandler.PlayEffect(6);
                if (!screen.trialMode) screen.player.Points += 1;
                else screen.player.Points += 6;
                //MessageBox.Show("U dead");
                //deathHandler?.Invoke();
                return;
            }
            else
            {
                isJumping = false;
                jumpSpeed = 0;
            }
            matrixPoint = Tools.PanelToMatrix(new Point(panelPosition.X + 25, panelPosition.Y));
            if (movingRight && screen.GetCollision(Tools.PanelToMatrix(new Point(panelPosition.X + 25 + 15, panelPosition.Y))) == 0)
            {
                panelPosition = new Point(panelPosition.X + 15, panelPosition.Y);
                matrixPoint = Tools.PanelToMatrix(new Point(panelPosition.X + 25, panelPosition.Y));
                if (matrixPoint.X > 15)
                {
                    matrixPoint = new Point(0, matrixPoint.Y);
                    screenIndex = screen.currentScreenIndex;
                    //screen.NextScreen();
                    //levels++;
                    //textBox2.Text = levels.ToString();
                    panelPosition = Tools.MatrixToPanel(matrixPoint);
                }
            }
            else if (movingLeft && screen.GetCollision(Tools.PanelToMatrix(new Point(panelPosition.X + 25 - 15, panelPosition.Y))) == 0)
            {
                panelPosition = new Point(panelPosition.X - 15, panelPosition.Y);
                matrixPoint = Tools.PanelToMatrix(new Point(panelPosition.X + 25, panelPosition.Y));
                if (matrixPoint.X < 0)
                {
                    matrixPoint = new Point(15, matrixPoint.Y);
                    screenIndex = screen.currentScreenIndex;
                    //screen.PreviosScreen();
                    panelPosition = Tools.MatrixToPanel(matrixPoint);
                }
            }
            matrixPosition = matrixPoint;
        }

        public void Run(bool needRunRight)
        {
            isLookingRight = needRunRight;
            if (needRunRight) movingRight = true;
            else movingLeft = true;
            framesNumber = 8;
            if (currentFrame >= 8) currentFrame = 0;
            spriteIndex = 3;
        }

        public void Attack()
        {
            if (!isAttacking)
            {
                SoundHandler.PlayEffect(1);
                currentFrame = 0;
                movingRight = movingLeft = false;
                framesNumber = 5;
                isAttacking = true;
                spriteIndex = 1;
            }
        }

        public void Hurt()
        {
            if (!isHurting) 
            {
                isHurting = true;
                currentFrame = 0;
                framesNumber = 4;
                spriteIndex = 2;
                //Update();
                HP -= 20;
                if (HP <= 0)
                {
                    SoundHandler.PlayEffect(6);
                    if (!screen.trialMode) screen.player.Points += 2;
                    else screen.player.Points += 6;
                    currentFrame = 0;
                    framesNumber = 6;
                    spriteIndex = 4;
                    //IsAlive = false;
                    movingLeft = movingRight = isAttacking = isJumping = false;
                    //MessageBox.Show("U dead");
                    //deathHandler?.Invoke();
                }
            }
        }

        public void Idle()
        {
            if (!isHurting && !isAttacking)
            {
                if (currentFrame >= 6) currentFrame = 0;
                movingRight = movingLeft = false;
                framesNumber = 6;
                spriteIndex = 0;
            }
        }
    }
}
