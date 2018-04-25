using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachelorGUI
{
    public partial class SiteForm : Form
    {
        public SiteForm()
        {
            InitializeComponent();
        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            BachelorApp.SiteFunctions.AddSite(NameTB.Text);
            MessageBox.Show("School has been created");
            FormCollection fc = Application.OpenForms;
        }

        private void SiteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
