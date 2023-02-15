using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace login
{
    public partial class homecontrol : UserControl
    {
        OracleConnection cn = new OracleConnection("DATA SOURCE=(DESCRIPTION =" +
  " (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-1T51EVG)(PORT = 1521))" +
  " (CONNECT_DATA =" +
     "(SERVER = DEDICATED)" +
    " (SERVICE_NAME = orcl)" +
   ")" +
" );User Id=system;Password=h123");
        public homecontrol()
        {
            InitializeComponent();
        }

        private void homecontrol_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
