using BachelorModel;
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
        ComboBox formSiteCB;
        public SiteForm(ComboBox cb)
        {
            InitializeComponent();
            formSiteCB = cb;
        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            BachelorApp.SiteFunctions.AddSite(NameTB.Text);
            MessageBox.Show("School has been created");
            FormCollection fc = Application.OpenForms;
            UpdateCB();
        }

        private void SiteForm_Load(object sender, EventArgs e)
        {
            UpdateCB();
        }
        private void UpdateCB()
        {
            int tempIndex = formSiteCB.SelectedIndex;
            int tempIndex2 = SiteCB.SelectedIndex;
            formSiteCB.Items.Clear();
            SiteCB.Items.Clear();
            foreach (Site s in BachelorApp.SiteFunctions.GetSite())
            {
                formSiteCB.Items.Add(s.SiteName);
                SiteCB.Items.Add(s.SiteName);
            }
            formSiteCB.SelectedIndex = tempIndex;
            SiteCB.SelectedIndex = tempIndex2;
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
