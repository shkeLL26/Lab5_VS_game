using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    partial class Friend : IEntity
    {
        public Action deathHandler {  get; set; }
        public Point matrixPosition { get; set; }
        public Point panelPosition { get; set; }
        public int screenIndex { get; set; }
        public GameScreen screen { get; set; }
        public bool isLookingRight { get; set; }

        public void Interact()
        {
            if (screen.player.HP < 100 && screen.player.Points >= 3)
            {
                screen.player.HP += 50;
                screen.player.Points -= 3;
                if (screen.player.HP > 100) screen.player.HP = 100;
            }
        }
    }
}
