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
    public partial class ChangeForm : Form
    {
        List<RadioButton> listrb = new List<RadioButton>();
        public ChangeForm(List<RadioButton> templist)
        {
            listrb = templist;
            InitializeComponent();
        }

        private void ChangeBTN_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    if (ConUTB.Text != "")
                    {
                        if (descTB.Text != "")
                        {
                            BachelorGUI.Change.ChangeNode(listrb, descTB.Text, Convert.ToInt32(ConUTB.Text));
                            break;
                        }

                        else
                        {
                            BachelorGUI.Change.ChangeNode(listrb, BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name)), Convert.ToInt32(ConUTB.Text));
                            break;
                        }
                    }

                    else
                    {
                        if (descTB.Text != "")
                        {
                            BachelorGUI.Change.ChangeNode(listrb, descTB.Text, BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name)));
                            break;
                        }
                    }
                }
            }
            BachelorGUI.Recolor.recolor(listrb);
        }

        private void ChangeForm_Load(object sender, EventArgs e)
        {
            foreach(RadioButton rb in listrb)
            {
                if(rb.Name == "baseBtn")
                {
                    nodeCB.Items.Add(BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(1));
                }
                else
                {
                    nodeCB.Items.Add(BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name)));
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
                    if (BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name)) == nodeCB.Text)
                    {
                        rb.Checked = true;
                        break;
                    }
                }
                
            }
        }
    }
}
