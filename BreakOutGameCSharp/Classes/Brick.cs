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
        public int x, y;

        public Image image = new Bitmap(Properties.Resources.ResourceManager.GetObject("brick_violet_small") as Image, new Size(50, 20)) as Image;

        public Brick(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Rectangle getRect() {
            return new Rectangle(x, y, 50, 20);
        }
    }
}
