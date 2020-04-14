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
    public partial class EditOrDeleteKvest : Form
    {

        BLL.Program prog = new BLL.Program();
        public EditOrDeleteKvest()
        {
            InitializeComponent();
            ShowKvestRooms();
        }
        public void ShowKvestRooms()
        {
            string[,] kvestRooms = prog.ShowAllKvestRooms();
            for(int i=0;i<kvestRooms.GetLength(0);i++)
            {
                listBox1.Items.Insert(i,kvestRooms[i,0]+"; "+ kvestRooms[i, 1]+"-"+ kvestRooms[i, 2]+" people;" +
                    " "+ kvestRooms[i, 3]+"-"+ kvestRooms[i, 4]+" age category; " +
                    " "+ kvestRooms[i, 5]+" UAH/person");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EditOrDeleteKvest_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuForAdmin open = new MenuForAdmin();
            open.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] words;
            words = listBox1.SelectedItem.ToString().Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            textBox1.Text = words[0];
            textBox2.Text = words[5];
        }
    }
}
