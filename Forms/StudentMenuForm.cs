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
    public partial class StudentMenuForm : Form
    {
        public Form activeForm = null;
        public StudentMenuForm()
        {
            InitializeComponent();
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
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ViewResult());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new VIewAttendance());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ViewHomework());
        }
    }
}
