using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class Main : Form
    {
        BLL.Program prog = new BLL.Program();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
                    if (prog.CheckAdmin(textBox1.Text, Convert.ToInt32(textBox2.Text)))
                    {
                        MenuForAdmin m = new MenuForAdmin();
                        m.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong data!!!");
                    }
            }
            else
            {
                MenuForUsers m = new MenuForUsers();
                m.Show();
            }
        }
    }
}
