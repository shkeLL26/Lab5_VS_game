using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab5
{
    partial class Player : IEntity
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
                SoundHandler.PlayEffect(7);
                currentFrame = 0;
                IsAlive = false;
                movingLeft = movingRight = isAttacking = isJumping = false;
                MessageBox.Show("U dead");
                deathHandler?.Invoke();
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
                    screen.NextScreen();
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
                    if (screen.currentScreenIndex == 0)
                    {
                        IsAlive = false;
                        movingLeft = movingRight = isAttacking = isJumping = false;
                        MessageBox.Show("Hi, Vanis");
                        deathHandler?.Invoke();
                    }
                    screen.PreviosScreen();
                    panelPosition = Tools.MatrixToPanel(matrixPoint);
                }
            }
            matrixPosition = matrixPoint;
            //screen.SetPlayerPosition(matrixPoint);
        }

        public void Run(bool needRunRight)
        {
            isLookingRight = needRunRight;
            if (needRunRight) movingRight = true;
            else movingLeft = true;
            framesNumber = 16;
            spriteIndex = 3;
        }

        public void Attack()
        {
            if (!isAttacking)
            {
                SoundHandler.PlayEffect(0);
                currentFrame = 0;
                movingRight = movingLeft = false;
                framesNumber = 7;
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
                HP -= 20;
                if (HP <= 0)
                {
                    SoundHandler.PlayEffect(7);
                    currentFrame = 0;
                    IsAlive = false;
                    movingLeft = movingRight = isAttacking = isJumping = false;
                    MessageBox.Show("U dead");
                    deathHandler?.Invoke();
                }
            }
        }

        public void Idle()
        {
            if (!isAttacking)
            {
                movingRight = movingLeft = false;
                framesNumber = 10;
                spriteIndex = 0;
            }
        }
     }
}
