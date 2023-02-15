using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class load : Form
    {
        main m = new main();
        int progress = 0;
        public load()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void load_Load(object sender, EventArgs e)
        {  //enable and set intervall
            timer1.Enabled = true;
            timer1.Interval = 50;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {  //increment our progress value
            progress += 1;
            //if it reaches 100,stop
            if (progress >= 100)
            {
                timer1.Enabled = false;
                timer1.Stop();
                this.Hide();
                //call main form
                login l = new login();
                l.Show();
            }
            //otherwise
            progressBar1.Value = progress;


        }


    }
}
