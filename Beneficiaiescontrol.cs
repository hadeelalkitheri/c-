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
    public partial class Beneficiaiescontrol : UserControl
    {
        OracleConnection cn = new OracleConnection("DATA SOURCE=(DESCRIPTION =" +
    " (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-1T51EVG)(PORT = 1521))" +
    " (CONNECT_DATA =" +
       "(SERVER = DEDICATED)" +
      " (SERVICE_NAME = orcl)" +
     ")" +
  " );User Id=system;Password=h123");
        OracleDataAdapter Da;
        OracleCommand cmd;
        public Beneficiaiescontrol()
        {
            InitializeComponent();
        }
        private void print()
        {
            
            DataTable dt = new DataTable();
            cn.Open();
            Da = new OracleDataAdapter("select *from Beneficiaries", cn);
            var ds=new DataSet();
            Da.Fill(dt);
            dataGridViewBeneficiaies.DataSource = dt;
            cn.Close();

        }

        

        private void usercontrol_Load(object sender, EventArgs e)
        {   //sequence by order default
            cn.Open();
            OracleCommand cmd;
            cmd = new OracleCommand("Select max(id_needed)+1 from Beneficiaries", cn);
            object myval = cmd.ExecuteScalar();
            txtIDBen.Text = myval.ToString();
            cn.Close();
            print();

            OracleDataAdapter da4;
            DataTable dt4 = new DataTable();
            da4 = new OracleDataAdapter("Select *FROM Employees", cn);
            dt4 = new DataTable();
            da4.Fill(dt4);
            comBoxEmp_for_Bene.DataSource = dt4;
            comBoxEmp_for_Bene.DisplayMember = "first_name";
            comBoxEmp_for_Bene.ValueMember = "id_employees";


            //string Oracle = "Select *FROM Type_beneficiaries  ";
            //OracleDataAdapter da = new OracleDataAdapter("Select * FROM Type_beneficiaries", cn);
            OracleDataAdapter da;
            DataTable dt = new DataTable();
            da = new OracleDataAdapter("Select * FROM Type_beneficiaries", cn);
             dt = new DataTable();
            da.Fill(dt);
            comBox_type_need_Bene.DataSource = dt;
            comBox_type_need_Bene.DisplayMember = "type";
            comBox_type_need_Bene.ValueMember = "id_type_beneficiaries";


            // Oracle = "Select *FROM Materials   ";
            //OracleDataAdapter da2 = new OracleDataAdapter("Select * FROM Employees", cn);
            OracleDataAdapter da2;
            DataTable dt2 = new DataTable();
            da2 = new OracleDataAdapter("Select *FROM Materials", cn);
            dt2 = new DataTable();
            da2.Fill(dt2);
            comBox_id_materialBene.DataSource = dt2;
            comBox_id_materialBene.DisplayMember = "type_donation";
            comBox_id_materialBene.ValueMember = "id_material";
            /*
            */
            


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try {
                cn.Open();
                OracleCommand cmd = new OracleCommand();                                                                                                                                                                                                     // this.comBox_don.SelectedValue.ToString()                                                 
                cmd.Connection = cn;
                cmd.CommandText = "insert into Beneficiaries values (" + this.txtIDBen.Text + ",'" + this.txtFNameBene.Text + "','" + this.txtLNameBene.Text + "','" + this.txtage_bn.Text + "','" + this.txt_add_Bene.Text + "','" + this.comBoxEmp_for_Bene.SelectedValue.ToString()+ "','" + this.comBox_type_need_Bene.SelectedValue.ToString() + "','" + this.comBox_id_materialBene.SelectedValue.ToString() + "')";


                cmd.ExecuteNonQuery();
                cn.Close();

                
                
                Da = new OracleDataAdapter("select *from Beneficiaries", cn);
                DataTable dt = new DataTable();
                Da.Fill(dt);
                dataGridViewBeneficiaies.DataSource = dt;
                MessageBox.Show("Insert ");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void txtFNameBene_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comBoxEmp_for_Bene_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comBox_type_need_Bene_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cl_btn_Click(object sender, EventArgs e)
        {
            //txtIDBen.Clear();
            txtFNameBene.Clear();
            txtLNameBene.Clear();
            txtage_bn.Clear();
            txt_add_Bene.Clear();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {// + "'," + this. + ",'" + this. + "'," + this. + "," + this.comBox_type_need_Bene.Text + ","+ this.+")";

            if (txtIDBen.Text=="" || txtFNameBene.Text=="" || txtLNameBene.Text=="" || txtage_bn.Text=="" || txt_add_Bene.Text==""|| comBoxEmp_for_Bene.Text==""||comBox_type_need_Bene.Text ==""|| comBox_id_materialBene.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {


                    cmd = new OracleCommand("update Beneficiaries set first_name= '" + this.txtFNameBene.Text + "',last_name='" + this.txtLNameBene.Text + "',age=" + this.txtage_bn.Text + ",Address='" + this.txt_add_Bene.Text + "',id_employees=" + this.comBoxEmp_for_Bene.SelectedValue.ToString() + ",type_need_num=" + this.comBox_type_need_Bene.SelectedValue.ToString() + ", id_material='" + this.comBox_id_materialBene.SelectedValue.ToString() + "' where id_needed= " +this.txtIDBen.Text+ "  ", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update Beneficiaries Successfuly");
                    cn.Close();
                    print();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.Open();
            OracleCommand cmd = new OracleCommand("Delete FROM Beneficiaries Where id_needed='" + txtIDBen.Text + "'  ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete Done");
            cn.Close();

            print();
        }

        private void dataGridViewBeneficiaies_Click(object sender, EventArgs e)
        {

            txtIDBen.Text = dataGridViewBeneficiaies.CurrentRow.Cells["id_needed"].Value.ToString();
            txtFNameBene.Text = dataGridViewBeneficiaies.CurrentRow.Cells["first_name"].Value.ToString();
            txtLNameBene.Text = dataGridViewBeneficiaies.CurrentRow.Cells["last_name"].Value.ToString();
            txtage_bn.Text = dataGridViewBeneficiaies.CurrentRow.Cells["age"].Value.ToString();
            txt_add_Bene.Text = dataGridViewBeneficiaies.CurrentRow.Cells["Address"].Value.ToString();
            comBoxEmp_for_Bene.SelectedValue = dataGridViewBeneficiaies.CurrentRow.Cells["id_employees"].Value.ToString();
            comBox_type_need_Bene.SelectedValue = dataGridViewBeneficiaies.CurrentRow.Cells["type_need_num"].Value.ToString();
            comBox_id_materialBene.SelectedValue = dataGridViewBeneficiaies.CurrentRow.Cells["id_material"].Value.ToString();

        }
    }
}
