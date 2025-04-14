using System;
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
    public partial class Login : UserControl
    {
        SONA S;
        public Login(SONA s)
        {
            InitializeComponent();
            S = s;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbDangky_Click(object sender, EventArgs e)
        {
            SignUp l= new SignUp(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(l);

        }
    }
}
