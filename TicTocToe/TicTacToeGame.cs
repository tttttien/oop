// TicTacToeGame.cs

using System;
using System.Windows.Forms;

namespace TicTacToe
{
    class TicTacToeGame
    {
        // Define player variables
        private Player player1, player2;
        public Player Player1 { get { return player1; } }
        public Player Player2 { get { return player2; } }

        public bool turn; // true: X turn; false: O turn // Luot choi
        public bool Turn { get { return turn; } set { turn = value; } }
        private int turnCount; // Counts the number of turns // Hoa hay khong
        public int turnCountForUltimate;
        
        // Constructor
        public TicTacToeGame(string playerName1, string playerName2)
        {
            player1 = new Player(playerName1);
            player2 = new Player(playerName2);
            turn = true;
            turnCount = 0;
        }
        // turn true -> X di. turn false -> O:di. Xong turn Count tang len. Turn = !turn => De toi luot thang khacs
        // Make a move on the game board
        public bool MakeMove(Button button)
        {
            if (button.Enabled)
            {
                if (turn)
                {
                    button.Text = "X";
                }
                else
                {
                    button.Text = "O";
                }
                button.Enabled = false;
                turn = !turn;
                turnCount++;
                return true;
            }
            return false;
        }

        // Check win -> Check A1 A2 A3-> Thang hang thi thang. (cu vay tiep tuc) 
        // Check for a winner on the game board
        public bool CheckForWinner(Button[,] buttons)
        {
            bool there_is_a_winner = false;


            // Check horizontal, vertical, and diagonal wins using the buttons array


            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0] != null && buttons[i, 1] != null && buttons[i, 2] != null)
                {
                    if (buttons[i, 0].Text == buttons[i, 1].Text && buttons[i, 1].Text == buttons[i, 2].Text && !buttons[i, 0].Enabled)
                    {
                        there_is_a_winner = true;
                        break;
                    }
                }
                if (buttons[0, i] != null && buttons[1, i] != null && buttons[2, i] != null)
                {
                    if (buttons[0, i].Text == buttons[1, i].Text && buttons[1, i].Text == buttons[2, i].Text && !buttons[0, i].Enabled)
                    {
                        there_is_a_winner = true;
                        break;
                    }
                }
            }
            if (buttons[0, 0] != null && buttons[1, 1] != null && buttons[2, 2] != null)
            {
                if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text && !buttons[0, 0].Enabled)
                {
                    there_is_a_winner = true;
                }
            }
            if (buttons[0, 2] != null && buttons[1, 1] != null && buttons[2, 0] != null)
            {
                if (buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text && !buttons[0, 2].Enabled)
                {
                    there_is_a_winner = true;
                }
            }
        
            return there_is_a_winner;
        }
        // Nay la khi choi xong, thi con may o con lai. Thi mk lam button khong nhan vao duoc
        // Disable all buttons on the game board
        public void DisableButton(Button[,] buttons)
        {
            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
        }
        // New game lai -> May cai button text rong tro lai
        // Reset the game board
        public void ResetGame(Button[,] buttons)
        {

            turn = true;
            turnCount = 0;
            foreach (Button button in buttons)
            {
                button.Enabled = true;
                button.Text = "";
            }
        }

        // Lay nguoi thang
        // Get the player who won the game
        public Player GetWinner()
        {
            if (turn)
            {
                return player2;
            }
            else
            {
                return player1;
            }
        }
        // Hoa 
        // Check if the game is a draw
        public bool IsDraw()
        {
            return turnCount == 9;
        }

        // Ben super

    }
}
