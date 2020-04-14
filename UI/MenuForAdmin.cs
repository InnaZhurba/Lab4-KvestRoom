using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MenuForAdmin : Form
    {
        public MenuForAdmin()
        {
            InitializeComponent();
        }

        private void MenuForAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddKvestRoom add = new AddKvestRoom();
            add.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditOrDeleteKvest add = new EditOrDeleteKvest();
            add.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BLL.Program prog = new BLL.Program();
            prog.AddSertificate();
            MessageBox.Show("Succesful!");
        }
    }
}
