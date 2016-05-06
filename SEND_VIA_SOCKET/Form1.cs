using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SEND_VIA_SOCKET
{
    public partial class Form1 : Form
    {
        Socket sck;//declare the socket
        EndPoint epLocal, epRemote;

        public Form1()
        {
            InitializeComponent();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                
                initializesocket();
                
            }

            catch (Exception exc1)
            {
                MessageBox.Show(exc1.ToString());
                
            }

        }

        protected void initializesocket()
        {
             sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//initialize the socket 
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)//because on host name can have multiple addressfamilys
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)//i check for ipv4
                {
                    Myip.Text = ip.ToString();
                    Myport.Text = "2000";
                }

            }




            initialization();

         }

        private void initialization()
        {
            try
            {
                epLocal = new IPEndPoint(IPAddress.Parse(Myip.Text), Convert.ToInt32(Myport.Text));
                epRemote = new IPEndPoint(IPAddress.Parse(Remoteip.Text), Convert.ToInt32(Remoteport.Text));
                sck.Bind(epLocal);
                sck.Connect(epRemote);
               
               
            }
            catch (Exception exp2)
            {
                MessageBox.Show(exp2.ToString());
                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            byte[] msg = new byte[1];
            msg[0] = 254;
            sck.Send(msg);
        }

    


        }

        


    }

