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
    public partial class MainWindowForm : Form
    {

        public Form activeForm = null;
        public MainWindowForm(Form ChildForm)
        {
            InitializeComponent();
            OpenChildForm(ChildForm);
         
          
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        public void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(childForm);
            childForm.Tag = this;            
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

    }
}
