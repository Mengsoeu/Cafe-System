using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Label lbl18, lbl19, lbl20, lbl21, lbl22;
        private int currentId = 1;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
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


        protected override void OnFormClosing(FormClosingEventArgs e)
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
            Form3 frm3 = new Form3(this);
            frm3.order = label2.Text;
            frm3.label2.Text = "2";
            frm3.ShowDialog(this);

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
            

            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {

                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);
                string drink = dataGridView1.Rows[rowIndex].Cells["drink"].Value.ToString();
                int qty = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["qty"].Value);
                string size = dataGridView1.Rows[rowIndex].Cells["size"].Value.ToString();
                string sugar = dataGridView1.Rows[rowIndex].Cells["description"].Value.ToString();
                int price = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["price"].Value);

                form2 frm2 = new form2(this, rowIndex, id, drink, qty, size, sugar, price);
                frm2.ShowDialog();
                    
            }
            else
            {
                
            }
            if(e.ColumnIndex == dataGridView1.Columns["del"].Index && e.RowIndex >= 0)
            {
                int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(selectedIndex);
            }
        }
        public void updateData(int rowIndex,string drink, int qty, string size, string sugar, int price)
        {
            dataGridView1.Rows[rowIndex].Cells["qty"].Value = qty;
            dataGridView1.Rows[rowIndex].Cells["drink"].Value = drink;
            dataGridView1.Rows[rowIndex].Cells["size"].Value = size;
            dataGridView1.Rows[rowIndex].Cells["description"].Value = sugar;
            dataGridView1.Rows[rowIndex].Cells["price"].Value = price;
        }

        private void SumColumnValues()
        {
            int sum = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
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
            dataGridView1.Rows.Clear();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        
    }
}
