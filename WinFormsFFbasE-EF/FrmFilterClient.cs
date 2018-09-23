using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFbasEDataEF
{
    public partial class FrmFilterClient : Form
    {
        private FFbasEDataEF.DBFFbasEEntities ctx_client = new FFbasEDataEF.DBFFbasEEntities();
        private WinFormsFFbasE_EF.FrmFFbasE frm;

        public FrmFilterClient(WinFormsFFbasE_EF.FrmFFbasE f)
        {
            InitializeComponent();

            frm = f;
        } 
      
        private void findClient_Click(object sender, EventArgs e)
        {
            /*
            var query = (from c in ctx_client.CLIENT select c);

            if (!String.IsNullOrWhiteSpace(textBox1.Text))
                query = query.Where(c => c.C_NAME.Contains(textBox1.Text));
            if (!String.IsNullOrWhiteSpace(textBox2.Text))
                query = query.Where(c => c.C_EMAIL.Contains(textBox2.Text));
            if (!String.IsNullOrWhiteSpace(textBox3.Text))
                query = query.Where(c => c.C_PHONE.Contains(textBox3.Text));
            if (!String.IsNullOrWhiteSpace(textBox4.Text))
                query = query.Where(c => c.C_SEC_PHONE.Contains(textBox4.Text));
            if (!String.IsNullOrWhiteSpace(textBox5.Text))
                query = query.Where(c => c.C_COMPANY.Contains(textBox5.Text));
            if (!String.IsNullOrWhiteSpace(textBox6.Text))
                query = query.Where(c => c.C_POST.Contains(textBox6.Text));
            if (!String.IsNullOrWhiteSpace(textBox7.Text))
                query = query.Where(c => c.C_EXPERIENCE.Contains(textBox7.Text));
            if (!String.IsNullOrWhiteSpace(textBox8.Text))
                query = query.Where(c => c.C_INTERESTS.Contains(textBox8.Text));

            query.Load();
            cLIENTBindingSource.DataSource = ctx_client.CLIENT.Local.ToBindingList();
            */
            
            frm.parametrsClient[0] = textBox1.Text;
            frm.parametrsClient[1] = textBox2.Text;
            frm.parametrsClient[2] = textBox3.Text;
            frm.parametrsClient[3] = textBox4.Text;
            frm.parametrsClient[4] = textBox5.Text;
            frm.parametrsClient[5] = textBox6.Text;
            frm.parametrsClient[6] = textBox7.Text;
            frm.parametrsClient[7] = textBox8.Text;
            

            this.Dispose();
        }

        private void FrmFilterClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ctx.Dispose();
        }
    }
}
