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
            Options selectedOP = new Options();
            foreach (Options op in BachelorApp.Options.Get())
            {
                if(op.ModelId == deviceIndex[DeviceCB.SelectedIndex])
                {
                    selectedOP = op;
                    break;
                }
            }

            if (NameTB.Text != "")
            {
                if (Range1TB.Text != "" && Range1TB.Text.All(char.IsDigit))
                {
                    if (Range2TB.Text != "" && Range2TB.Text.All(char.IsDigit))
                    {
                        BachelorApp.Options.Change(deviceIndex[DeviceCB.SelectedIndex],NameTB.Text, Convert.ToInt32(Range1TB.Text), Convert.ToInt32(Range2TB.Text));
                        updateCB();
                    }

                    else
                    {
                        BachelorApp.Options.Change(deviceIndex[DeviceCB.SelectedIndex], NameTB.Text, Convert.ToInt32(Range1TB.Text), selectedOP.RangeTwo);
                        updateCB();
                    }
                }

                else
                {
                    if (Range2TB.Text != "" && Range2TB.Text.All(char.IsDigit))
                    {
                        BachelorApp.Options.Change(deviceIndex[DeviceCB.SelectedIndex], NameTB.Text, selectedOP.RangeOne, Convert.ToInt32(Range2TB.Text));
                        updateCB();
                    }

                    else
                    {
                        BachelorApp.Options.Change(deviceIndex[DeviceCB.SelectedIndex], NameTB.Text, selectedOP.RangeOne, selectedOP.RangeTwo);
                        updateCB();
                    }
                }
            }

            else
            {
                if (Range1TB.Text != "" && Range1TB.Text.All(char.IsDigit))
                {
                    if (Range2TB.Text != "" && Range2TB.Text.All(char.IsDigit))
                    {
                        BachelorApp.Options.Change(deviceIndex[DeviceCB.SelectedIndex], selectedOP.ModelName, Convert.ToInt32(Range1TB.Text), Convert.ToInt32(Range2TB.Text));
                    }

                    else
                    {
                        BachelorApp.Options.Change(deviceIndex[DeviceCB.SelectedIndex], selectedOP.ModelName, Convert.ToInt32(Range1TB.Text), selectedOP.RangeTwo);
                    }
                }

                else
                {
                    if (Range2TB.Text != "" && Range2TB.Text.All(char.IsDigit))
                    {
                        BachelorApp.Options.Change(deviceIndex[DeviceCB.SelectedIndex], selectedOP.ModelName, selectedOP.RangeOne, Convert.ToInt32(Range2TB.Text));
                    }
                    else
                    {
                        MessageBox.Show("no input");
                    }
                }
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
                        updateCB();
                    }

                    else if (!Range2TB.Text.All(char.IsDigit))
                    {
                        MessageBox.Show("Medium Range is not a number");
                    }

                    else
                    {
                        MessageBox.Show("Missing Medium Range");
                    }
                }

                else if (!Range1TB.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Top Range is not a number");
                }

                else
                {
                    MessageBox.Show("Missing Top Range");
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
            DeviceCB.SelectedIndex = 0;
        }
        private void updateCB()
        {
            int selectedIndex = DeviceCB.SelectedIndex;
            DeviceCB.Items.Clear();
            foreach (Options op in BachelorApp.Options.Get())
            {
                DeviceCB.Items.Add(op.ModelName);
                deviceIndex.Add(op.ModelId);
            }
            DeviceCB.SelectedIndex = selectedIndex;
        }
    }
}
