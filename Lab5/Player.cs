using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    partial class Player : IEntity
    {
        public int HP { get; set; }
        public int MaxHP { get; }
        public bool IsAlive { get; set; }
        public bool MayDie { get; set; }
        public int Points { get; set; }
        public Player(int hP, int maxHP, bool isAlive, bool mayDie, int distanceBetweenFrames, int distanceFromLeftBorder)
        {
            HP = hP;
            MaxHP = maxHP;
            IsAlive = isAlive;
            MayDie = mayDie;
            Points = 0;
            spriteIndex = 0;
            frameX = 29;
            frameY = 47;
            frameWidth = 68;
            frameHeight = 34;
            framesNumber = 10;
            panelHeight = 100;
            panelWidth = 200;
            leftPanelCorrection = -120;
            rightPanelCorrection = -30;
            this.distanceBetweenFrames = distanceBetweenFrames;
            this.distanceFromLeftBorder = distanceFromLeftBorder;

            Sprites = new Bitmap[4];
            Sprites[0] = new Bitmap(Properties.Resources.P1_IDLE);
            Sprites[1] = new Bitmap(Properties.Resources.P1_ATTACK);
            Sprites[2] = new Bitmap(Properties.Resources.P1_HURT);
            Sprites[3] = new Bitmap(Properties.Resources.P1_RUN);

            movingLeft = movingRight = isAttacking = isJumping = isHurting = false;
        }
    }
}
