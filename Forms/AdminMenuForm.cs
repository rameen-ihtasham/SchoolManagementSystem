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
    public partial class AdminMenuForm : Form
    {
        public Form activeForm = null;
        public AdminMenuForm()
        {
            InitializeComponent();
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageTeachersForm());
        }

        public void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            MainAdminScreen.Controls.Add(childForm);
            childForm.Tag = this;
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageStudentsForm());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ManageClassesForm());
        }
    }
}
