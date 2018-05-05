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
        List<int> siteIndex = new List<int>();
        public SiteForm(ComboBox cb)
        {
            InitializeComponent();
            formSiteCB = cb;
        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            BachelorApp.SiteFunctions.AddSite(NameTB.Text);
            MessageBox.Show("Site has been created");
            UpdateCB();
            SiteForm.ActiveForm.Close();
        }

        private void SiteForm_Load(object sender, EventArgs e)
        {
            UpdateCB();
            SiteCB.SelectedIndex = 0;
        }
        private void UpdateCB()
        {
            int tempIndex = formSiteCB.SelectedIndex;
            formSiteCB.Items.Clear();
            SiteCB.Items.Clear();
            foreach (Site s in BachelorApp.SiteFunctions.GetSite())
            {
                formSiteCB.Items.Add(s.SiteName);
                SiteCB.Items.Add(s.SiteName);
                siteIndex.Add(s.SiteId);
            }
            formSiteCB.SelectedIndex = tempIndex;
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            BachelorApp.SiteFunctions.DeleteSite(siteIndex[SiteCB.SelectedIndex]);
            formSiteCB.Items.RemoveAt(SiteCB.SelectedIndex);
            SiteCB.Items.RemoveAt(SiteCB.SelectedIndex);
            SiteCB.SelectedIndex = 0;
        }
    }
}
