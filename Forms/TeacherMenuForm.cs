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
    public partial class TeacherMenuForm : Form
    {
        public Form activeForm = null;
        public TeacherMenuForm()
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
            guna2Panel3.Controls.Add(childForm);
            childForm.Tag = this;
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
           /* OpenChildForm(new Attendance());*/
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UploadResult());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AssignHomework());
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
