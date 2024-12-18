using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    partial class Friend : IEntity
    {
        public int HP { get; set; }
        public int MaxHP { get; }
        public bool IsAlive { get; set; }
        public bool MayDie { get; set; }
        public Friend(int hP, int maxHP, bool isAlive, bool mayDie, int distanceBetweenFrames, int distanceFromLeftBorder, int screenIndex)
        {
            HP = hP;
            MaxHP = maxHP;
            IsAlive = isAlive;
            MayDie = mayDie;
            //Sprites = sprites;
            spriteIndex = 0;
            frameX = distanceBetweenFrames;
            frameY = 24;
            frameWidth = 70;
            frameHeight = 55;
            panelHeight = 100;
            panelWidth = 100;
            leftPanelCorrection = 0;
            rightPanelCorrection = 0;

            Bitmap[] friendSprite = { new Bitmap(Properties.Resources.F1_IDLE) };
            Sprites = friendSprite;
            framesNumber = 7;
            currentFrame = 0;

            this.distanceBetweenFrames = distanceBetweenFrames;
            this.distanceFromLeftBorder = distanceFromLeftBorder;
            this.screenIndex = screenIndex;
        }
    }
}
