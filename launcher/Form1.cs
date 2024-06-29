using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FiveMLauncher2
{
    public partial class Form1 : Form
    {
        public static string IP = "rp.mystic.ro:30120";
        public static string discordInv = "https://discord.gg/se6YRgS";
        public static string website = "http://mystic.ro";
        Form2 f2 = new Form2();
        public Form1()
        { 
            InitializeComponent();
             WebClient wc = new WebClient();
            try
            {
                button1.Enabled = true;

                var players = wc.DownloadString("http://" + IP + "/players.json");
                var svInfo = wc.DownloadString("http://" + IP + "/info.json");

                dynamic svData = JsonConvert.DeserializeObject<dynamic>(svInfo);
                dynamic playerData = JsonConvert.DeserializeObject<dynamic>(players);
                string playerSlots = svData["vars"]["sv_maxClients"].ToString();
                int totalPlayers = playerData.Count;
                string uptime = svData["vars"]["UpTime"].ToString();

                label1.Text = "Jucatori: " + totalPlayers + " / " + playerSlots;
                label4.Text = "UpTime: " + uptime;

                label3.Text = "ONLINE";
                label3.ForeColor = System.Drawing.Color.Green;

                listBox1.Items.Clear();
                if (playerData.Count > 0)
                {
                    foreach (var plr in playerData)
                    {
                        var userID = wc.DownloadString(website + "/others/servers/fivem/rp/launcher/info.php?act=findID&identifier=" + plr["identifiers"][0].ToString());
                        
                        listBox1.Items.Add("[" + userID + "] " + plr["name"].ToString());
                    }
                }
                else
                {
                    listBox1.Items.Add("NICI UN JUCATOR ONLINE");
                }

            }
            catch (Exception)
            {
                label3.Text = "OFFLINE";
                label3.ForeColor = System.Drawing.Color.Red;
                button1.Enabled = false;
                listBox1.Items.Add("SERVER OFFLINE");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Process.Start("fivem://connect/" + IP);

            /* Process[] fivemProcess = Process.GetProcessesByName("FiveM");
             if (checkBox1.Checked) { 
                 if (fivemProcess.Length > 0)
                 {
                     this.Close();
                 }
             }*/
            f2.ShowDialog(this);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(discordInv);
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
