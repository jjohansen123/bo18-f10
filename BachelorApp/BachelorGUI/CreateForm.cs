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
    public partial class CreateForm : Form
    {
        List<RadioButton> listrb = new List<RadioButton>();
        int siteID;
        public CreateForm(List<RadioButton> temprb, int SiteID)
        {
            siteID = SiteID;
            listrb = temprb;
            InitializeComponent();
        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            if (ConUTB.Text != "" && ConUTB.Text.All(char.IsDigit))
            {
                if(descTB.Text != "")
                {
                    RadioButton rBtn;
                    rBtn = BachelorGUI.Create.CreateRBtn(listrb, Convert.ToInt32(ConUTB.Text), descTB.Text, siteID);
                    FormCollection fc = Application.OpenForms;
                    foreach (Form f in fc)
                    {
                        if(f.Name == "MainForm1")
                        {
                            foreach(Control c in f.Controls)
                            {
                               
                                if(c.Name == "panel1")
                                {
                                    c.Controls.Add(rBtn);
                                    nodeCB.Items.Add(descTB.Text);
                                }
                            }
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Description: is missing text");
                }
            }
            else
            {
                MessageBox.Show("Connected users: is missing text or isnt a number");
            }
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            foreach (RadioButton rb in listrb)
            {
                if (rb.Name == "baseBtn")
                {
                    nodeCB.Items.Add(BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(1, siteID));
                }
                else
                {
                    nodeCB.Items.Add(BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name), siteID));
                }
            }
            nodeCB.SelectedIndex = 0;
        }

        private void nodeCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    rb.Checked = false;
                }
                if (rb.Name == "baseBtn")
                {
                    if (nodeCB.SelectedIndex == 0)
                    {
                        rb.Checked = true;
                        break;
                    }
                }
                else
                {
                    if (BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name), siteID) == nodeCB.Text)
                    {
                        rb.Checked = true;
                        break;
                    }
                }

            }
        }
    }
}
