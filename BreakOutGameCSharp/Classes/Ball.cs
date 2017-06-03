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
        const int BALL_SPEED = 10;

        public int x, y;

        public double angle;

        public Image image = new Bitmap(Properties.Resources.ResourceManager.GetObject("ball_red") as Image, new Size(20, 20)) as Image;

        public Ball(int x, int y)
        {
            this.angle = -45;
            this.x = x;
            this.y = y;
        }

        public void move() {
            this.x = getNextCoords().X;
            this.y = getNextCoords().Y;
        }

        public Point getNextCoords() {
            return new Point(this.x + (int)(Math.Cos(3.14 * angle / 180) * BALL_SPEED), this.y + (int)(Math.Sin(3.14 * angle / 180) * BALL_SPEED));
        }

        public Rectangle getNextRectangle() {
            return new Rectangle(getNextCoords(), new Size(20, 20));
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

    }
}
