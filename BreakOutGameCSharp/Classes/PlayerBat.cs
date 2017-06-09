using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace BreakOutGameCSharp
{
    [Serializable]
    class PlayerBat
    {
        public int  width, height;

        public Rectangle rect;
        
        public Image image = Properties.Resources.ResourceManager.GetObject("bat_yellow") as Image;



        public PlayerBat(int x, int y)
        {
            rect = new Rectangle(x, y, 100, 20);
        }

        public Rectangle getRect()
        {
            return rect;
        }

        public void draw(Graphics g)
        {
            g.DrawImage(image, rect);
        }

    }
}
