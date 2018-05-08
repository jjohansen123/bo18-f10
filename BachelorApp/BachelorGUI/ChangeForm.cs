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
    public partial class ChangeForm : Form
    {
        List<RadioButton> listrb = new List<RadioButton>();
        List<int> listIndex = new List<int>();
        List<int> DeviceIndex = new List<int>();
        int SiteID;
        RichTextBox formRTB;
        public ChangeForm(List<RadioButton> templist,int siteID, RichTextBox rtb)
        {
            SiteID = siteID;
            listrb = templist;
            formRTB = rtb;
            InitializeComponent();
        }

        private void ChangeBTN_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    bool error = false;
                    if(rb.Name != "baseBtn")
                    {
                        if (ConUTB.Text != "" && ConUTB.Text.All(char.IsNumber))
                        {
                            if (descTB.Text != "")
                            {
                                BachelorGUI.Change.ChangeNode(listrb, descTB.Text, Convert.ToInt32(ConUTB.Text), SiteID, DeviceIndex[DeviceCB.SelectedIndex]);
                                BachelorGUI.AddPercent.addPercent(listrb, SiteID);

                                nodeCB.Items[nodeCB.SelectedIndex] = descTB.Text;
                            }

                            else
                            {
                                BachelorGUI.Change.ChangeNode(listrb, BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name), SiteID), Convert.ToInt32(ConUTB.Text), SiteID, DeviceIndex[DeviceCB.SelectedIndex]);
                                BachelorGUI.AddPercent.addPercent(listrb, SiteID);
                                nodeCB.Items[nodeCB.SelectedIndex] = descTB.Text;
                            }
                        }
                        else if(ConUTB.Text != "" && !ConUTB.Text.All(char.IsNumber))
                        {
                            MessageBox.Show("Connected Users: in not a number!");
                            error = true;
                        }

                        else
                        {
                            if (descTB.Text != "")
                            {
                                BachelorGUI.Change.ChangeNode(listrb, descTB.Text, BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name), SiteID), SiteID, DeviceIndex[DeviceCB.SelectedIndex]);
                                BachelorGUI.AddPercent.addPercent(listrb, SiteID);
                                nodeCB.Items[nodeCB.SelectedIndex] = descTB.Text;
                            }
                        }

                        if (commentRTB.Text != "" && error == false)
                        {
                            BachelorApp.Updatenode.UpdateNodeComment(Convert.ToInt32(rb.Name), commentRTB.Text, SiteID);
                            formRTB.Text = commentRTB.Text;
                        }

                        if (DeviceIndex[DeviceCB.SelectedIndex] != BachelorApp.ViewSingleNodeModelID.viewSingleNodeModelID(Convert.ToInt32(rb.Name), SiteID) && error == false)
                        {
                            BachelorApp.Updatenode.UpdateNodeModel(Convert.ToInt32(rb.Name), DeviceIndex[DeviceCB.SelectedIndex], SiteID);
                        }
                        break;
                    }

                    else
                    {
                        if (ConUTB.Text != "" && ConUTB.Text.All(char.IsNumber))
                        {
                            if (descTB.Text != "")
                            {
                                BachelorGUI.Change.ChangeNode(listrb, descTB.Text, Convert.ToInt32(ConUTB.Text), SiteID, DeviceIndex[DeviceCB.SelectedIndex]);
                                BachelorGUI.AddPercent.addPercent(listrb, SiteID);
                                nodeCB.Items[nodeCB.SelectedIndex] = descTB.Text;
                            }

                            else
                            {
                                BachelorGUI.Change.ChangeNode(listrb, BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(1, SiteID), Convert.ToInt32(ConUTB.Text), SiteID, DeviceIndex[DeviceCB.SelectedIndex]);
                                BachelorGUI.AddPercent.addPercent(listrb, SiteID);
                            }
                        }

                        else if (ConUTB.Text != "" && !ConUTB.Text.All(char.IsNumber))
                        {
                            MessageBox.Show("Connected Users: in not a number!");
                            error = true;
                        }

                        else
                        {
                            if (descTB.Text != "")
                            {
                                BachelorGUI.Change.ChangeNode(listrb, descTB.Text, BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(1, SiteID), SiteID, DeviceIndex[DeviceCB.SelectedIndex]);
                                BachelorGUI.AddPercent.addPercent(listrb, SiteID);
                                nodeCB.Items[nodeCB.SelectedIndex] = descTB.Text;
                            }
                        }

                        if (commentRTB.Text != "" && error == false)
                        {
                            BachelorApp.Updatenode.UpdateNodeComment(1, commentRTB.Text, SiteID);
                            formRTB.Text = commentRTB.Text;
                        }
                        
                        if(DeviceIndex[DeviceCB.SelectedIndex] != BachelorApp.ViewSingleNodeModelID.viewSingleNodeModelID(1,SiteID) && error == false)
                        {
                            BachelorApp.Updatenode.UpdateNodeModel(1, DeviceIndex[DeviceCB.SelectedIndex], SiteID);
                        }
                        break;
                    }
                }
            }
            BachelorGUI.Recolor.recolor(listrb,SiteID);
        }

        private void ChangeForm_Load(object sender, EventArgs e)
        {
            foreach(RadioButton rb in listrb)
            {
                if(rb.Name == "baseBtn")
                {
                    nodeCB.Items.Add(BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(1, SiteID));
                    listIndex.Add(1);
                }

                else
                {
                    nodeCB.Items.Add(BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name), SiteID));
                    listIndex.Add(Convert.ToInt32(rb.Name));
                }

                if (rb.Checked)
                {
                    nodeCB.SelectedIndex = listIndex.Count - 1;
                }
            }
            foreach(Options op in BachelorApp.Options.Get())
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
                    if(BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription((listIndex[(nodeCB.SelectedIndex)]), SiteID) == nodeCB.Text && Convert.ToInt32(rb.Name) == (listIndex[(nodeCB.SelectedIndex)]))
                    {
                        rb.Checked = true;
                        break;
                    }
                }
                
            }
        }

        private void descTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChangeBTN_Click(sender, e);
            }
        }
    }
}
