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
    public partial class StartGame : Form
    {
        public StartGame()
        {
            InitializeComponent();
        }
        // Nhap thi no lay ten qua form 1
        //The button1_Click event handler is triggered when the button with the name button1 is clicked.
        //The code checks if the Owner of the current form is an instance of Form1 (presumably the main form of the application).
        //If it is, it calls the SetPlayerNames method on the Form1 instance and passes the text values of the p1 and p2 controls as arguments.
        private void button1_Click(object sender, EventArgs e)
        {

            Basic_Computer basic_computer = new Basic_Computer();
            basic_computer.Owner = this;
            this.Hide();
            basic_computer.SetPlayerNames(p1.Text, p2.Text);
            basic_computer.ShowDialog();
            // Không cần gọi this.Hide() ở đây
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ultimate ultimate = new Ultimate ();
            ultimate.Owner = this;
            this.Hide();
            ultimate.SetPlayerNames(p1.Text, p2.Text);
            ultimate.ShowDialog();
            // Không cần gọi this.Hide() ở đây
        }

      

    }
}
