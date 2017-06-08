using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace BreakOutGameCSharp
{
    class Brick
    {
        public const int WIDTH = 50, HEIGHT = 20;

        public Rectangle rect;

        public Image image = Properties.Resources.ResourceManager.GetObject("brick_violet_small") as Image;

        public Brick(int x, int y)
        {
            rect = new Rectangle(x, y, WIDTH, HEIGHT);
        }

        public Rectangle getRect() {
            return rect;
        }

        public void draw(Graphics g)
        {
            g.DrawImage(image, rect);
        }
    }
}
