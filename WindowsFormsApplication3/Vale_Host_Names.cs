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
    public partial class Vale_Host_Names : Form
    {
        public Vale_Host_Names(Readfromexml nprmtrs)//pass parameters to this form
        {
            InitializeComponent();
            prmtrs = nprmtrs;

        }
       
        private Readfromexml prmtrs;
        private void Vale_Host_Names_Load(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection("user id=" + prmtrs.Dbuser + ";" + "password=" + prmtrs.Password + ";server=" + prmtrs.Server + ";" + "Trusted_Connection=no;" + "database=" + prmtrs.Database + "; " + "connection timeout=30");
            SqlCommand sqlcom = new SqlCommand("select NAME,IP from WHMUSERS", sqlcon);//connect to sql in table test1
            sqlcon.Open();
            SqlDataReader sqlrdr = sqlcom.ExecuteReader();//execute querry and pass it to list box
            dataTable1.Load(sqlrdr);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dataTable1;
            dataGridView1.Refresh();


            sqlcon.Close();
            sqlcon.Dispose();
            sqlcom.Dispose();


            GC.Collect();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
