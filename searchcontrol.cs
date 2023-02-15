using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
namespace login
{
    public partial class searchcontrol : UserControl
    {
        OracleConnection cn = new OracleConnection("DATA SOURCE=(DESCRIPTION =" +
   " (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-1T51EVG)(PORT = 1521))" +
   " (CONNECT_DATA =" +
      "(SERVER = DEDICATED)" +
     " (SERVICE_NAME = orcl)" +
    ")" +
 " );User Id=system;Password=h123");
        public searchcontrol()
        {
            InitializeComponent();
        }
        private void print1()
        {
            OracleDataAdapter Da;
            DataTable dt = new DataTable();
            cn.Open();
            Da = new OracleDataAdapter("select *from Beneficiaries", cn);
            var ds = new DataSet();
            Da.Fill(dt);
            dataGridViewsearchBeneficialtes.DataSource = dt;
            cn.Close();

        }

        private void print2()
        {
            OracleDataAdapter Da;
            DataTable dt = new DataTable();
            cn.Open();
            Da = new OracleDataAdapter("select *from Donors", cn);
            var ds = new DataSet();
            Da.Fill(dt);
            dataGridViewsearchDonors.DataSource = dt;
            cn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                cn.Open();
                OracleCommand cmd;
                cmd = new OracleCommand("Select *from Beneficiaries where id_needed=" + txtSearhbeneficialies.Text + " ", cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewsearchBeneficialtes.DataSource = dt;
                cn.Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewsearch1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {  
            try
            {
                cn.Open();
                OracleCommand cmd;
                cmd = new OracleCommand("Select *from Donors where id_donor=" + txtSearch_Donors.Text + " ", cn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewsearchDonors.DataSource = dt;
                cn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchcontrol_Load(object sender, EventArgs e)
        {
            

        }
    }
}
