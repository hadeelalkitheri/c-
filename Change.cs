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
    public partial class Change : Form
    {
        OracleConnection cn = new OracleConnection("DATA SOURCE=(DESCRIPTION =" +
" (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-1T51EVG)(PORT = 1521))" +
" (CONNECT_DATA =" +
 "(SERVER = DEDICATED)" +
" (SERVICE_NAME = orcl)" +
")" +
" );User Id=system;Password=h123");

        main m = new main();
        // login l = new login();
       // string username;
        //string password;
        public Change()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            
            if (textchangename.Text=="" || texchangepass.Text == "")
            {
                MessageBox.Show("Do you enter name, password ? ");

            }
            else
            {
                try {
                    OracleCommand cmd;
                    cmd = new OracleCommand("update Users set user_name='" + textchangename.Text + "'where password=" + texchangepass.Text + "  ", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    OracleDataAdapter Da;
                    Da = new OracleDataAdapter("select * from Users ", cn);
                    DataTable dt = new DataTable();
                    Da.Fill(dt);

                    m.ShowDialog();
                    this.Hide();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
         

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Change_Load(object sender, EventArgs e)
        {

        }

        private void Change_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* DialogResult result = MessageBox.Show("Do you want exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result==DialogResult.OK)
            {
                this.Close();
            }*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
