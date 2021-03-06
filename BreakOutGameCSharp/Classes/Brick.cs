﻿using System;
using System.Drawing;


namespace BreakOutGameCSharp
{
    [Serializable]
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
