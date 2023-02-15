using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace login
{
    public partial class login : Form
    {
        OracleConnection cn = new OracleConnection("DATA SOURCE=(DESCRIPTION =" +
  " (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-1T51EVG)(PORT = 1521))" +
  " (CONNECT_DATA =" +
     "(SERVER = DEDICATED)" +
    " (SERVICE_NAME = orcl)" +
   ")" +
" );User Id=system;Password=h123");
        Change c= new Change();
        main m = new main ();
     
        public login()
        {
            InitializeComponent();
        }
        private void btn_enter_Click_1(object sender, EventArgs e)
        {
            OracleDataAdapter oda = new OracleDataAdapter("Select count(*)From Users where user_name='" + tbname.Text + "' and password='" + tbpass.Text + "'", cn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                main m = new main();
                m.Show();
            }
            else
            {
                MessageBox.Show("please enter correct user and password");
            }


        }




        private void linkL_forget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            c.Text = "Change ..MSFA";
          
            this.Hide();
            c.ShowDialog();
            //textBox3.Visible = true;
           // label2.Visible = true;
        }

       

        

        private void tbname_TextChanged(object sender, EventArgs e)
        {
            tbpass.Enabled = true;
        }



        private void btn_colse_Click(object sender, EventArgs e)
        {
            Close();
        }

      


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
           if( tbpass.UseSystemPasswordChar == true)
            {
                tbpass.UseSystemPasswordChar = false;
            }
           else
                tbpass.UseSystemPasswordChar = true;

        }

        private void tbpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void btn_userName_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
