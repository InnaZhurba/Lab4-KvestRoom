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
    public partial class MenuForUsers : Form
    {
        BLL.Program prog = new BLL.Program();
        int ageCategory;
        int usersValue;
        public MenuForUsers()
        {
            InitializeComponent();
            ShowKvestRooms();
            AddComboAgeCategories();
            AddComboTimeCategories();
            AddComboUsersValues();
            
        }
        public void ShowKvestRooms()
        {
            string[,] kvestRooms = prog.ShowAllKvestRooms();
            for (int i = 0; i < kvestRooms.GetLength(0); i++)
            {
                listBox1.Items.Insert(i, kvestRooms[i, 0] + "; " + kvestRooms[i, 1] + "-" + kvestRooms[i, 2] + " people;" +
                    " " + kvestRooms[i, 3] + "-" + kvestRooms[i, 4] + " age category; " +
                    " " + kvestRooms[i, 5] + " UAH/person");
            }
        }
        void AddComboUsersValues()
        {
            int[,] usersVal = prog.UsersValueShow();
            for (int i = 0; i < 3; i++)
                comboBox1.Items.Add(usersVal[i, 0] + "-" + usersVal[i, 1]);
        }
        void AddComboAgeCategories()
        {
            int[,] value = prog.AgeCategoriesShow();
            for (int i = 0; i < 3; i++)
                comboBox2.Items.Add(value[i, 0] + "-" + value[i, 1]);
            
        }
        void AddComboTimeCategories()
        {
            string[,] value = prog.TimeCategoriesShow();
            for (int i = 0; i < value.GetLength(0); i++)
                comboBox3.Items.Add(value[i, 0] + ": " + value[i, 1]+"-"+value[i,2]);
            comboBox3.SelectedIndex = 0;
        }

        private void MenuForUsers_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ageCategory = comboBox2.SelectedIndex + 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            usersValue = comboBox1.SelectedIndex + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ageCategory!=0 && usersValue!=0 && textBox2.Text.Length>0)
            {
                string[] data = prog.FindKvestNames(usersValue,ageCategory,Convert.ToInt32(textBox2.Text));
                listBox1.Items.Clear();
                for(int i=0;i<data.Length;i++)
                {
                    listBox1.Items.Insert(i, data[i]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0 && textBox4.Text.Length>0)
            {
                if (prog.SaveStatusAndOrder(textBox1.Text, comboBox3.SelectedIndex + 1, Convert.ToInt32(textBox4.Text), Convert.ToInt16(textBox3.Text), listBox1.SelectedIndex+1))
                    MessageBox.Show("Succes!!!");
            }
        }
    }
}
