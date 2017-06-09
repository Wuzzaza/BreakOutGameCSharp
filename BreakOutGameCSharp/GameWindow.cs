using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace BreakOutGameCSharp
{
        public partial class GameWindow : Form
    {
        const int FPS = 60, 
                  SCORES_FOR_BRICK = 100, 
                  SCORES_ADDED_AT_TICK = 10, 
                  WIDTH = 800, HEIGHT = 600, 
                  STAR_SPAWN_CHANCE_IN_PERCENT = 20;

        PlayerBat playerBat;
        Ball ball;
        List<Brick> brickList = new List<Brick>();
        Random randomizer = new Random();

        List<Star> starList = new List<Star>();
        GameMenu gameMenu;
        public System.Timers.Timer timer { get; set; }

        int playerScore, scoreToAdd;

        public GameWindow()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            this.Paint += new PaintEventHandler(drawGameWindow);

            gameMenu = new GameMenu();
            gameMenu.ShowInTaskbar = false;


            playerBat = new PlayerBat(350, 520);
            ball = new Ball(390, 500);

            for (int i = 0; i < 70; i++) {
                brickList.Add(new Brick(((i % 14) * 50) + 50, ((i / 14) * 20) + 100));
            }

            this.timer = new System.Timers.Timer(1000/60);
            this.timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            this.timer.Start();

            playerScore = 0;
            scoreToAdd = 0;

        }

        private void drawGameWindow(object sender, PaintEventArgs e)
        {
            playerBat.draw(e.Graphics);
            ball.draw(e.Graphics);

            for (int i = brickList.Count - 1; i >= 0; i--)
            {
                brickList[i].draw(e.Graphics);
            }

            for (int i = starList.Count - 1; i >= 0; i--)
            {
                starList[i].draw(e.Graphics);
                starList[i].move();
                if (starList[i].rect.Y > HEIGHT) starList.RemoveAt(i);
            }

            e.Graphics.DrawString("SCORE: " + playerScore.ToString(), new Font(FontFamily.GenericSansSerif, 22, FontStyle.Bold), new SolidBrush(Color.Black), 500, 10);

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
            checkStarCollision();

            ball.move();

            if (scoreToAdd >= (0 + SCORES_ADDED_AT_TICK)) {

                scoreToAdd -= SCORES_ADDED_AT_TICK;
                playerScore += SCORES_ADDED_AT_TICK;
            }

            this.Invalidate();

        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) pauseGame();

        }

        private void checkBorderCollision() {
            Point nextBallCoords = ball.getNextCoords();

            if (nextBallCoords.X < 0 || nextBallCoords.X > WIDTH - 30) ball.flipAngleVerticaly();
            if (nextBallCoords.Y < 0 || nextBallCoords.Y > HEIGHT - 30) ball.flipAngleHorizontaly();

        }

        private void checkBatCollision() {
            if (ball.getNextRectangle().IntersectsWith(playerBat.getRect())) {
                if (ball.rect.X < playerBat.rect.X - 10 || ball.rect.X > playerBat.rect.X + 110) ball.flipAngleVerticaly();
                else ball.flipAngleHorizontaly();
    }
        }

        private void checkBrickCollision() {
            for(int i = brickList.Count - 1; i >= 0; i--)
            {
                if (ball.getNextRectangle().IntersectsWith(brickList[i].getRect()))
                {
                    if (ball.rect.X + 10 < brickList[i].rect.X  || ball.rect.X + 10 > brickList[i].rect.X + 50) ball.flipAngleVerticaly();
                    else ball.flipAngleHorizontaly();

                    
                    if (randomizer.Next(0, 100) > 100 - STAR_SPAWN_CHANCE_IN_PERCENT) generateStar(brickList[i].rect.X, brickList[i].rect.Y);
                    brickList.RemoveAt(i);

                    scoreToAdd += SCORES_FOR_BRICK;

                    return;
                    
                }
            }
        }

        private void checkStarCollision() {
            for (int i = starList.Count - 1; i >= 0; i--) {
                if (playerBat.rect.IntersectsWith(starList[i].rect)) {
                    starList.RemoveAt(i);
                    scoreToAdd += SCORES_FOR_BRICK;
                }
            }
        }

        public void continueGame() {
            timer.Start();
        }

        public void newGame() {
            playerBat = new PlayerBat(350, 520);
            ball = new Ball(390, 500);

            brickList = new List<Brick>();

            for (int i = 0; i < 70; i++)
            {
                brickList.Add(new Brick(((i % 14) * 50) + 50, ((i / 14) * 20) + 100));
            }

            this.Invalidate();
        }

        public void pauseGame() {
            timer.Stop();
            gameMenu.StartPosition = FormStartPosition.CenterParent;
            gameMenu.ShowDialog(this);
        }

        public void generateStar(int x, int y)
        {
            starList.Add(new Star(x, y));
        }
    }
}
