using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                string constring = @"Data Source=mssql-157124-0.cloudclusters.net,10041;Initial Catalog=CafeDB;Persist Security Info=True;User ID=admin;Password=Admin123;";
                SqlConnection con = new SqlConnection(constring);
                con.Open();

                string query = @"SELECT 
                                    od.order_detail_id, 
                                    i.date, 
                                    i.time 
                                 FROM
                                    order_detail od
                                 INNER JOIN 
                                    id i on od.order_detail_id = od.order_detail_id"; // this whole code we select our data from database to show in form
                
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))//we set sqldataadapter = adapter for later use
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt); //we fill our data from database to dt which we set on top
                    dataGridView1.DataSource = dt; //and we push everything to the form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
