using System;
using System.Windows.Forms;

namespace TicTacToe
{
    class ComputerState
    {
        // Indicates whether the computer is playing against a human player
        private bool againstComputer;
        // Property to get or set the value of 'againstComputer'
        public bool AgainstComputer
        {
            get { return againstComputer; }
            set { againstComputer = value; }
        }
        // Constructor to initialize the ComputerState with the game mode
        public ComputerState(bool againstComputer)
        {
            AgainstComputer = againstComputer;
        }
        // Logic for the computer to make a move in the game
        /* Computer applies priority order
        1. Prioritizing winning moves (That means computer find the way to win first)
        2. Blocking the opponent's winning moves
        3. Occupying corner spaces
        4. selecting open space
        */
        public void ComputerMakeMove(Button[,] buttons)
        {
            Button move = null;
            // Look for a winning move for "O" - computer
            move = LookForWinOrBlock("O", buttons);
            if (move == null)
            {
                // If no winning move, look for a blocking move for 'X' (human)
                move = LookForWinOrBlock("X", buttons);
                // If no winning move for 'X', look for a corner move
                if (move == null)
                {
                    move = LookForCorner(buttons);
                    // If no corner move, look for an open space
                    if (move == null)
                    {
                        move = LookForOpenSpace(buttons);
                    }
                }
            }
            // If a move is found, perform the click on the button
            if (move != null)
            {
                move.PerformClick();
            }
           
        }
        // Look for a winning move for "O" - computer or look for a blocking move of "X" - human
        private Button LookForWinOrBlock(string mark, Button[,] buttons)
        {
            Console.WriteLine("Looking for win or block: " + mark);
            for (int i = 0; i < 3; i++)
            {
                // Check horizontally
                if (buttons[i, 1].Text == buttons[i, 2].Text && buttons[i, 1].Text == mark && buttons[i, 0].Text == "")
                {
                    return buttons[i, 0];
                }
                if (buttons[i, 0].Text == buttons[i, 2].Text && buttons[i, 0].Text == mark && buttons[i, 1].Text == "")
                {
                    return buttons[i, 1];
                }
                if (buttons[i, 0].Text == buttons[i, 1].Text && buttons[i, 1].Text == mark && buttons[i, 2].Text == "")
                {
                    return buttons[i, 2];
                }
                // Check vertically
                if (buttons[1, i].Text == buttons[2, i].Text && buttons[1, i].Text == mark && buttons[0, i].Text == "")
                {
                    return buttons[0, i];
                }
                if (buttons[0, i].Text == buttons[2, i].Text && buttons[0, i].Text == mark && buttons[1, i].Text == "")
                {
                    return buttons[1, i];
                }
                if (buttons[0, i].Text == buttons[1, i].Text && buttons[0, i].Text == mark && buttons[2, i].Text == "")
                {
                    return buttons[2, i];
                }
            }
            // Check diagonally
            if (buttons[1, 1].Text == buttons[2, 2].Text && buttons[1, 1].Text == mark && buttons[0, 0].Text == "")
            {
                return buttons[0, 0];
            }
            if (buttons[0, 0].Text == buttons[2, 2].Text && buttons[0, 0].Text == mark && buttons[1, 1].Text == "")
            {
                return buttons[1, 1];
            }
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == mark && buttons[2, 2].Text == "")
            {
                return buttons[2, 0];
            }

            if (buttons[1, 1].Text == buttons[2, 0].Text && buttons[1, 1].Text == mark && buttons[0, 2].Text == "")
            {
                return buttons[0, 2];
            }

            if (buttons[0, 2].Text == buttons[2, 0].Text && buttons[0, 2].Text == mark && buttons[1, 1].Text == "")
            {
                return buttons[0, 2];
            }

            if (buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text ==  mark && buttons [2,0].Text == "")
            {
                return buttons[2, 0];
            }
            return null;
        }
        // Look for a corner move
        private Button LookForCorner(Button[,] buttons)
        {
            if (buttons[0, 0].Text == "O")
            {
                if (buttons[0, 2].Text == "")
                    return buttons[0, 2];
                if (buttons[2, 2].Text == "")
                    return buttons[2, 2];
                if (buttons[2, 0].Text == "")
                    return buttons[2, 0];
            }
            if (buttons[0, 2].Text == "O")
            {
                if (buttons[0, 0].Text == "")
                    return buttons[0, 0];
                if (buttons[2, 2].Text == "")
                    return buttons[2, 2];
                if (buttons[2, 0].Text == "")
                    return buttons[2, 0];
            }
            if (buttons[2, 2].Text == "O")
            {
                if (buttons[0, 0].Text == "")
                    return buttons[0, 0];
                if (buttons[0, 2].Text == "")
                    return buttons[0, 2];
                if (buttons[2, 0].Text == "")
                    return buttons[2, 0];
            }
            if (buttons[2, 0].Text == "O")
            {
                if (buttons[0, 0].Text == "")
                    return buttons[0, 0];
                if (buttons[0, 2].Text == "")
                    return buttons[0, 2];
                if (buttons[2, 2].Text == "")
                    return buttons[2, 2];
            }
            if (buttons[0, 0].Text == "")
            {
                return buttons[0, 0];
            }
            if (buttons[0, 2].Text == "")
            {
                return buttons[0, 2];
            }
            if (buttons[2, 0].Text == "")
            {
                return buttons[2, 0];
            }
            if (buttons[2, 2].Text == "")
            {
                return buttons[2, 2];
            }
            return null;
        }
        // look for an open space (Con trong cai nao danh vo cai ay)
        private Button LookForOpenSpace(Button[,] buttons)
        {
            foreach (Button button in buttons)
            {
                if (button.Text == "")
                    return button;
            }
            return null;
        }
    }
}