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
    public partial class SONA : Form
    {
        public SONA()
        {
            InitializeComponent();
            Login login = new Login(this);
            pnLogin.Controls.Add(login);
        }
    }
}
