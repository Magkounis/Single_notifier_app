using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;


namespace WindowsFormsApplication3
{
    class Transmitviasocketdatagram
    {
        Socket sck;
        public Transmitviasocketdatagram()
        {
             
        }


        public String getlocalip(string hostname)//get the  ip of for the host...
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(hostname);
             foreach (IPAddress ip in host.AddressList)//take the ipv4 address and not for other protocolls
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)//if it is AddressFamily ip version 4 (INternetwork family address type)
                {
                  
                    return ip.ToString();
                }

            }
          
            return "169.0.0.1";
        }

        internal void initializesocket(ref bool result, string ip, string port)
        {
            try
            {
                EndPoint epLocal, epRemote;
                sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//initialize a udp socket
                sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);//set socket options
                
                epLocal = new IPEndPoint(IPAddress.Parse(getlocalip(Dns.GetHostName())), Convert.ToInt32(port));//get the local ipv4 of the local pc
                sck.Bind(epLocal);
                epRemote = new IPEndPoint(IPAddress.Parse(ip.Trim()), Convert.ToInt32(port));
                sck.Connect(epRemote);
                send();//send the bite thrue udp
                sck.Close();
                sck.Dispose();//close and dispose the object
                result = true;//set result =true 


            }
            catch (Exception e)
            {

                result = false;
                string error;
                error = "ERROR IN INIT SOCKET:" + e.ToString();//in case of failure write the error to the log file
                string path;
                path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);//get the path of the exe
                path = "C:\\Log.txt";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {

                    file.WriteLine(error + "|" + DateTime.Now.ToString() + "\n");

                };

            }

        }
        protected void send()//send the byte
        {
            byte [] buffer=new byte[1];
            buffer[0] = 254;
            sck.Send(buffer);


        }

    }
}
