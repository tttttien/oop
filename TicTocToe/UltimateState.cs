using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class UltimateState : TicTacToeGame
    {
        private TicTacToeGame ticTacToeGame;
        private Ultimate ultimate;
        private Button[,] button;
        // Constructor for the UltimateState class
        public UltimateState(TicTacToeGame game, Ultimate ultimateInstance, string playerName1, string playerName2, Button[,] button) : base (playerName1, playerName2)
        {
            ticTacToeGame = game;
            ultimate = ultimateInstance;
            this.button = button;
            Turn = true;
        }
        // Handles the logic for making a move and jumping to the appropriate panel
        public void Jump(Button clickedButton, Button[,] buttons, Panel[,] panels)
        {
            string buttonName = clickedButton.Name;

            // Extract the first digit and last digit from the button name
            char firstDigit = buttonName[0];
            char lastDigit = buttonName[buttonName.Length - 1];

            // Combine first and last digits to determine the target panel
            string panelChar = firstDigit.ToString() + lastDigit.ToString();

            // Determine the index of the target panel based on its identifier
            int panelIndex = 0;
            switch (panelChar)
            {
                case "A1":
                    panelIndex = 1;
                    break;
                case "A2":
                    panelIndex = 2;
                    break;
                case "A3":
                    panelIndex = 3;
                    break;
                case "B1":
                    panelIndex = 4;
                    break;
                case "B2":
                    panelIndex = 5;
                    break;
                case "B3":
                    panelIndex = 6;
                    break;
                case "C1":
                    panelIndex = 7;
                    break;
                case "C2":
                    panelIndex = 8;
                    break;
                case "C3":
                    panelIndex = 9;
                    break;
                default:
                    // Handle invalid button names
                    return;
            }

            // Enable the buttons in the target panel and disable others
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Panel currentPanel = panels[i, j];
                    int currentPanelIndex = (i * 3) + (j + 1);

                    foreach (Control control in currentPanel.Controls)
                    {
                        if (control is Button button)
                        {
                            if (currentPanelIndex == panelIndex && button.Text == "")
                            {
                                // Enable buttons in the target panel
                                button.Enabled = true;
                                // If the corresponding button in the game board is not null and has the same name as the panel,
                                // it means that big button have appeared and the position we want to move is the same with this big button, so enable buttons with no text in all panels
                                if (buttons[i, j] != null && buttons[i, j].Name == panels[i, j].Name)
                                {
                                    EnableButtonNoText(panels);
                                    return;
                                }
                            }
                            else
                            {
                                // Disable buttons in panels other than the target panel
                                button.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        // Enable buttons with no text in the panels
        public void EnableButtonNoText(Panel[,] panels)
        {
            foreach (Panel panel in panels)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is Button button && button.Text == "")
                    {
                        button.Enabled = true;
                    }

                }
            }
        }
        // Disable buttons in all panels when there is a winner
        public void DisableButtonWhenWin(Panel[,] panels)
        {
            foreach (Panel panel in panels)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is Button button)
                    {
                        button.Enabled = false;
                    }

                }
            }
        }
        // Check for a winner in the Ultimate Tic Tac Toe game
        public void CheckWinner(Button clickedButton, Button[,] buttons, Panel panel, Panel[,] panels)
        {
            Console.WriteLine("CheckForWinnerPanel returned true");
            // Try to make a move using the clicked button
            if (MakeMove(clickedButton)) 
            {
                // Check if the current player has won
                if (CheckForWinner(buttons))
                {
                    // Disable buttons and display the winner
                    DisableButton(buttons);
                    Player winner = GetWinner();
                    // Handle if Player1 (X) is the winner
                    if (winner.Name == Player1.Name)
                    {
                        // Create a new button for the winning panel
                        Button newButton = new Button();

                        // Set the size of the new button to match the size of the panel
                        newButton.Size = panel.Size;

                        // Set the location of the new button to the top-left corner of the panel
                        newButton.Location = new Point(0, 0);

                        // Set the text of the new button to "X"
                        newButton.Text = "X";

                        // Set the font for the new button (adjustable size)
                        newButton.Font = new Font("Microsoft Sans Serif", 40F, FontStyle.Bold);

                        // Set the name of the new button to match the name of the panel
                        newButton.Name = panel.Name;

                        // Add the new button to the panel or container
                        panel.Controls.Add(newButton); 
                        panel.Controls[newButton.Name].BringToFront();
                        // Handle the logic for hiding the corresponding big button
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (newButton.Name == panels[i, j].Name)
                                {
                                    button[i, j] = newButton;  // Set the array value to the new button
                                    button[i, j].Enabled = false;
                                    turnCountForUltimate++;  // Count big buttons to know draw or not
                                    break;
                                }
                            }
                        }
                    }
                    // Handle if Player2 (O) is the winner
                    if (winner.Name == Player2.Name)
                    {
                        // Create a new button for the winning panel
                        Button newButton = new Button();

                        // Set the size of the new button to match the size of the panel
                        newButton.Size = panel.Size;

                        // Set the location of the new button to the top-left corner of the panel
                        newButton.Location = new Point(0, 0);

                        // Set the text of the new button to "O"
                        newButton.Text = "O";
                        // Set the font for the new button (adjustable size)
                        newButton.Font = new Font("Microsoft Sans Serif", 40F, FontStyle.Bold);

                        // Set the name of the new button to match the name of the panel
                        newButton.Name = panel.Name;

                        // Add the new button to the panel or container
                        panel.Controls.Add(newButton);
                        panel.Controls[newButton.Name].BringToFront();
                        // Handle the logic for hiding the corresponding big button
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (newButton.Name == panels[i, j].Name)
                                {
                                    button[i, j] = newButton;
                                    button[i, j].Enabled = false;
                                    turnCountForUltimate++;
                                    break;
                                }
                            }
                        }

                    }
                    // Check if the ultimate game is a draw
                    if (turnCountForUltimate == 9)
                    {
                        ultimate.isDraw();
                        return;
                    }
                    // Check for a winner in the ultimate game
                    if (CheckForWinner(button))
                    {
                        // Disable buttons in all panels when there is an ultimate winner
                        DisableButtonWhenWin(panels);
                        // Update the score for the ultimate game based on the winner
                        ultimate.ScoreWinner(winner);
                        return;
                    }
                }
            }
            // If no winner is found, proceed with the logic for jumping to the appropriate panel
            Jump(clickedButton, button, panels);
        }
        // Reset the game state in the Ultimate Tic Tac Toe game
        public void ResetGame(Panel[,] panels, Button[,] buttons)
        {

            Turn = true;
            //  turnCount = 0;
            foreach (Panel panel in panels)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is Button button)
                    {
                        button.Enabled = true;
                        button.Text = "";
                    }
                }
            }
            foreach (Button button in buttons)
            {
                if (button != null)
                {
                    button.Dispose();
                    // Rename because it will still name of panel
                    button.Name = "";
                }
            }
        }
    }
}
