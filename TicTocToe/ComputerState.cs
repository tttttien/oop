using System;
using System.Windows.Forms;

namespace TicTacToe
{
    class ComputerState
    {
        private bool againstComputer;
        public bool AgainstComputer
        {
            get { return againstComputer; }
            set { againstComputer = value; }
        }

        public ComputerState (bool againstComputer)
        {
            AgainstComputer = againstComputer;
        }

        public void ComputerMakeMove(Button[,] buttons)
        {
            Button move = null;
            move = LookForWinOrBlock("O", buttons);
            if (move == null)
            {
                move = LookForWinOrBlock("X", buttons);
                if (move == null)
                {
                    move = LookForCorner(buttons);
                    if (move == null)
                    {
                        move = LookForOpenSpace(buttons);
                    }
                }
            }
            if (move != null)
            {
                move.PerformClick();
            }
           
        }

        private Button LookForWinOrBlock(string mark, Button[,] buttons)
        {
            Console.WriteLine("Looking for win or block: " + mark);
            for (int i = 0; i < 3; i++)
            {
                // HORIZONTAL
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
                // VERTICAL
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
            // DIAGONAL
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