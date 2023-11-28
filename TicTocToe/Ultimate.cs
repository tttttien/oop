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
    public partial class Ultimate : Form
    {
        // Lay ben tictacToeGame
        // Reference to the TicTacToeGame class
        private TicTacToeGame ticTacToeGame;
        // 2D array to represent the game buttons
        private Button[,] button1;
        private Button[,] button2;
        private Button[,] button3;
        private Button[,] button4;
        private Button[,] button5;
        private Button[,] button6;
        private Button[,] button7;
        private Button[,] button8;
        private Button[,] button9;
        private Panel[,] panels;
        private Button[,] button;
        // Khoi tao
        // Constructor
        public Ultimate ()
        {
            InitializeComponent();
            // Initialize the buttons array
            button1 = new Button[,]
            {
                { A11, A12, A13 },
                { B11, B12, B13 },
                { C11, C12, C13 }
            };
            button2 = new Button[,]
            {
                { A21, A22, A23 },
                { B21, B22, B23 },
                { C21, C22, C23 }
            };
            button3 = new Button[,]
            {
                { A31, A32, A33 },
                { B31, B32, B33 },
                { C31, C32, C33 }
            };
            button4 = new Button[,]
            {
                { A41, A42, A43 },
                { B41, B42, B43 },
                { C41, C42, C43 }
            };
            button5 = new Button[,]
            {
                { A51, A52, A53 },
                { B51, B52, B53 },
                { C51, C52, C53 }
            };
            button6 = new Button[,]
            {
                { A61, A62, A63 },
                { B61, B62, B63 },
                { C61, C62, C63 }
            };
            button7 = new Button[,]
            {
                { A71, A72, A73 },
                { B71, B72, B73 },
                { C71, C72, C73 }
            };
            button8 = new Button[,]
            {
                { A81, A82, A83 },
                { B81, B82, B83 },
                { C81, C82, C83 }
            };
            button9 = new Button[,]
            {
                { A91, A92, A93 },
                { B91, B92, B93 },
                { C91, C92, C93 }
            };
            panels = new Panel[,]
            {
                {panel1, panel2, panel3 },
                {panel4, panel5, panel6 },
                {panel7, panel8, panel9 }
            };
            button = new Button[3, 3];
        }

        // Tao player
        // Set player names using Form2
        public void SetPlayerNames(string playerName1, string playerName2)
        {
            // Create an instance of TicTacToeGame with player names
            ticTacToeGame = new TicTacToeGame(playerName1, playerName2);
            // Set player names on the form
            p1.Text = ticTacToeGame.Player1.Name;
            p2.Text = ticTacToeGame.Player2.Name;
        }
        //  Khi ma di -> Khi cos nguoiw thang -> Disable het button -> Ai thang, thif tinh ra score -> Xong gan cho x_count de hien thi ra man hinh
        // Handle click event for game buttons
        public void Superstar(Button clickedButton, Button[,] buttons, Panel[,] panels)
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
                    int currentPanelIndex = (i * 3) + (j + 1);

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
     
        public void EnableButtonNoText (Panel[,] panels)
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
        public void CheckWinner (Button clickedButton, Button[,] buttons, Panel panel)
        {
            Console.WriteLine("CheckForWinnerPanel returned true");
            if (ticTacToeGame.MakeMove(clickedButton))
            {
                if (ticTacToeGame.CheckForWinner(buttons))
                {
                    // Disable buttons and display the winner
                    ticTacToeGame.DisableButton(buttons);
                    Player winner = ticTacToeGame.GetWinner();
                    if (winner.Name == ticTacToeGame.Player1.Name)
                    {
                        Button newButton = new Button();

                        // Đặt kích thước cho button mới (cùng với kích thước của panel)
                        newButton.Size = panel.Size;

                        // Đặt vị trí cho button mới theo vị trí của panel
                        newButton.Location = new Point(0,0);

                        // Đặt văn bản cho button mới là "X"-
                        newButton.Text = "X";

                        // Đặt font cho văn bản (có thể điều chỉnh kích thước)
                        newButton.Font = new Font("Microsoft Sans Serif", 40F, FontStyle.Bold);

                        // Đặt tên cho button mới theo tên của panel
                        newButton.Name = panel.Name;
                 
                        // Thêm button mới vào form hoặc container tương ứng
                        panel.Controls.Add(newButton);
                        panel.Controls[newButton.Name].BringToFront();
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j ++)
                            {
                                if (newButton.Name == panels[i,j].Name)
                                {
                                    button[i, j] = newButton;
                                    button[i, j].Enabled = false;
                                    break;
                                }
                            }
                        }
                    }

                    if (winner.Name == ticTacToeGame.Player2.Name)
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
                            for (int j = 0; j < 3; j ++)
                            {
                                if (newButton.Name == panels[i, j].Name)
                                {
                                    button[i, j] = newButton;
                                    button[i, j].Enabled = false;
                                    break;
                                }
                            }
                        }

                    };
                    if (ticTacToeGame.CheckForWinner(button))
                    {
                        winner = ticTacToeGame.GetWinner();
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
                }
            }
            Superstar(clickedButton,button, panels);
        }

        




        private void button_click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            CheckWinner(clickedButton, button1, panel1);

        }


        private void button_click1(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            CheckWinner(clickedButton, button2, panel2);

        }
        private void button_click2(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            CheckWinner(clickedButton, button3, panel3);

        }
        private void button_click3(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            CheckWinner(clickedButton, button4, panel4);

        }
        private void button_click4(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            CheckWinner(clickedButton, button5, panel5);
            
        }
        private void button_click5(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            CheckWinner(clickedButton, button6, panel6);
         
        }
        private void button_click6(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            CheckWinner(clickedButton, button7, panel7);

        }
        private void button_click7(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            CheckWinner(clickedButton, button8, panel8);


        }
        private void button_click8(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            CheckWinner(clickedButton, button9, panel9);
   
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
        // Game moi
        // Start a new game
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ticTacToeGame.ResetGame(button);
        }
        // Reset
        // Reset scores and the game board
        private void resetWinGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_count.Text = "0";
            x_count.Text = "0";
            draw_count.Text = "0";

            ticTacToeGame.Player1.Score = 0;
            ticTacToeGame.Player2.Score = 0;
            ticTacToeGame.ResetGame(button1);
        }

        // Thoat khoi
        // Exit the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Display information about the application
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Team", "Tic Tac Toe about");
        }





        // Using Form2 to input player names
        // Load player names from Form2
        /*
        private void Super_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Owner = this; // Set the owner to Super
            f2.ShowDialog();
        }
        */

    }
}
