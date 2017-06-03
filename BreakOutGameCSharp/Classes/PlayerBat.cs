using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace BreakOutGameCSharp
{
    class PlayerBat
    {
        public int x, y;
        
        
        public Image image = new Bitmap (Properties.Resources.ResourceManager.GetObject("bat_yellow") as Image, new Size(100, 20)) as Image;



        public PlayerBat(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public Rectangle getRect() {
            return new Rectangle(x, y, 100, 20);
        }
    }
}
