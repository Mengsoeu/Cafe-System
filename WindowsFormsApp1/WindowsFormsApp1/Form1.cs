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
    public partial class Form1 : Form
    {

        public static Form1 instance;
        public Label lbl18, lbl19, lbl20, lbl21, lbl22; //public label to use in other form
        private int currentId = 1;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded; //over here everytime i add new data it will add new line in datagrridview
        }
        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Auto-increment the ID when a new row is added
            for (int i = 0; i < e.RowCount; i++)
            {
                dataGridView1.Rows[e.RowIndex + i].Cells["id"].Value = currentId;
                currentId++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }


        protected override void OnFormClosing(FormClosingEventArgs e) //just a verification when you click X(exit)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);//we get form3
            frm3.order = label2.Text; //we push our data from form1 label2 to form3
            frm3.label2.Text = "2"; //we set the price for the drink
            frm3.ShowDialog(this); //show form3

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);
            frm3.order = label3.Text;
            frm3.label2.Text = "1";
            frm3.ShowDialog(this);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);
            frm3.order = label4.Text;
            frm3.label2.Text = "2";
            frm3.ShowDialog(this);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);
            frm3.order = label7.Text;
            frm3.label2.Text = "2";
            frm3.ShowDialog(this);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);
            frm3.order = label6.Text;
            frm3.label2.Text = "3";
            frm3.ShowDialog(this);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);
            frm3.order = label5.Text;
            frm3.label2.Text = "1";
            frm3.ShowDialog(this);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);
            frm3.order = label10.Text;
            frm3.label2.Text = "3";
            frm3.ShowDialog(this);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);
            frm3.order = label9.Text;
            frm3.label2.Text = "2";
            frm3.ShowDialog(this);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(this);
            frm3.order = label8.Text;
            frm3.label2.Text = "2";
            frm3.ShowDialog(this);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)// here our edit code
            {

                int rowIndex = dataGridView1.SelectedCells[0].RowIndex; // this line mean we gonna know which row that the user click on
                int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value); //here we get id from datagridview and convert to int 
                string drink = dataGridView1.Rows[rowIndex].Cells["drink"].Value.ToString(); //here we get drink from datagridview and convert to string
                int qty = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["qty"].Value);
                string size = dataGridView1.Rows[rowIndex].Cells["size"].Value.ToString();
                string sugar = dataGridView1.Rows[rowIndex].Cells["description"].Value.ToString();
                int price = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["price"].Value);

                form2 frm2 = new form2(this, rowIndex, id, drink, qty, size, sugar, price);// over here we open new form which is form2 also we gonna push all data from the top to new form which is form2
                frm2.ShowDialog();
                    
            }
            else
            {
                
            }
            if(e.ColumnIndex == dataGridView1.Columns["del"].Index && e.RowIndex >= 0) // here our delete code
            {
                int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(selectedIndex);// delete the row we selected
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form4 frm2 = new Form4();
            frm2.ShowDialog();
        }

        public void updateData(int rowIndex,string drink, int qty, string size, string sugar, int price)// here is our update function and the code inside () is important cuz it guide us where the user wanna update their data
        {
            dataGridView1.Rows[rowIndex].Cells["qty"].Value = qty;// this line is similar to edit and rowIndex is where we know which row our user want to update
            dataGridView1.Rows[rowIndex].Cells["drink"].Value = drink;
            dataGridView1.Rows[rowIndex].Cells["size"].Value = size;
            dataGridView1.Rows[rowIndex].Cells["description"].Value = sugar;
            dataGridView1.Rows[rowIndex].Cells["price"].Value = price;
        }

        private void SumColumnValues()// here is our total price just grab all data and plus
        {
            int sum = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)//loop select price only from datagridview
            {
                // Ensure the cell value is not null or empty
                if (row.Cells["Price"].Value != null &&
                    !string.IsNullOrEmpty(row.Cells["Price"].Value.ToString()))
                {
                    // Parse the cell value to an integer and add to the sum
                    sum += Convert.ToInt32(row.Cells["Price"].Value);
                }
            }
            
            MessageBox.Show("Total: " + sum.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SumColumnValues();
            try //here is our code when we wanna push all our data to our ssms(sql server management studio)
            {
                string constring = @"Data Source=mssql-157124-0.cloudclusters.net,10041;Initial Catalog=CafeDB;Persist Security Info=True;User ID=admin;Password=Admin123;";//this line we writing a string to connect to our database
                SqlConnection con = new SqlConnection(constring); // we set con = SqlConnection
                con.Open();//here we open our databse to insert our data from winform
                foreach (DataGridViewRow row in dataGridView1.Rows)// we gonna loop cuz when the user input a lot of data
                {
                    if(!row.IsNewRow)//since we write to make our datagridview first have row we have to write
                    {
                        DateTime currentDate = DateTime.Now;//we set datetime = currentDate to get current order

                        string drink = row.Cells["drink"].Value.ToString();
                        int qty = Convert.ToInt32(row.Cells["qty"].Value);
                        string size = row.Cells["size"].Value.ToString();
                        string sugar = row.Cells["description"].Value.ToString();
                        int overall_price = Convert.ToInt32(row.Cells["price"].Value);

                        string formattedDate = currentDate.ToString("yyyy-MM-dd");//here we get only date
                        string formattedDateTime = currentDate.ToString("HH:mm:ss");//here we get only time

                        string query = "insert into order_detail (product_name, qty, size, description, overall_price)" + "VALUES(@drink, @qty, @size, @sugar, @overall_price)";//over here is sql code we insert into our database
                        string query2 = "insert into id (date, time)" + "values(@date, @time)";

                        using (SqlCommand cmd = new SqlCommand(query, con))//here we push the data to our database
                        {
                            cmd.Parameters.AddWithValue("@drink", drink);//we set name to make it easy identify the data like you see in sql values
                            cmd.Parameters.AddWithValue("@qty", qty);
                            cmd.Parameters.AddWithValue ("@size", size);
                            cmd.Parameters.AddWithValue("@sugar", sugar);
                            cmd.Parameters.AddWithValue("@overall_price", overall_price);

                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(query2, con))
                        {
                            cmd.Parameters.AddWithValue("@date", formattedDate);
                            cmd.Parameters.AddWithValue("@time", formattedDateTime);

                            cmd.ExecuteNonQuery ();
                        }
                    }
                }
                MessageBox.Show("Records inserted successfully.", "Insert Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//this line if we have an error this, it will show as a messagebox
            }
            dataGridView1.Rows.Clear();//we clear our datagridview after insert into our database
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        
    }
}
