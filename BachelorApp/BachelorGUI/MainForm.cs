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
using BachelorModel;

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

            bool formcheck = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "CreateForm")
                {
                    formcheck = true;
                    f.Focus();
                    break;
                }
            }
            if (formcheck == false)
            {
                CreateForm CreateForm = new CreateForm(GenerateList());
                CreateForm.Show();
            }
        }
        private void SortField()
        {
            BachelorGUI.Sort.SortField(GenerateList(), panel1.Height,panel1.Location.Y,baseBtn.Height);
            Recolor();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (!baseBtn.Checked)
            {
                if (BachelorGUI.NodeHasChildren.HasChild(GenerateList()))
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete this node and all it's connected nodes", "Delete all connected nodes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (RadioButton rb in BachelorGUI.Delete.DeleteBtnRec(GenerateList()))
                        {
                            this.panel1.Controls.Remove(rb);
                        }
                    }
                }
                else
                {
                    this.panel1.Controls.Remove(BachelorGUI.Delete.DeleteBtn(GenerateList()));
                }
            }
            
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
            List <Node> temp = BachelorApp.View.ViewNodesList();
            foreach(Node n in temp)
            {
                if(n.NodeID != 1)
                {
                    RadioButton rBtn;
                    rBtn = BachelorGUI.Create.CreateRBtnWithOutDB(GenerateList(), n.ParentID, n.NodeID);
                    rBtn.CheckedChanged += new System.EventHandler(this.baseBtn_CheckedChanged);
                    this.panel1.Controls.Add(rBtn);
                    SortField();
                }        
            }
        }

        private void changeBTN_Click(object sender, EventArgs e)
        {
            bool formcheck = false;
            FormCollection fc = Application.OpenForms;
            foreach(Form f in fc)
            {
                if(f.Name == "ChangeForm")
                {
                    formcheck = true;
                    f.Focus();
                    break;
                }
            }
            if (formcheck == false)
            {
                ChangeForm ChangeForm = new ChangeForm(GenerateList());
                ChangeForm.Show();
            }
        }

        private void MainForm1_SizeChanged(object sender, EventArgs e)
        {
            SortField();
        }
        private void Recolor()
        {
            BachelorGUI.Recolor.recolor(GenerateList());
        }

        private void panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            foreach(RadioButton rb in GenerateList())
            {
                rb.CheckedChanged -= this.baseBtn_CheckedChanged;
                rb.CheckedChanged += this.baseBtn_CheckedChanged;
            }
            SortField();
        }
    }
}
