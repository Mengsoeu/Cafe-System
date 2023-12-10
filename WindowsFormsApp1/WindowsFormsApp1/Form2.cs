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
    public partial class form2 : Form
    {
        private Form1 frm1;
        private int rowIndex;//we set this for later use in order to know our row in datagrid view


        public form2(Form1 form1, int rowIndex,int id, string drink, int qty, string size, string sugar, int price)//over we get data from form1
        {
            InitializeComponent();

            this.frm1 = form1;
            this.rowIndex = rowIndex;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;//we just customized our comboBox for user just click only they can't type it
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.Items.Add("Ice Latte");//we add items to our comboBox
            comboBox1.Items.Add("Americano");
            comboBox1.Items.Add("Mocha");
            comboBox1.Items.Add("Brown Sugar");
            comboBox1.Items.Add("Chocolate");
            comboBox1.Items.Add("Lemonade");
            comboBox1.Items.Add("Cappunico");
            comboBox1.Items.Add("Expresso");
            comboBox1.Items.Add("Matcha");

            comboBox2.Items.Add("M");
            comboBox2.Items.Add("L");

            comboBox3.Items.Add("25%");
            comboBox3.Items.Add("50%");
            comboBox3.Items.Add("100%");

            label6.Text = id.ToString();//we set label6 = id and convert to string since it was an int
            comboBox1.Text = drink;
            textBox1.Text = qty.ToString();
            comboBox2.Text = size;
            comboBox3.Text = sugar;
            textBox2.Text = price.ToString();

            textBox2.Enabled = false;

            textBox1.KeyPress += textbox1_KeyPress;//over here we set that user can only type numeric you will see in line 105
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged; //over here we gonna change the price when they use select item from comboBox in line 60
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the ComboBox
            string selectedValue = comboBox1.SelectedItem.ToString();

            if(selectedValue == "Ice Latte")
            {
                textBox2.Text = "2";
            } else if(selectedValue == "Americano")
            {
                textBox2.Text = "1";
            } else if (selectedValue == "Mocha")
            {
                textBox2.Text = "2";
            }
            else if (selectedValue == "Brown Sugar")
            {
                textBox2.Text = "2";
            }
            else if (selectedValue == "Chocolate")
            {
                textBox2.Text = "3";
            }
            else if (selectedValue == "Lemonade")
            {
                textBox2.Text = "1";
            }
            else if (selectedValue == "Cappucino")
            {
                textBox2.Text = "3";
            }
            else if (selectedValue == "Expresso")
            {
                textBox2.Text = "2";
            }
            else if (selectedValue == "Matcha")
            {
                textBox2.Text = "2";
            }
            else
            {

            }
        }

        private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only numeric
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;//Ignore the key press
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//here when the button trigger we gonna send all data to form1
        {
            int qty = Convert.ToInt32(textBox1.Text);
            string drink = comboBox1.Text;
            string size = comboBox2.Text;
            string sugar = comboBox3.Text;
            int multi = Convert.ToInt32(textBox2.Text);
            int price = (qty * multi);
                
            frm1.updateData(rowIndex, drink, qty, size, sugar, price);
            this.Close();
        }
    }
}
