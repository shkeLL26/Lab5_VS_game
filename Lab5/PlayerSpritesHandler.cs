using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    partial class Player : IEntity
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
            if (!isLookingRight) bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
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
                    if (movingRight) Run(true);
                    else if (movingLeft) Run(false);
                    else Idle();
                }
                if (isAttacking)
                {
                    isAttacking = false;
                    framesNumber = 10;
                    spriteIndex = 0;
                }
                currentFrame = 0;
            }
            frameX = distanceFromLeftBorder + currentFrame * distanceBetweenFrames;
            currentFrame++;
        }

        public void Update()
        {
            if (isAttacking && currentFrame == 4)
            {
                foreach (IEntity entity in EntitiesHandler.entities) if (entity.screenIndex == screen.currentScreenIndex && entity.IsAlive && entity.MayDie)
                    {
                        if (isLookingRight && matrixPosition.X <= entity.matrixPosition.X && entity.matrixPosition.X < matrixPosition.X + 3) (entity as Enemy).Hurt();
                        if (!isLookingRight && matrixPosition.X >= entity.matrixPosition.X && entity.matrixPosition.X > matrixPosition.X - 3) (entity as Enemy).Hurt();
                    }
            }
            UpdateFrame();
        }
    }
}
