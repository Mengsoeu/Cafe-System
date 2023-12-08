using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public string order { get; set; }
        public static Form3 instance;
        Form1 fgrid;
        public Form3(Form1 fg)
        {
            InitializeComponent();

            instance = this;
            this.fgrid = fg;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("M");
            comboBox1.Items.Add("L");

            comboBox2.Items.Add("25%");
            comboBox2.Items.Add("50%");
            comboBox2.Items.Add("100%");

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            textBox1.KeyPress += textbox1_KeyPress;
        }

        private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only numeric
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;//Ignore the key press
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = order;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(label2.Text);
            fgrid.dataGridView1.Rows.Add("",label1.Text, x, comboBox1.Text, comboBox2.Text, (y * x));
            this.Close();
        }
    }
}
