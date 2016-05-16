using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace WindowsFormsApplication3
{
   public class Readfromexml
    {
        public string mode { get; set; }
        public string remoteip { get; set; }
        public string formenabled { get; set; }
        public string run { get; set; }
        public string error { get; set; }

        public string Database { get; set; }
        public string Server { get; set; }
        public string Password { get; set; }
        public string Remothostname { get; set; }
        public string Dbuser { get; set; }
        public string Port { get; set; }
        public bool Stop { get; set; }


        
        

        public Readfromexml(string namexml)
        {
            try
            {
                string path;
                path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);//get the path of the exe
                XmlDocument doc = new XmlDocument();
                doc.Load(path+"\\"+namexml);
                path = null;
                XmlNode node = doc.DocumentElement.SelectSingleNode("mode");
                mode = node.InnerText;
                XmlNode node2 = doc.DocumentElement.SelectSingleNode("remoteip");
                remoteip = node2.InnerText;
                XmlNode node3 = doc.DocumentElement.SelectSingleNode("database");
                Database = node3.InnerText;
                XmlNode node4 = doc.DocumentElement.SelectSingleNode("server");
                Server = node4.InnerText;
                XmlNode node5 = doc.DocumentElement.SelectSingleNode("password");
                Password = node5.InnerText;
                XmlNode node6 = doc.DocumentElement.SelectSingleNode("dbuser");
                Dbuser = node6.InnerText;
                XmlNode node7 = doc.DocumentElement.SelectSingleNode("port");
                Port = node7.InnerText;
                doc = null;
                node = null;
            }
            catch (Exception exp)
            {
                
                error="ERROR IN Reading from config xml:" + exp.ToString();
                string path;
                path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);//get the path of the exe
                path =  "C:\\Log.txt";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {

                    file.WriteLine(error + "|" + DateTime.Now.ToString() + "\n");

                };

            }
           
            

        }



    }
}
