using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BreakOutGameCSharp
{
        class Ball
    {
        const int BALL_SPEED = 10, WIDTH = 20, HEIGHT = 20;

        public double angle;

        public Rectangle rect;

        public Image image = Properties.Resources.ResourceManager.GetObject("ball_red") as Image;

        public Ball(int x, int y)
        {
            rect = new Rectangle(x, y, WIDTH, HEIGHT);
            this.angle = -45;
        }

        public void move() {
            rect.X = getNextCoords().X;
            rect.Y = getNextCoords().Y;
        }

        public Point getNextCoords() {
            return new Point(rect.X + (int)(Math.Cos(3.14 * angle / 180) * BALL_SPEED), rect.Y + (int)(Math.Sin(3.14 * angle / 180) * BALL_SPEED));
        }

        public Rectangle getNextRectangle() {
            return new Rectangle(getNextCoords(), rect.Size);
        }

        public void flipAngleHorizontaly() {
            angle = 0D - angle;
            minimizeBallAngle();
        }

        public void flipAngleVerticaly()
        {
            angle = 180D - angle;
            minimizeBallAngle();
        }

        private void minimizeBallAngle()
        {
            if (angle > 360) angle -= 360;
            if (angle < -360) angle += 360;
        }

        public void draw(Graphics g)
        {
            g.DrawImage(image, rect);
        }

    }
}
