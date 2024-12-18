using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal interface IEntity
    {
        int HP { get; set; }
        int MaxHP { get; }
        bool IsAlive { get; set; }
        bool MayDie { get; set; }
        Bitmap[] Sprites { get; set; }
        int spriteIndex { get; set; }
        int frameX { get; set; }
        int frameY { get; set; }
        int frameWidth { get; set; }
        int frameHeight { get; set; }
        int panelWidth { get; set; }
        int panelHeight { get; set; }
        int distanceBetweenFrames { get; set; }
        int distanceFromLeftBorder { get; set; }
        int framesNumber { get; set; }
        int currentFrame { get; set; }
        int leftPanelCorrection { get; set; }
        int rightPanelCorrection { get; set; }
        Action deathHandler { get; set; }
        Point matrixPosition { get; set; }
        Point panelPosition { get; set; }
        int screenIndex { get; set; }
        GameScreen screen { get; set; }
        bool isLookingRight { get; set; }

        Bitmap GetFrame();

        void Update();


    }
}
