
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Basic_Computer : Form
    {
        // Lay ben tictacToeGame
        // Reference to the TicTacToeGame class
        private TicTacToeGame ticTacToeGame;
        // 2D array to represent the game buttons
        private Button[,] buttons;
        // Represents the state of the computer player
        private ComputerState computer;
        // Constructor
        public Basic_Computer()
        {
            InitializeComponent();
            // Initialize the buttons array
            buttons = new Button[,]
            {
                { A1, A2, A3 },
                { B1, B2, B3 },
                { C1, C2, C3 }
            };
            // Initialize the computer state
            computer = new ComputerState (false);
        }
        // Set player names using StartGame.cs
        public void SetPlayerNames(string playerName1, string playerName2)
        {
            // Create a new instance of TicTacToeGame with player names
            ticTacToeGame = new TicTacToeGame(playerName1, playerName2);
            p1.Text = ticTacToeGame.Player1.Name;
            p2.Text = ticTacToeGame.Player2.Name;

            // Check if player 2 is "Computer" to set the game mode accordingly
            if (playerName2.ToUpper() == "Computer")
            {
                computer.AgainstComputer = true;
            }
            else
            {
                computer.AgainstComputer = false;
            }
        }
        //  Khi ma di -> Khi cos nguoiw thang -> Disable het button -> Ai thang, thif tinh ra score -> Xong gan cho x_count de hien thi ra man hinh
        // Handle click event for game buttons
        private void button_click(object sender, EventArgs e)
        {
            // Check if player names are specified
            if ((p1.Text == "Player 1" || p2.Text == "Player2"))
            {
                MessageBox.Show("You must specify the players' names before you can start! InType Computer (for Player 2)");
            }
            else
            {
                Button clickedButton = (Button)sender;
                // Make a move in the Tic Tac Toe game
                if (ticTacToeGame.MakeMove(clickedButton))
                {
                    // Check for a winner or a draw
                    if (ticTacToeGame.CheckForWinner(buttons))
                    {
                        // Disable buttons and display the winner
                        ticTacToeGame.DisableButton(buttons);

                        Player winner = ticTacToeGame.GetWinner();
                        winner.Score++;
                        // Update score on the form based on the winner
                        if (winner == ticTacToeGame.Player1)
                        {
                            x_count.Text = winner.Score.ToString();
                        }
                        else if (winner == ticTacToeGame.Player2)
                        {
                            o_count.Text = winner.Score.ToString();
                        }

                        MessageBox.Show($"Congratulations! {winner.Name} is the winner", "Winner");
                    }
                    else if (ticTacToeGame.IsDraw())
                    {
                        // Update draw count and display a draw message
                        draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                        MessageBox.Show("Draw", "Draw");
                    }
                } 
            }
            // If it's the computer's turn, let the computer make a move
            if ((!ticTacToeGame.Turn) && (computer.AgainstComputer))
            {
                computer.ComputerMakeMove (buttons);
            }
        }
        // La luc luot qua o, no se hien thi X hay O as
        // Handle mouse enter event for game buttons
        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                // Display X or O when mouse enters a button based on the current player's turn
                if (ticTacToeGame.Turn)
                {
                    b.Text = "X";
                }
                else
                {
                    b.Text = "O";
                }
            }
        }
        // Luc minh luot qua, may cais conf laij nos hk hienj len X hay O
        // Handle mouse leave event for game buttons
        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                // Reset the text when mouse leaves a button
                b.Text = "";
            }
        }
      
        // Reset
        // Start a new game and reset scores
        private void resetWinGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_count.Text = "0";
            x_count.Text = "0";
            draw_count.Text = "0";

            ticTacToeGame.Player1.Score = 0;
            ticTacToeGame.Player2.Score = 0;
            ticTacToeGame.ResetGame(buttons);
        }

        // Exit the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Display information about the application
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Team 5", "Tic Tac Toe about");
        }

        // Load default player names
        private void setPlayerDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1.Text = "Player";
            p2.Text = "Computer";
            ticTacToeGame = new TicTacToeGame(p1.Text, p2.Text);
            o_count.Text = "0";
            x_count.Text = "0";
            draw_count.Text = "0";

            ticTacToeGame.Player1.Score = 0;
            ticTacToeGame.Player2.Score = 0;
            ticTacToeGame.ResetGame(buttons);
        }
        // Handle changes in the text for Player 2 (P2)
        private void p2_TextChanged(object sender, EventArgs e)
        {
            // Check if the text for Player 2 is "Computer" to set the game mode
            if (p2.Text == "Computer")
            {
                computer.AgainstComputer = true;
                ticTacToeGame.Player2.Name = "Computer"; // Đặt tên người chơi 2 là "Computer"
            }
            else
            {
                computer.AgainstComputer = false;
                ticTacToeGame.Player2.Name = p2.Text; // Update player 2 name based on the input value
            }
        }
        // Start a new game
        private void button1_Click(object sender, EventArgs e)
        {
            ticTacToeGame.ResetGame(buttons);
        }
    }
}
