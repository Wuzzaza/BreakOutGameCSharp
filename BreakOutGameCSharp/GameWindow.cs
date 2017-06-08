﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace BreakOutGameCSharp
{
        public partial class GameWindow : Form
    {
        const int FPS = 60;

        PlayerBat playerBat;
        Ball ball;
        List<Brick> brickList = new List<Brick>();
        System.Timers.Timer timer;

        public GameWindow()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(drawGameWindow);
            playerBat = new PlayerBat(350, 520);
            ball = new Ball(390, 500);

            for (int i = 0; i < 70; i++) {
                brickList.Add(new Brick(((i % 14) * 50) + 50, ((i / 14) * 20) + 100));
            }

            this.timer = new System.Timers.Timer(1000/60);
            this.timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            this.timer.Start();

        }

        private void drawGameWindow(object sender, PaintEventArgs e)
        {
            playerBat.draw(e.Graphics);
            ball.draw(e.Graphics);

            for (int i = brickList.Count - 1; i >= 0; i--)
            {
                brickList[i].draw(e.Graphics);
            } 
        }

        private void GameWindow_MouseMove(object sender, MouseEventArgs e)
        {

            playerBat.rect.X = Control.MousePosition.X - this.Location.X - 55;
        }


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            checkBorderCollision();
            checkBatCollision();
            checkBrickCollision();

            ball.move();

            this.Invalidate();

        }

        private void checkBorderCollision() {
            Point nextBallCoords = ball.getNextCoords();

            if (nextBallCoords.X < 0 || nextBallCoords.X > 800 - 30) ball.flipAngleVerticaly();
            if (nextBallCoords.Y < 0 || nextBallCoords.Y > 600 - 30) ball.flipAngleHorizontaly();

            Console.WriteLine(ball.angle.ToString());

        }

        private void checkBatCollision() {
            if (ball.getNextRectangle().IntersectsWith(playerBat.getRect())) ball.flipAngleHorizontaly();
        }

        private void checkBrickCollision() {
            for(int i = brickList.Count - 1; i >= 0; i--)
            {
                if (ball.getNextRectangle().IntersectsWith(brickList[i].getRect()))
                {
                    if (ball.rect.X < brickList[i].rect.X || ball.rect.X > brickList[i].rect.X + 50) ball.flipAngleVerticaly();
                    else ball.flipAngleHorizontaly();
                    brickList.RemoveAt(i);
                    return;
                    
                }
            }
        }
    }
}
