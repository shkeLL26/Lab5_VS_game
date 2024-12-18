using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    partial class Friend
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
            return bmp;
        }

        public void Update()
        {

            if (currentFrame >= framesNumber)
            {
                currentFrame = 0;
                SoundHandler.PlayEffect(2);
            }
            frameX = distanceFromLeftBorder + currentFrame * distanceBetweenFrames;
            currentFrame++;
        }
    }
}
