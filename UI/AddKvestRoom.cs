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
    public partial class AddKvestRoom : Form
    {
        BLL.Program prog = new BLL.Program();
        int ageCategory;
        int usersValue;
        public AddKvestRoom()
        {
            InitializeComponent();
            AddComboUsersValues();
            AddComboAgeCategories();
            CleanItems();
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
        void CleanItems()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                if (prog.AddKvestRoom(textBox1.Text, usersValue, ageCategory, Convert.ToInt32(textBox2.Text)))
                {
                    MessageBox.Show("Kvest-room was added succesfully!!!");
                    CleanItems();
                }
            }
            else
                MessageBox.Show("You shoud edit all rows. Try again!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            usersValue = comboBox1.SelectedIndex + 1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ageCategory = comboBox2.SelectedIndex + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuForAdmin m = new MenuForAdmin();
            m.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddKvestRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
