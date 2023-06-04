using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_game
{
    public partial class Form2 : Form
    {
        public Form2(int score)
        {
            InitializeComponent();
            this.score = score;
        }
        int score;  
        private void Lose_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            label1.Text = score.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
