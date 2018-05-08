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
    public partial class CreateForm : Form
    {
        List<RadioButton> listrb = new List<RadioButton>();
        List<int> listIndex = new List<int>();
        List<int> DeviceIndex = new List<int>();
        int siteID;
        public CreateForm(List<RadioButton> tempList, int SiteID)
        {
            siteID = SiteID;
            listrb = tempList;
            InitializeComponent();
        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            if (ConUTB.Text != "" && ConUTB.Text.All(char.IsDigit))
            {
                if(descTB.Text != "")
                {
                    RadioButton rBtn;
                    rBtn = BachelorGUI.Create.CreateRBtn(listrb, Convert.ToInt32(ConUTB.Text), descTB.Text, commentRTB.Text, siteID, DeviceIndex[DeviceCB.SelectedIndex]);
                    FormCollection fc = Application.OpenForms;
                    foreach (Form f in fc)
                    {
                        if (f.Name == "MainForm1")
                        {
                            foreach (Control c in f.Controls)
                            {

                                if (c.Name == "panel1")
                                {
                                    c.Controls.Add(rBtn);
                                    listrb.Add(rBtn);
                                    listIndex.Add(Convert.ToInt32(rBtn.Name));
                                    nodeCB.Items.Add(descTB.Text);
                                    BachelorGUI.AddPercent.addPercent(listrb, siteID);
                                }
                            }
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Name: is missing text");
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
                    nodeCB.Items.Add(BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(1, siteID));
                    listIndex.Add(1);
                }

                else
                {
                    nodeCB.Items.Add(BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name), siteID));
                    listIndex.Add(Convert.ToInt32(rb.Name));
                }

                if (rb.Checked)
                {
                    nodeCB.SelectedIndex = listIndex.Count - 1;
                }
            }
            foreach (Options op in BachelorApp.Options.Get())
            {
                DeviceCB.Items.Add(op.ModelName);
                DeviceIndex.Add(op.ModelId);
            }
            DeviceCB.SelectedIndex = 0;
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
                    if (BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription((listIndex[(nodeCB.SelectedIndex)]), siteID) == nodeCB.Text && Convert.ToInt32(rb.Name) == (listIndex[(nodeCB.SelectedIndex)]))
                    {
                        rb.Checked = true;
                        break;
                    }
                }

            }
        }

        private void descTB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                CreateBTN_Click(sender, e);
            }
        }
    }
}
