using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Lab5
{
    partial class Enemy : IEntity
    {
        public int HP { get; set; }
        public int MaxHP { get; }
        public bool IsAlive { get; set; }
        public bool MayDie { get; set; }
        public Enemy(int hP, int maxHP, bool isAlive, bool mayDie, int distanceBetweenFrames, int distanceFromLeftBorder, int screenIndex)
        {
            HP = hP;
            MaxHP = maxHP;
            IsAlive = isAlive;
            MayDie = mayDie;
            spriteIndex = 0;
            frameX = 2;
            frameY = 30;
            frameWidth = 114;
            frameHeight = 60;
            framesNumber = 6;
            panelHeight = 100;
            panelWidth = 200;
            leftPanelCorrection = -75;
            rightPanelCorrection = -75;
            this.distanceBetweenFrames = 148;
            this.distanceFromLeftBorder = 2;
            this.screenIndex = screenIndex;

            Sprites = new Bitmap[5];
            Sprites[0] = new Bitmap(Properties.Resources.E1_IDLE);
            Sprites[1] = new Bitmap(Properties.Resources.E1_ATTACK);
            Sprites[2] = new Bitmap(Properties.Resources.E1_HURT);
            Sprites[3] = new Bitmap(Properties.Resources.E1_RUN);
            Sprites[4] = new Bitmap(Properties.Resources.E1_DEATH);

            isLookingRight = movingLeft = movingRight = isAttacking = isJumping = isHurting = false;
        }
    }
}
