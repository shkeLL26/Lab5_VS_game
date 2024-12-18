using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal static class Tools
    {
        public static Point centerXY = new Point(0, 450);
        public static Bitmap Resizer(Bitmap recievedBmp, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(recievedBmp, 0, 0, width, height);
            }
            return resizedImage;
        }

        public static Bitmap GetFrame(int frameWidth, int frameHeight, Point pnt, Bitmap picture)
        {
            Bitmap bmp = new Bitmap(frameWidth, frameHeight);
            Rectangle sourceRect = new Rectangle(pnt.X, pnt.Y, frameWidth, frameHeight);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;
                gr.DrawImage(picture, new RectangleF(0, 0, frameWidth, frameHeight), sourceRect, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        public static Point PanelToMatrix(Point pnt)
        {
            pnt.X = (pnt.X - centerXY.X) / 50;
            pnt.Y = (pnt.Y - centerXY.Y + 50) / -50;
            return pnt;
        }

        public static Point MatrixToPanel(Point pnt)
        {
            if (pnt.X < 0 || pnt.X > 15 || pnt.Y < 0 || pnt.Y > 8) return new Point(-1, -1);
            pnt.X = 50 * pnt.X + centerXY.X;
            pnt.Y = -50 * pnt.Y + centerXY.Y - 50;
            return pnt;
        }
    }
}
