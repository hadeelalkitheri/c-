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
    public partial class Donatecontrol : UserControl
    {
        OracleConnection cn = new OracleConnection("DATA SOURCE=(DESCRIPTION =" +
  " (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-1T51EVG)(PORT = 1521))" +
  " (CONNECT_DATA =" +
     "(SERVER = DEDICATED)" +
    " (SERVICE_NAME = orcl)" +
   ")" +
" );User Id=system;Password=h123");
        //SqlConnection cn = new SqlConnection(@"Server=DESKTOP-0OF4CD9\SQLEXPRESS;DataBase=agricultural_DB;Integrated Security=true;");
        //SqlDataAdapter Da;
        //DataSet Ds;
        DataTable Dt = new DataTable();
       

        public Donatecontrol()
        {
            InitializeComponent();
        }
        private void print()
        {
            OracleDataAdapter Da;
            DataTable dt = new DataTable();
            cn.Open();
            Da = new OracleDataAdapter("select *from Donate", cn);
            var ds = new DataSet();
            Da.Fill(dt);
            dataGridViewDonate.DataSource = dt;
            cn.Close();

        }
        private void settingcontrol_Load(object sender, EventArgs e)
        {   //squence
            cn.Open();
            OracleCommand cmd;
            cmd = new OracleCommand("Select max(id_material)+1 from Donate", cn);
            object myval = cmd.ExecuteScalar();
            comBox_id_materialBene.SelectedValue = myval.ToString();
            cn.Close();

            //
            print();
            OracleDataAdapter da2;
            DataTable dt2 = new DataTable();
            da2 = new OracleDataAdapter("Select *FROM Materials", cn);
            dt2 = new DataTable();
            da2.Fill(dt2);
            comBox_id_materialBene.DataSource = dt2;
            comBox_id_materialBene.DisplayMember = "type_donation";
            comBox_id_materialBene.ValueMember = "id_material";

            OracleDataAdapter da3;
            DataTable dt3 = new DataTable();
            da3 = new OracleDataAdapter("Select *FROM donors", cn);
            dt3 = new DataTable();
            da3.Fill(dt3);
            comboBox2.DataSource = dt3;
            comboBox2.DisplayMember = "first_name";
            comboBox2.ValueMember = "id_donor";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                cn.Open();
                 string dd = dateTimePicker1.Value.Day.ToString() + '/' + dateTimePicker1.Value.Day.ToString() + '/' + dateTimePicker1.Value.Year.ToString();
                // string quntity = numericQuentity_Mat.Value.ToString();
                //dateTimePicker1.Value.ToString("yyyy/MM/dd 00:00:00")
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Donate values ('" + this.comBox_id_materialBene.SelectedValue.ToString() + "','" + this.comboBox2.SelectedValue.ToString() + "','" + dd+ "'," + txtquDonate.Text + ")";

                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("insert sucessful ");
                print();

               /* OracleDataAdapter Da;
                Da = new OracleDataAdapter("select *from Donate", cn);
                DataTable dt = new DataTable();
                Da.Fill(dt);
                dataGridViewDonate.DataSource = dt;
                
                MessageBox.Show("insert sucessful ");*/

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            cn.Open();
            OracleCommand cmd = new OracleCommand("Delete FROM Donate Where id_material='" + comBox_id_materialBene.SelectedValue.ToString() + "'  ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete Done");
            cn.Close();

            print();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string dd = dateTimePicker1.Value.Day.ToString() + '/' + dateTimePicker1.Value.Month.ToString() + '/' + dateTimePicker1.Value.Year.ToString();

            if (this.comBox_id_materialBene.Text==""|| this.comboBox2.Text == "" || dd == "" || txtquDonate.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                { 
                    OracleCommand cmd;
                    cn.Open();
                    cmd = new OracleCommand("select id_donor from Donate where id_donor=' " + this.comboBox2.SelectedValue.ToString() + " '", cn);

                    object myvalue = cmd.ExecuteScalar();
                    string pasDonor = Convert.ToString(myvalue);

                     cmd = new OracleCommand("update Donate set  id_material= '" + this.comBox_id_materialBene.SelectedValue.ToString() +"',id_donor = '" + this.comboBox2.SelectedValue.ToString() + "',date_material='" + dd + "',quentity=" + this.txtquDonate.Text + "   where id_material= '" + comBox_id_materialBene.SelectedValue.ToString() + " 'and id_donor='"+ pasDonor+ "' ", cn);
                      
                    //cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update Donate  Successfuly");
                    cn.Close();
                    print();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

              
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void cl_btn_Click(object sender, EventArgs e)
        {
            txtquDonate.Clear();
        }

        private void dataGridViewDonate_Click(object sender, EventArgs e)
        {
           /* string dd = dateTimePicker1.Value.Day.ToString() + '/' + dateTimePicker1.Value.Day.ToString() + '/' + dateTimePicker1.Value.Year.ToString();

            comBox_id_materialBene.SelectedValue = dataGridViewDonate.CurrentRow.Cells["id_material"].Value.ToString();
            comboBox2.SelectedValue = dataGridViewDonate.CurrentRow.Cells["id_donor"].Value.ToString();
            dd = dataGridViewDonate.CurrentRow.Cells["date_material"].Value.ToString();
            txtquDonate.Text = dataGridViewDonate.CurrentRow.Cells["quentity"].Value.ToString();
            */

        }

        private void dataGridViewDonate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewDonate_Click_1(object sender, EventArgs e)
        {
            string dd = dateTimePicker1.Value.Day.ToString() + '/' + dateTimePicker1.Value.Day.ToString() + '/' + dateTimePicker1.Value.Year.ToString();

            comBox_id_materialBene.SelectedValue = dataGridViewDonate.CurrentRow.Cells["id_material"].Value.ToString();
            comboBox2.SelectedValue = dataGridViewDonate.CurrentRow.Cells["id_donor"].Value.ToString();
            dd = dataGridViewDonate.CurrentRow.Cells["date_material"].Value.ToString();
            txtquDonate.Text = dataGridViewDonate.CurrentRow.Cells["quentity"].Value.ToString();


        }
    }
}
