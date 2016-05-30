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

        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommandBuilder sqlcmb = null;
        SqlConnection sqlcon;

        private void Vale_Host_Names_Load(object sender, EventArgs e)
        {
             sqlcon = new SqlConnection("user id=" + prmtrs.Dbuser + ";" + "password=" + prmtrs.Password + ";server=" + prmtrs.Server + ";" + "Trusted_Connection=no;" + "database=" + prmtrs.Database + "; " + "connection timeout=30");
            sqlcon.Open();
            
            sqlda.SelectCommand = new SqlCommand("select NAME,IP,recno from WHMUSERS", sqlcon);//connect to sql in table test1
            
            sqlda.Fill(dataTable1);
            sqlcmb = new SqlCommandBuilder(sqlda);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoResizeColumns();
            dataGridView1.DataSource = dataTable1;
            
            dataGridView1.Refresh();
            
            
         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {
             
          
        }

       

        private void Save_Click(object sender, EventArgs e)
        {
           
            sqlda.UpdateCommand = sqlcmb.GetUpdateCommand();
            sqlda.Update(dataTable1);
           


     
        }

        private void Vale_Host_Names_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlcon.Close();
            sqlda.Dispose();
            GC.Collect();

        }

        
    }
}
