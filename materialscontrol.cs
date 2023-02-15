using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Oracle.ManagedDataAccess.Client;
namespace login
{
    public partial class materialscontrol : UserControl
    {
        OracleConnection cn = new OracleConnection("DATA SOURCE=(DESCRIPTION =" +
   " (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-1T51EVG)(PORT = 1521))" +
   " (CONNECT_DATA =" +
      "(SERVER = DEDICATED)" +
     " (SERVICE_NAME = orcl)" +
    ")" +
 " );User Id=system;Password=h123");
        UserControl user = new UserControl();
        main m = new main();
       
        public materialscontrol()
        {
            InitializeComponent();
        }
        private void print()
        {
            OracleDataAdapter Da;
            DataTable dt = new DataTable();
            cn.Open();
            Da = new OracleDataAdapter("select *from Materials", cn);
            var ds = new DataSet();
            Da.Fill(dt);
            dataGridViewMatrial.DataSource = dt;
            cn.Close();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {//,'" + this.txtFNameBene.Text + "','" + this.txtLNameBene.Text + "','" + this.txtage_bn.Text + "','" + this.txt_add_Bene.Text + "','" + this.comBoxEmp_for_Bene.
                cn.Open();
                OracleCommand cmd = new OracleCommand();                                                                                                                                                       // this.comBox_don.SelectedValue.ToString() comBoxEmp_for_Matei                                                
                cmd.Connection = cn;
                //
                cmd.CommandText = "insert into Materials values (" + this.textBox1.Text+ ",'" + this.comboT_Ben.SelectedValue.ToString() + "'," + this.txtqun.Text + ",'" + this.comBoxEmp_for_Matei.SelectedValue.ToString() + "')";

                // cmd.CommandText = "insert into Materials values ('" + this.comBox_id_material.SelectedValue.ToString() + "','" + this.comboT_Ben.SelectedValue.ToString() + "'," + this.txtqun.Text + ",'" + this.comBoxEmp_for_Matei.SelectedValue.ToString() + "')";


                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Insert ");
                print();


                /* OracleDataAdapter Da;
                 Da = new OracleDataAdapter("select *from Materials", cn);
                 DataTable dt = new DataTable();
                 Da.Fill(dt);
                 dataGridViewMatrial.DataSource = dt;
                 MessageBox.Show("Insert ");*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void materialscontrol_Load(object sender, EventArgs e)
        {   //sequence by order default
            cn.Open();
            OracleCommand cmd;
            cmd = new OracleCommand("Select max(id_material) from Materials", cn);
            object myval = cmd.ExecuteScalar();
            textBox1.Text = myval.ToString();
            cn.Close();

            print();
           /* OracleDataAdapter da2;
            DataTable dt2 = new DataTable();
            da2 = new OracleDataAdapter("Select *FROM Materials", cn);
            dt2 = new DataTable();
            da2.Fill(dt2);
            comBox_id_material.DataSource = dt2;
            comBox_id_material.DisplayMember = "type_donation";
            comBox_id_material.ValueMember = "id_material";*/
            //=====================================================

            

            OracleDataAdapter da4;
            DataTable dt4 = new DataTable();
            da4 = new OracleDataAdapter("Select *FROM Employees", cn);
            dt4 = new DataTable();
            da4.Fill(dt4);
            comBoxEmp_for_Matei.DataSource = dt4;
            comBoxEmp_for_Matei.DisplayMember = "first_name";
            comBoxEmp_for_Matei.ValueMember = "id_employees";
            //=========================================================
             OracleDataAdapter da3;
             DataTable dt3 = new DataTable();
             da3 = new OracleDataAdapter("Select *FROM Type_beneficiaries", cn);
             dt3 = new DataTable();
             da3.Fill(dt3);
             comboT_Ben.DataSource = dt3;
             comboT_Ben.DisplayMember = "type";
            comboT_Ben.ValueMember="id_type_beneficiaries";
       
            // comboT_Ben.ValueMember = "type";
            // comboT_Ben.ValueMember = "id_material";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.Open();
            OracleCommand cmd = new OracleCommand("Delete FROM Materials Where id_material=" + this.textBox1.Text + "", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete Done");
            cn.Close();
            print();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*cmd.CommandText = "insert into Materials values (" + this.textBox1.eTxt+ ",'" + this.comboT_Ben.SelectedValue.ToString() + "'," + this.txtqun.Text + ",'" + this.comBoxEmp_for_Matei.SelectedValue.ToString() + "')";*/
            if(this.textBox1.Text==""|| this.comboT_Ben.Text==""|| this.txtqun.Text==""|| this.comboT_Ben.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    OracleCommand cmd;
                    cmd = new OracleCommand("update Materials set quentity=" + this.txtqun.Text + ",id_employees='" + this.comBoxEmp_for_Matei.SelectedValue.ToString() + "' where id_material= " + this.textBox1.Text + "  ", cn);
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

        private void dataGridViewMatrial_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridViewMatrial.CurrentRow.Cells["id_material"].Value.ToString();
            // comboT_Ben.SelectedValue = dataGridViewMatrial.CurrentRow.Cells["id_type_beneficiaries"].Value.ToString();
            txtqun.Text = dataGridViewMatrial.CurrentRow.Cells["quentity"].Value.ToString();
            comBoxEmp_for_Matei.SelectedValue = dataGridViewMatrial.CurrentRow.Cells["id_employees"].Value.ToString();

        }
    }
}
