using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiveMLauncher2
{
    public partial class Form2 : Form
    {
        public string IP = "rp.mystic.ro:30120";
        public Form2()
        {
            InitializeComponent();
    }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.TopMost = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Se face conexiunea cu serverul...";
            timer1.Stop();

            timer2.Start();
            Process.Start("fivem://connect/" + IP);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            //Form1 frm = new Form1();
            Process[] fivemProcess = Process.GetProcessesByName("FiveM");
           /* if (frm.checkBox1.Checked)
            {
                if (fivemProcess.Length > 0)
                {
                    Application.Exit();
                }
            }
            else
            {*/
                this.Visible = false;
            //}
        }
    }
}
