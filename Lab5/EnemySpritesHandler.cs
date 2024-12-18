using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    partial class Enemy : IEntity
    {
        public Bitmap[] Sprites { get; set; }
        public int spriteIndex { get; set; }
        public int frameX { get; set; }
        public int frameY { get; set; }
        public int frameWidth { get; set; }
        public int frameHeight { get; set; }
        public int panelWidth { get; set; }
        public int panelHeight { get; set; }
        public int distanceBetweenFrames { get; set; }
        public int distanceFromLeftBorder { get; set; }
        public int framesNumber { get; set; }
        public int currentFrame { get; set; }
        public int leftPanelCorrection { get; set; }
        public int rightPanelCorrection { get; set; }

        public Bitmap GetFrame()
        {
            Bitmap bmp = new Bitmap(frameWidth, frameHeight);
            Rectangle sourceRect = new Rectangle(frameX, frameY, frameWidth, frameHeight);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;
                gr.DrawImage(Sprites[spriteIndex], new RectangleF(0, 0, frameWidth, frameHeight), sourceRect, GraphicsUnit.Pixel);
            }
            if (isLookingRight) bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return bmp;
        }

        public void UpdateFrame()
        {
            if (currentFrame >= framesNumber)
            {
                if (isHurting)
                {
                    if (spriteIndex == 4) IsAlive = false;
                    isHurting = false;
                    framesNumber = 6;
                    spriteIndex = 0;
                }
                else if (isAttacking)
                {
                    isAttacking = false;
                    framesNumber = 6;
                    spriteIndex = 0;
                }
                currentFrame = 0;
            }
            frameX = distanceFromLeftBorder + currentFrame * distanceBetweenFrames;
            currentFrame++;
        }

        public void Update()
        {
            attackDelayer += 60;
            if (attackDelayer >= 780) attackDelayer = 0;
            if (Math.Abs(matrixPosition.X - screen.GetPlayerPosition().X) >= 0 && Math.Abs(matrixPosition.X - screen.GetPlayerPosition().X) < 3
                && attackDelayer == 0 && !isAttacking && !isHurting)
            {
                Attack();
                if (screenIndex == screen.currentScreenIndex && screen.player.IsAlive && screen.player.MayDie)
                {
                    if (isLookingRight && matrixPosition.X <= screen.player.matrixPosition.X && screen.player.matrixPosition.X < matrixPosition.X + 3) screen.player.Hurt();
                    if (!isLookingRight && matrixPosition.X >= screen.player.matrixPosition.X && screen.player.matrixPosition.X > matrixPosition.X - 3) screen.player.Hurt();
                }
            }
            else
            {
                if (matrixPosition.X - screen.GetPlayerPosition().X > 0 && matrixPosition.X - screen.GetPlayerPosition().X < 8) isLookingRight = false;
                else if (matrixPosition.X - screen.GetPlayerPosition().X < 0 && matrixPosition.X - screen.GetPlayerPosition().X > -8) isLookingRight = true;
                if (matrixPosition.X - screen.GetPlayerPosition().X > 2 && matrixPosition.X - screen.GetPlayerPosition().X < 7 && !isAttacking && !isHurting) Run(false);
                else if (matrixPosition.X - screen.GetPlayerPosition().X < -2 && matrixPosition.X - screen.GetPlayerPosition().X > -7 && !isAttacking && !isHurting) Run(true);
                else Idle();
                if (((movingRight && screen.GetCollision(Tools.PanelToMatrix(new Point(panelPosition.X + 25 + 15, panelPosition.Y + 4))) == 0) ||
                    (movingLeft && screen.GetCollision(Tools.PanelToMatrix(new Point(panelPosition.X + 25 - 15, panelPosition.Y + 4))) == 0) ||
                    (movingRight && screen.GetCollision(Tools.PanelToMatrix(new Point(panelPosition.X + 25 + 15, panelPosition.Y))) == 1) ||
                    (movingLeft && screen.GetCollision(Tools.PanelToMatrix(new Point(panelPosition.X + 25 - 15, panelPosition.Y))) == 1)) && !isAttacking && !isHurting)
                {
                    if (!isJumping)
                    {
                        jumpSpeed = -20;
                        isJumping = true;
                    }
                }
            }
            /* (isAttacking && currentFrame == 2 && screenIndex == screen.currentScreenIndex && screen.player.IsAlive && screen.player.MayDie)
            {
                if (isLookingRight && matrixPosition.X <= screen.player.matrixPosition.X && screen.player.matrixPosition.X < matrixPosition.X + 3) screen.player.Hurt();
                if (!isLookingRight && matrixPosition.X >= screen.player.matrixPosition.X && screen.player.matrixPosition.X > matrixPosition.X - 3) screen.player.Hurt();
            }*/
            UpdateFrame();
            MovingHandler();
        }
    }
}
