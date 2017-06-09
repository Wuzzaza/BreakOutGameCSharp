using System.Drawing;

namespace BreakOutGameCSharp
{

    class Star
    {
        public const int WIDTH = 30, HEIGHT = 30, MOVE_SPEED = 5;

        public Rectangle rect;

        public Image image = Properties.Resources.ResourceManager.GetObject("star") as Image;

        public Star(int x, int y)
        {
            rect = new Rectangle(x, y, WIDTH, HEIGHT);
        }

        public Rectangle getRect()
        {
            return rect;
        }

        public void draw(Graphics g)
        {
            g.DrawImage(image, rect);
        }

        public void move() {
            rect.Y += MOVE_SPEED;
        }
    }

}

