﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class SignUp : UserControl
    {
        SONA S;
        public SignUp(SONA s )
        {
            InitializeComponent();
            S = s;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            S.Close();  
        }

        private void lbDangnhap_Click(object sender, EventArgs e)
        {
            Login info = new Login(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(info);

        }
    }
}
