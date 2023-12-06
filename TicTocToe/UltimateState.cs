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
        public UltimateState(TicTacToeGame game, Ultimate ultimateInstance, string playerName1, string playerName2, Button[,] button) : base (playerName1, playerName2)
        {
            ticTacToeGame = game;
            ultimate = ultimateInstance;
            this.button = button;
            Turn = true;
        }
        public void Jump(Button clickedButton, Button[,] buttons, Panel[,] panels)
        {
            string buttonName = clickedButton.Name;

            // Extract the first digit and last digit from the button name
            char firstDigit = buttonName[0];
            char lastDigit = buttonName[buttonName.Length - 1];

            // Combine first and last digits to get the panel character
            string panelChar = firstDigit.ToString() + lastDigit.ToString();

            // Determine the panel index based on the panel character
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

            // Enable the clicked panel and disable others
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Panel currentPanel = panels[i, j];
                    int currentPanelIndex = (i * 3) + (j + 1);  // 

                    foreach (Control control in currentPanel.Controls)
                    {
                        if (control is Button button)
                        {
                            if (currentPanelIndex == panelIndex && button.Text == "")
                            {
                                button.Enabled = true;
                                if (buttons[i, j] != null && buttons[i, j].Name == panels[i, j].Name)
                                {
                                    EnableButtonNoText(panels);
                                    return;
                                }
                            }
                            else
                            {
                                button.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

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
        public void CheckWinner(Button clickedButton, Button[,] buttons, Panel panel, Panel[,] panels)
        {
            Console.WriteLine("CheckForWinnerPanel returned true");
            if (MakeMove(clickedButton)) 
            {
                if (CheckForWinner(buttons))
                {
                    // Disable buttons and display the winner
                    DisableButton(buttons);
                    Player winner = GetWinner();
                    if (winner.Name == Player1.Name)
                    {
                        Button newButton = new Button();

                        // Đặt kích thước cho button mới (cùng với kích thước của panel)
                        newButton.Size = panel.Size;

                        // Đặt vị trí cho button mới theo vị trí của panel
                        newButton.Location = new Point(0, 0);  

                        // Đặt văn bản cho button mới là "X"-
                        newButton.Text = "X";

                        // Đặt font cho văn bản (có thể điều chỉnh kích thước)
                        newButton.Font = new Font("Microsoft Sans Serif", 40F, FontStyle.Bold);

                        // Đặt tên cho button mới theo tên của panel
                        newButton.Name = panel.Name;

                        // Thêm button mới vào form hoặc container tương ứng
                        panel.Controls.Add(newButton); 
                        panel.Controls[newButton.Name].BringToFront();
                        // An nut big do
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (newButton.Name == panels[i, j].Name)
                                {
                                    button[i, j] = newButton; // Set mang vao button
                                    button[i, j].Enabled = false;
                                    turnCountForUltimate++;
                                    break;
                                }
                            }
                        }
                    }

                    if (winner.Name == Player2.Name)
                    {
                        Button newButton = new Button();

                        // Đặt kích thước cho button mới (cùng với kích thước của panel)
                        newButton.Size = panel.Size;

                        // Đặt vị trí cho button mới theo vị trí của panel
                        newButton.Location = new Point(0, 0);

                        // Đặt văn bản cho button mới là "O"-
                        newButton.Text = "O";
                        // Đặt font cho văn bản (có thể điều chỉnh kích thước)
                        newButton.Font = new Font("Microsoft Sans Serif", 40F, FontStyle.Bold);

                        // Đặt tên cho button mới theo tên của panel
                        newButton.Name = panel.Name;

                        // Thêm button mới vào form hoặc container tương ứng
                        panel.Controls.Add(newButton);
                        panel.Controls[newButton.Name].BringToFront();
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
                    if (turnCountForUltimate == 9)
                    {
                        ultimate.isDraw();
                        return;
                    }
                    if (CheckForWinner(button))
                    {
                        DisableButtonWhenWin(panels);
                        ultimate.ScoreWinner(winner);
                        return;
                    }
                }
            }
            Jump(clickedButton, button, panels);
        }
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
