/*
 * Author: Jacob Sunny
 * War game 
 * 1/23/2019
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WARGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game g = new Game();
            g.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            lblRules.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
