using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityClient
{
    public partial class FrmAccessToken : Form
    {
        public FrmAccessToken()
        {
            InitializeComponent();
        }
        public FrmAccessToken(AccessToken aToken)
        {
            InitializeComponent();
            txttoken.Text = aToken.ToString();
        }
    }
}
