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
    public partial class DeviceForm : Form
    {
        List<int> deviceIndex = new List<int>();
        public DeviceForm()
        {
            InitializeComponent();
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (NameTB.Text != "")
            {
                if (Range1TB.Text != "" && Range1TB.Text.All(char.IsDigit))
                {
                    if (Range2TB.Text != "" && Range2TB.Text.All(char.IsDigit))
                    {
                        //temp
                    }

                    else
                    {
                        
                    }
                }

                else
                {
                    
                }
            }

            else
            {
                
            }
        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            if(NameTB.Text != "")
            {
                if(Range1TB.Text != "" && Range1TB.Text.All(char.IsDigit))
                {
                    if (Range2TB.Text != "" && Range2TB.Text.All(char.IsDigit))
                    {
                        BachelorApp.Options.Add(NameTB.Text,Convert.ToInt32(Range1TB.Text), Convert.ToInt32(Range2TB.Text));
                    }

                    else if (!Range2TB.Text.All(char.IsDigit))
                    {
                        MessageBox.Show("Range 2 is not a number");
                    }

                    else
                    {
                        MessageBox.Show("Missing Range 2");
                    }
                }

                else if (!Range1TB.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Range 1 is not a number");
                }

                else
                {
                    MessageBox.Show("Missing Range 1");
                }
            }

            else
            {
                MessageBox.Show("Missing name");
            }
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            BachelorApp.Options.Delete(deviceIndex[DeviceCB.SelectedIndex]);
            DeviceCB.Items.RemoveAt(DeviceCB.SelectedIndex);
            DeviceCB.SelectedIndex = 0;
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
            foreach(Options op in BachelorApp.Options.Get())
            {
                DeviceCB.Items.Add(op.ModelName);
                deviceIndex.Add(op.ModelId);
            }
        }
    }
}
