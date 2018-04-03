using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BachelorApp;

namespace BachelorGUI
{
    public partial class MainForm1 : Form
    {
        public MainForm1()
        {
            InitializeComponent();
        }  
        private List<RadioButton> GenerateList()
        {
            List<RadioButton> temprb = new List<RadioButton>();
            foreach (RadioButton rb in panel1.Controls)
            {
                temprb.Add(rb);
            }
            return temprb;
        }
        private void CreateBTN_Click(object sender, EventArgs e)
        {
            if (conUTB.Text.All(char.IsNumber))
            {
                RadioButton rBtn;
                rBtn = WindowsFormsApp1.Create.CreateRBtn(GenerateList(), Convert.ToInt32(conUTB.Text), descTB.Text);
                rBtn.CheckedChanged += new System.EventHandler(this.baseBtn_CheckedChanged);
                this.panel1.Controls.Add(rBtn);
                SortField();
            }
        }
        private void SortField()
        {
            WindowsFormsApp1.Sort.SortField(GenerateList(), panel1.Height,panel1.Location.Y,baseBtn.Height);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
             this.panel1.Controls.Remove(WindowsFormsApp1.Delete.DeleteBtn(GenerateList()));
             SortField();
        }

        public void baseBtn_CheckedChanged(object sender, EventArgs e)
        {
            
            foreach (RadioButton rb in panel1.Controls)
            {
                if (rb.Checked)
                {
                    if(rb.Name == "baseBtn")
                    {
                        int id = 1;
                        descTB.Text = BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(Convert.ToInt32(id));
                        conUTB.Text = BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(id)).ToString();
                        break;
                    }
                    
                    descTB.Text = BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name));
                    conUTB.Text = BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name)).ToString();
                    break;
                }   
            }
        }

        private void MainForm1_Load(object sender, EventArgs e)
        {

        }
    }
}
