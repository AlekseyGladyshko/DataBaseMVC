using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFbasEDataEF;
using System.Data.Entity;

namespace WinFormsFFbasE_EF
{
    public partial class FrmAddClient : Form
    {  
        public FrmAddClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new DBFFbasEEntities();
            int? n = null;

            var client = new CLIENT()
            {
                C_NAME = textBox1.Text,
                C_EMAIL = textBox2.Text,
                C_PHONE = textBox3.Text,
                C_SEC_PHONE = textBox4.Text,
                C_COMPANY = textBox5.Text,
                C_POST = textBox6.Text,
                C_EXPERIENCE = textBox7.Text,
                C_INTERESTS = textBox8.Text,
                C_SG = comboBox1.SelectedItem != null ? (int)comboBox1.SelectedValue : n    
            };

            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            comboBox1.SelectedItem = null;

            MessageBox.Show("Клинет успешно добавлен", "Добавление клиента");

            context.Set<CLIENT>().Add(client);
            context.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            comboBox1.SelectedItem = null;
        }
    }
}
