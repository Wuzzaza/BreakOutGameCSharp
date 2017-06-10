using System;
using System.IO;
using System.Windows.Forms;

namespace BreakOutGameCSharp
{
    public partial class GameMenu : Form
    {


        public GameMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            continueGame();
        }

        private void continueGame() {
            (Owner as GameWindow).continueGame();
            this.Hide();
        }

        private void GameMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) continueGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (Owner as GameWindow).Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (Owner as GameWindow).newGame();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (Owner as GameWindow).saveGame();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            (Owner as GameWindow).loadGame();
        }
    }
}
