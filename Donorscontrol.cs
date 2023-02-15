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
    public partial class Donorscontrol : UserControl
    {
        OracleConnection cn = new OracleConnection("DATA SOURCE=(DESCRIPTION =" +
  " (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-1T51EVG)(PORT = 1521))" +
  " (CONNECT_DATA =" +
     "(SERVER = DEDICATED)" +
    " (SERVICE_NAME = orcl)" +
   ")" +
" );User Id=system;Password=h123");
        public Donorscontrol()
        {
            InitializeComponent();
        }
        private void print()
        {
            OracleDataAdapter Da;
            DataTable dt = new DataTable();
            cn.Open();
            Da = new OracleDataAdapter("select *from Donors", cn);
            var ds = new DataSet();
            Da.Fill(dt);
            dataGridViewDonors.DataSource = dt;
            cn.Close();

        }
        /*void print()
        {
            cn.Open();
            OracleDataAdapter sda = new OracleDataAdapter("Select * from Employees", cn);

            OracleCommandBuilder builder = new OracleCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewEmployees1.DataSource = ds.Tables[0];
            cn.Close();

        }*/



        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void requestcontrol_Load(object sender, EventArgs e)
        {   //squence
            cn.Open();
            OracleCommand cmd;
            cmd = new OracleCommand("Select max(id_donor)+1 from Donors", cn);
            object myval = cmd.ExecuteScalar();
            txtIDon.Text = myval.ToString();
            cn.Close();

            print();
            OracleDataAdapter dar;
            DataTable dtr = new DataTable();
            dar = new OracleDataAdapter("Select *FROM Employees", cn);
            dtr = new DataTable();
            dar.Fill(dtr);
            comBox_don.DataSource = dtr;
            comBox_don.DisplayMember = "first_name";
            comBox_don.ValueMember = "id_employees";

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Donors values (" + this.txtIDon.Text + ",'" + this.comBox_don.SelectedValue.ToString()+ "','" + this.txtFName_Don.Text + "','" + this.txtLNam_Don.Text + "','" + this.txtAddressDon.Text + "','" + this.txtEmailDon.Text + "'," + this.txtPhDon.Text + ")";


                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("insert sucessful ");
                print();
                /*  OracleDataAdapter da;
                  da = new OracleDataAdapter("Select *from Donors ", cn);
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  dataGridViewDonors.DataSource = dt;
                  MessageBox.Show("insert sucessful ");*/

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
           /* cn.Open();
            OracleCommand cmd = new OracleCommand("Delete FROM Donors Where id_donor ='" + txtIDon.Text + "'  ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete Done");
            cn.Close();

            print();*/
             cn.Open();
            OracleCommand cmd = new OracleCommand("Delete FROM Donors Where id_donor ='" + txtIDon.Text+ "'  ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete Done");
            cn.Close();
            print();

            /* cn.Open();
              OracleCommand cmd = new OracleCommand("Delete FROM Donors Where id_donor='" + this.txtIDon.Text + "'", cn);
             cmd.ExecuteNonQuery();
             MessageBox.Show("Delete Done");
             cn.Close();
             print();*/
            /*OracleDataAdapter da = new OracleDataAdapter("Select *from Donors ", cn);
             DataTable dt = new DataTable();
             da.Fill(dt);
             dataGridViewDonors.DataSource = dt;
             MessageBox.Show("delete sucessful ");*/

        }

        private void cl_btn_Click(object sender, EventArgs e)
        {
            //txtIDon.Clear();
            txtFName_Don.Clear();
            txtLNam_Don.Clear();
            txtAddressDon.Clear();
            txtEmailDon.Clear();
            txtPhDon.Clear();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
          

            if (this.txtIDon.Text== "" || this.comBox_don.SelectedValue.ToString() == "" || this.txtFName_Don.Text == "" || this.txtFName_Don.Text == "" || this.txtLNam_Don.Text == "" || this.txtAddressDon.Text == "" || this.txtEmailDon.Text == "" || this.txtPhDon.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {  //cmd.CommandText = "insert into Donors values (" + this.txtIDon.Text + ",'" + this.comBox_don.SelectedValue.ToString()+ "','" + this.txtFName_Don.Text + "','" + this.txtLNam_Don.Text + "','" + this.txtAddressDon.Text + "','" + this.txtEmailDon.Text + "'," + this.txtPhDon.Text + ")";

                    OracleCommand cmd;
                    cmd = new OracleCommand("Update Donors set id_employees='" + this.comBox_don.SelectedValue.ToString() + "', first_name='" + this.txtFName_Don.Text + "',last_name='" + this.txtLNam_Don.Text + "',Address='" + this.txtAddressDon.Text + "',email='" + this.txtEmailDon.Text + "',phone_num='"+ txtPhDon.Text+ "' Where id_donor=" + this.txtIDon.Text + "", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("updata successfuly");
                    cn.Close();
                    print();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridViewDonors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridViewDonors_Click(object sender, EventArgs e)
        {
           /* txtIDon.Text = dataGridViewDonors.CurrentRow.Cells["id_donor"].Value.ToString();
            comBox_don.SelectedValue = dataGridViewDonors.CurrentRow.Cells["id_employees"].Value.ToString();
            txtFName_Don.Text = dataGridViewDonors.CurrentRow.Cells["first_name"].Value.ToString();
            txtLNam_Don.Text = dataGridViewDonors.CurrentRow.Cells["last_name"].Value.ToString();
            txtAddressDon.Text = dataGridViewDonors.CurrentRow.Cells["Address"].Value.ToString();
            txtEmailDon.Text = dataGridViewDonors.CurrentRow.Cells["email"].Value.ToString();
            txtPhDon.Text = dataGridViewDonors.CurrentRow.Cells["phone_num"].Value.ToString();*/

        }

        private void dataGridViewEmployees1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridViewDonors_Click_1(object sender, EventArgs e)
        {
            txtIDon.Text = dataGridViewDonors.CurrentRow.Cells["id_donor"].Value.ToString();
            comBox_don.SelectedValue = dataGridViewDonors.CurrentRow.Cells["id_employees"].Value.ToString();
            txtFName_Don.Text = dataGridViewDonors.CurrentRow.Cells["first_name"].Value.ToString();
            txtLNam_Don.Text = dataGridViewDonors.CurrentRow.Cells["last_name"].Value.ToString();
            txtAddressDon.Text = dataGridViewDonors.CurrentRow.Cells["Address"].Value.ToString();
            txtEmailDon.Text = dataGridViewDonors.CurrentRow.Cells["email"].Value.ToString();
            txtPhDon.Text = dataGridViewDonors.CurrentRow.Cells["phone_num"].Value.ToString();


        }
    }
}
