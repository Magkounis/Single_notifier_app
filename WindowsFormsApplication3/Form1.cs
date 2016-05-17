using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication3
{
 
    public partial class Form1 : Form
    {
        Readfromexml prmtrs = null;
        Transmitviasocketdatagram transmit = null;
        bool Result = new bool();
        Timer t;

        public Form1()
        {
            InitializeComponent();
            Connect.Text = "Connect";
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            listBox2.SelectedIndexChanged += new EventHandler(listBox2_SelectedIndexChanged);
            button1.Visible = false;
            addIPOrHostnameToolStripMenuItem.Enabled = false;

            prmtrs = new Readfromexml("config.txt");
            transmit=new Transmitviasocketdatagram();
            prmtrs.Remothostname = "test";

             t = new Timer();
            t.Interval = 1;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
            
           

            

            
        }
        

        void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
            prmtrs.remoteip = listBox2.SelectedItem.ToString();
            if (listBox2.SelectedItem.ToString().Trim() != "") prmtrs.remoteip = listBox2.SelectedItem.ToString();
            else prmtrs.remoteip = transmit.getlocalip(listBox1.SelectedItem.ToString().Trim());
        }
        //synchronize the 2 listboxes and if only the host name is available resolve it to ipv4
        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            listBox2.SelectedIndex = listBox1.SelectedIndex;
            prmtrs.remoteip = listBox2.SelectedItem.ToString();
            if (listBox2.SelectedItem.ToString().Trim() != "") prmtrs.remoteip = listBox2.SelectedItem.ToString();
            else prmtrs.remoteip = transmit.getlocalip(listBox1.SelectedItem.ToString().Trim()); 
        }

        void t_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString() + " | " + GC.CollectionCount(0).ToString() + " |";
         
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            button1.Text = "Send";
            button1.Visible = true;
            Connect.Text = "Refresh";
            addIPOrHostnameToolStripMenuItem.Enabled = true;
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                SqlConnection sqlcon = new SqlConnection("user id="+prmtrs.Dbuser+";" + "password="+prmtrs.Password+";server="+prmtrs.Server+";" + "Trusted_Connection=no;" + "database="+prmtrs.Database+"; " + "connection timeout=30");
                SqlCommand sqlcom = new SqlCommand("select NAME,IP from WHMUSERS", sqlcon);//connect to sql in table test1
                sqlcon.Open();
                SqlDataReader sqlrdr = sqlcom.ExecuteReader();//execute querry and pass it to list box


                while (sqlrdr.Read())//while reading add them to list box1,2 hostnames and ip
                {
                    listBox1.Items.Add(sqlrdr.GetString(0)  );
                    listBox2.Items.Add(sqlrdr.GetString(1));
                }
                sqlcon.Close();
                sqlcon.Dispose();
                sqlcom.Dispose();
             

                GC.Collect();
               
                
            }
            catch (Exception e1)
            {string s=e1.ToString();
                writetologfile(e1.Data.Keys.ToString() + " | "+"Error in connecting to sql"+ " | "+s.Substring(1,200));
               // if (e1.Data.Keys==
              //  Dictionary<string, int> d = new Dictionary<string, int>();
                
            }



        }//get hostnames-ips from sqltable and place them in listboxes


        protected void writetologfile(string s)
        {
            string path;
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);//get the path of the exe
            path =  "C:\\Log.txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {

                file.WriteLine(s + "|" + DateTime.Now.ToString() + "\n");

            };


        }

        private void button1_Click(object sender, EventArgs e)
        {
             transmit.initializesocket(ref Result,prmtrs.remoteip,prmtrs.Port);//execute socket initialization and save result to bool result referenced
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addIPOrHostnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vale_Host_Names form2 = new Vale_Host_Names();
            form2.Enabled = true;
            form2.Show();
        }
    }

    public static class parameters
    {
    }
}
