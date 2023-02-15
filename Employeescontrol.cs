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
//using Oracle.ManagedDataAccess.Types;

using System.Configuration;
namespace login
{
    public partial class Employeescontrol : UserControl
    {
        OracleConnection cn = new OracleConnection("DATA SOURCE=(DESCRIPTION =" +
   " (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-1T51EVG)(PORT = 1521))" +
   " (CONNECT_DATA =" +
      "(SERVER = DEDICATED)" +
     " (SERVICE_NAME = orcl)" +
    ")" +
 " );User Id=system;Password=h123");
        public Employeescontrol()
        {
            InitializeComponent();
        }
         private void print()
        {
            DataTable dt = new DataTable();
            cn.Open();
            OracleDataAdapter Da;
            Da = new OracleDataAdapter("Select * From Employees ", cn);
            var ds = new DataSet();
            Da.Fill(dt);
            dataGridViewEmployees1.DataSource = dt;
            cn.Close();

            /*cn.Open();
            OracleDataAdapter sda = new OracleDataAdapter("Select * from Employees", cn);

            OracleCommandBuilder builder = new OracleCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewEmployees1.DataSource = ds.Tables[0];
            cn.Close();*/

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            OracleCommand cmd=new OracleCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert into Employees values (" + this.txtIDEmp.Text + ",'" + this.txtFNameEmp.Text + "','" + this.txtLNameEmp.Text + "'," + this.txtPhone_NEmp.Text + ",'" + this.txt_add_Emp.Text + "','" + this.txtEmail_Emp.Text + "')";
            

            cmd.ExecuteNonQuery();
            MessageBox.Show("insert sucessful ");
            cn.Close();
            print();

            /* OracleDataAdapter da = new OracleDataAdapter("Select *from Employees ", cn);
             DataTable dt = new DataTable();
             da.Fill(dt);
             dataGridViewEmployees1.DataSource = dt;
             MessageBox.Show("insert sucessful ");*/


        }

        private void txtLNameEmp_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "Delete  Employees Where id_employees ='" + this.txtIDEmp.Text + "' ";
                cmd.ExecuteNonQuery();
                cn.Close();
                //Print function
                OracleDataAdapter da = new OracleDataAdapter("Select *from Employees ", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewEmployees1.DataSource = dt;
                MessageBox.Show("delete sucessful ");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
                if (txtIDEmp.Text == "" || txtFNameEmp.Text == "" || txtFNameEmp.Text == "" || txtLNameEmp.Text == "" || txtPhone_NEmp.Text == "" || txt_add_Emp.Text == "" || txtEmail_Emp.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
            else
            {
                try
                {
                    OracleCommand cmd;
                     cmd = new OracleCommand("Update Employees set first_name='" + this.txtFNameEmp.Text + "',last_name='" + this.txtLNameEmp.Text + "',phone_num=" + this.txtPhone_NEmp.Text + ",Address='" + this.txt_add_Emp.Text + "',email='" + this.txtEmail_Emp.Text + "'Where id_employees=" + this.txtIDEmp.Text + "", cn);
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
            // cmd.CommandText = "Update Employees set first_name='" + this.txtFNameEmp.Text + "',last_name='" + this.txtLNameEmp.Text + "',phone_num=" + this.txtPhone_NEmp.Text + ",Address='" + this.txt_add_Emp.Text + "',email='" + this.txtEmail_Emp.Text + "'Whare id_employees=" + this.txtIDEmp.Text + "";
            // if (txtIDEmp.Text ==""|| txtFNameEmp.Text ==""|| txtFNameEmp.Text == ""|| txtLNameEmp.Text == "" ||txtPhone_NEmp.Text == "" ||txt_add_Emp.Text = "" ||txtEmail_Emp.Text == "")

            // dataGridViewEmployees1.DataSource = dt;
            // MessageBox.Show("Update sucessful ");
        }

        private void cl_btn_Click(object sender, EventArgs e)
        {
            //txtIDEmp.Clear();
            txtFNameEmp.Clear();
            txtLNameEmp.Clear();
            txtPhone_NEmp.Clear();
            txt_add_Emp.Clear();
            txtEmail_Emp.Clear();
        }

        private void Employeescontrol_Load(object sender, EventArgs e)
        {   //make squence id by order
            cn.Open();
            OracleCommand cmd;
            cmd = new OracleCommand("Select max(id_employees)+1 from Employees", cn);
            object myval = cmd.ExecuteScalar();
            txtIDEmp.Text = myval.ToString();
            cn.Close();
            print();
        }

        private void dataGridViewEmployees1_Click(object sender, EventArgs e)
        {
            txtIDEmp.Text = dataGridViewEmployees1.CurrentRow.Cells["id_employees"].Value.ToString();
            txtFNameEmp.Text = dataGridViewEmployees1.CurrentRow.Cells["first_name"].Value.ToString();
            txtLNameEmp.Text = dataGridViewEmployees1.CurrentRow.Cells["last_name"].Value.ToString();
            txtPhone_NEmp.Text = dataGridViewEmployees1.CurrentRow.Cells["phone_num"].Value.ToString();
            txt_add_Emp.Text = dataGridViewEmployees1.CurrentRow.Cells["Address"].Value.ToString();
            txtEmail_Emp.Text = dataGridViewEmployees1.CurrentRow.Cells["email"].Value.ToString();


        }
    }
    }
    

