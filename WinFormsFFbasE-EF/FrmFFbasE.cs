using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using FFbasEDataEF;

namespace WinFormsFFbasE_EF
{
    public partial class FrmFFbasE : Form
    {
        string unNoneError = "Неизвестная ошибка! Обратитесь к Алексею!";

        public List<string> parametrsClient = new List<string> { "", "", "", "", "", "", "", "" };

        private FFbasEDataEF.DBFFbasEEntities ctx;

        public FrmFFbasE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ctx = new FFbasEDataEF.DBFFbasEEntities();

            ctx.CLIENT.Load();
            this.cLIENTBindingSource.DataSource = ctx.CLIENT.Local.ToBindingList();

            ctx.EVENT.Load();
            this.eVENTBindingSource.DataSource = ctx.EVENT.Local.ToBindingList();

            ctx.STUDENT.Load();
            this.sTUDENTBindingSource.DataSource = ctx.STUDENT.Local.ToBindingList();

            ctx.COURSE_OF_LECTURE.Load();
            this.cOURSEOFLECTUREBindingSource.DataSource = ctx.COURSE_OF_LECTURE.Local.ToBindingList();

            ctx.STATUS.Load();
            this.sTATUSBindingSource.DataSource = ctx.STATUS.Local.ToBindingList();

            ctx.COURSE_OF_LECTURE.Load();
            this.cOURSEOFLECTUREBindingSource.DataSource = ctx.COURSE_OF_LECTURE.Local.ToBindingList();

            // dataGridView1.Column
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ctx.Dispose();
        }

        private void saveClient_Click(object sender, EventArgs e)
        {
            ctx.SaveChanges();
        }

        private void delClient_Click(object sender, EventArgs e)
        {
            try
            {
                CLIENT cl = (CLIENT)dgvClient.CurrentRow.DataBoundItem;
                var tiedStudent = (from c in ctx.STUDENT where c.CLIENT.STUDENT.Any(f => f.S_C == cl.C_ID) select c).Any();
                var tiedLecturer = (from c in ctx.LECTURER where c.CLIENT.LECTURER.Any(f => f.LC_C == cl.C_ID) select c).Any();
                var tiedEventClient = (from c in ctx.EVENT_CLIENT where c.CLIENT.EVENT_CLIENT.Any(f => f.EC_C == cl.C_ID) select c).Any();

                if (tiedStudent || tiedLecturer || tiedEventClient)
                {
                    MessageBox.Show("Удалить нельзя! К клиенту призязан студент/лектор/участник ивента!", "Ошбика удаления клиента");
                }
                else
                {
                    cLIENTBindingSource.RemoveCurrent();
                }
            }
            catch
            {
                MessageBox.Show(unNoneError, "Ошибка удаление клиента");
            }
        }

        private void addClient_Click(object sender, EventArgs e)
        {
            FrmAddClient addClientFrm = new FrmAddClient();

            addClientFrm.ShowDialog(this);
            addClientFrm.Dispose();

            ctx.CLIENT.Load();
            this.cLIENTBindingSource.DataSource = ctx.CLIENT.Local.ToBindingList();
        }

        private void filterClient_Click(object sender, EventArgs e)
        {
            var changes = ctx.ChangeTracker.Entries<CLIENT>().Where(a => a.State != System.Data.Entity.EntityState.Unchanged).ToList();

            if (changes.Count() != 0)
            {
                MessageBox.Show("Необходимо сохранить изминения!", "Фильтр клиента");
            }
            else
            {
                try
                {
                    CLIENT cl = (CLIENT)dgvClient.CurrentRow.DataBoundItem;

                    FrmFilterClient filterClientDialog = new FrmFilterClient(this);

                    filterClientDialog.ShowDialog(this);
                    filterClientDialog.Dispose();

                    var query = (from c in ctx.CLIENT select c);
                    string temp;

                    if (!String.IsNullOrWhiteSpace(parametrsClient[0]))
                    {
                        temp = parametrsClient[0];
                        query = query.Where(c => c.C_NAME.Contains(temp));
                    }
                    if (!String.IsNullOrWhiteSpace(parametrsClient[1]))
                    {
                        temp = parametrsClient[1];
                        query = query.Where(c => c.C_EMAIL.Contains(temp));
                    }
                    if (!String.IsNullOrWhiteSpace(parametrsClient[2]))
                    {
                        temp = parametrsClient[2];
                        query = query.Where(c => c.C_PHONE.Contains(temp));
                    }
                    if (!String.IsNullOrWhiteSpace(parametrsClient[3]))
                    {
                        temp = parametrsClient[3];
                        query = query.Where(c => c.C_SEC_PHONE.Contains(temp));
                    }
                    if (!String.IsNullOrWhiteSpace(parametrsClient[4]))
                    {
                        temp = parametrsClient[4];
                        query = query.Where(c => c.C_COMPANY.Contains(temp));
                    }
                    if (!String.IsNullOrWhiteSpace(parametrsClient[4]))
                    {
                        temp = parametrsClient[5];
                        query = query.Where(c => c.C_POST.Contains(temp));
                    }
                    if (!String.IsNullOrWhiteSpace(parametrsClient[6]))
                    {
                        temp = parametrsClient[6];
                        query = query.Where(c => c.C_EXPERIENCE.Contains(temp));
                    }
                    if (!String.IsNullOrWhiteSpace(parametrsClient[7]))
                    {
                        temp = parametrsClient[7];
                        query = query.Where(c => c.C_INTERESTS.Contains(temp));
                    }

                    query.Load();
                    cLIENTBindingSource.DataSource = query.ToList();
                    
                    
                    /*
                    cLIENTBindingSource.DataSource = ctx.CLIENT.Where(x => x.C_NAME.Contains(parametrsClient[0]) 
                                                                        && x.C_EMAIL.Contains(parametrsClient[1])
                                                                        && x.C_PHONE.Contains(parametrsClient[2])
                                                                        && x.C_SEC_PHONE.Contains(parametrsClient[3])
                                                                        && x.C_COMPANY.Contains(parametrsClient[4])
                                                                        && x.C_POST.Contains(parametrsClient[5])
                                                                        && x.C_EXPERIENCE.Contains(parametrsClient[6])
                                                                        && x.C_INTERESTS.Contains(parametrsClient[7])).ToList();
                    */
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            } 
        }

        private void delFilterClient_Click(object sender, EventArgs e)
        {

        }

        private void saveEvent_Click(object sender, EventArgs e)
        {
            ctx.SaveChanges();
        }

        private void delEvent_Click(object sender, EventArgs e)
        {
            try
            {
                EVENT ev = (EVENT)dgvEvent.CurrentRow.DataBoundItem;
                var tiedEventClient = (from c in ctx.EVENT_CLIENT where (c.EC_C == ev.E_ID) select c).Any();

                if(tiedEventClient)
                {
                    MessageBox.Show("Удалите нельзя! У ивента есть посетитель!", "Ошибка удаления ивента");
                }
                else
                {
                    eVENTBindingSource.RemoveCurrent();
                }
            }
            catch
            {
                MessageBox.Show(unNoneError, "Ошибка удаления ивента");
            }
        }

        private void addEvent_Click(object sender, EventArgs e)
        {

        }

        private void filterEvent_Click(object sender, EventArgs e)
        {

        }

        private void delFilterEvent_Click(object sender, EventArgs e)
        {

        }
    }
}
