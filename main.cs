using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client; 

namespace login
{
    public partial class main : Form
    {
        // SqlConnection cn = new SqlConnection("@Server=DESKTOP-0OF4CD9\SQLEXPRESS;DataBase=agricultural_DB;Integrated Security=true;");
        OracleConnection cn = new OracleConnection("DATA SOURCE=(DESCRIPTION =" +
  " (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-1T51EVG)(PORT = 1521))" +
  " (CONNECT_DATA =" +
     "(SERVER = DEDICATED)" +
    " (SERVICE_NAME = orcl)" +
   ")" +
" );User Id=system;Password=h123");
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            homecontrol hc = new homecontrol();
            showcontrol(hc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Beneficiaiescontrol uc = new Beneficiaiescontrol(); 
            showcontrol(uc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employeescontrol ab = new Employeescontrol();
            showcontrol(ab);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Donorscontrol rc = new Donorscontrol();
            showcontrol(rc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            searchcontrol sc = new searchcontrol();
            showcontrol(sc);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            materialscontrol pc = new materialscontrol();
            showcontrol(pc);
        }
        public void showcontrol(Control control)
        {
            content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();
            content.Controls.Add(control);


        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            Donatecontrol sc2 = new Donatecontrol();
            showcontrol(sc2);
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
