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
    public partial class SignInFrom : Form
    {
        public Form activeForm = null;
        public SignInFrom()
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
            MainWindow.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.Tag = this;
            childForm.BringToFront();
            childForm.Show();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            MainWindowForm form = (MainWindowForm)this.Tag;
            form.OpenChildForm(new AdminMenuForm());           
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
