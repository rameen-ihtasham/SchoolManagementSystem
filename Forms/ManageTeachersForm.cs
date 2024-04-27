using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFinalProject.Forms
{
    public partial class ManageTeachersForm : Form
    {
        public ManageTeachersForm()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AdminMenuForm form = (AdminMenuForm)this.Tag;
            form.OpenChildForm(new AddTeachersForm());
        }
    }
}
