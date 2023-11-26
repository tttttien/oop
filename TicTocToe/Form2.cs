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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        // Nhap thi no lay ten qua form 1
        //The button1_Click event handler is triggered when the button with the name button1 is clicked.
        //The code checks if the Owner of the current form is an instance of Form1 (presumably the main form of the application).
        //If it is, it calls the SetPlayerNames method on the Form1 instance and passes the text values of the p1 and p2 controls as arguments.
        private void button1_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Owner = this;
            this.Hide();
            form1.SetPlayerNames(p1.Text, p2.Text);
            form1.ShowDialog();
            // Không cần gọi this.Hide() ở đây
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Super super = new Super();
            super.Owner = this;
            this.Hide();
            super.SetPlayerNames(p1.Text, p2.Text);
            super.ShowDialog();
            // Không cần gọi this.Hide() ở đây
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        // nhan enter khi nhap xong ten thu 2 thi cung chuyen qua form 1
        //The p2_KeyPress event handler is triggered when a key is pressed while the focus is on the p2 control (presumably a text input control).
        // The code checks if the pressed key is the Enter key(\r represents the carriage return character).
        // If it is, it programmatically triggers a click event on button1 by calling the PerformClick method.

    }
}
