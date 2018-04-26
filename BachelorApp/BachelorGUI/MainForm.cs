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
            List<Form> closeList = new List<Form>();
            foreach (Form f in fc)
            {
                if (f.Name == "SiteForm")
                {
                    formcheck = true;
                    f.Focus();
                    MessageBox.Show("You have to close the school window to continue");
                    break;
                }
                if (f.Name == "ChangeForm")
                {
                    closeList.Add(f);

                }
                if (f.Name == "CreateForm")
                {
                    formcheck = true;
                    f.Focus();
                }
            }
            foreach (Form f in closeList)
            {
                f.Close();
            }
            if (formcheck == false)
            {
                CreateForm CreateForm = new CreateForm(GenerateList(), getSiteID());
                CreateForm.Show();
            }
        }
        private void SortField()
        {
            BachelorGUI.Sort.SortField(GenerateList(), panel1.Height,panel1.Location.Y,baseBtn.Height, getSiteID());
            Recolor();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (!baseBtn.Checked)
            {
                if (BachelorGUI.NodeHasChildren.HasChild(GenerateList(), getSiteID()))
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete this node and all it's connected nodes", "Delete all connected nodes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (RadioButton rb in BachelorGUI.Delete.DeleteBtnRec(GenerateList(), getSiteID()))
                        {
                            this.panel1.Controls.Remove(rb);
                        }
                    }
                }
                else
                {
                    this.panel1.Controls.Remove(BachelorGUI.Delete.DeleteBtn(GenerateList(), getSiteID()));
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
                        descTB.Text = BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(Convert.ToInt32(id), getSiteID());
                        conUTB.Text = BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(id), getSiteID()).ToString();
                        break;
                    }
                    
                    descTB.Text = BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name), getSiteID());
                    conUTB.Text = BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name), getSiteID()).ToString();
                    break;
                }   
            }
        }

        private void MainForm1_Load(object sender, EventArgs e)
        {
            UpdateCB(schoolCB);
            schoolCB.SelectedIndex = 0;
            UpdatePanel();
            Recolor();
        }

        private void changeBTN_Click(object sender, EventArgs e)
        {
            bool formcheck = false;
            FormCollection fc = Application.OpenForms;
            List<Form> closeList = new List<Form>();
            foreach (Form f in fc)
            {
                if(f.Name == "SiteForm")
                {
                    formcheck = true;
                    f.Focus();
                    MessageBox.Show("You have to close the school window to continue");
                    break;
                }
                if (f.Name == "CreateForm")
                {
                    closeList.Add(f);

                }
                if (f.Name == "ChangeForm")
                {
                    formcheck = true;
                    f.Focus();
                }
            }
            foreach (Form f in closeList)
            {
                f.Close();
            }
            if (formcheck == false)
            {
                ChangeForm ChangeForm = new ChangeForm(GenerateList(), getSiteID());
                ChangeForm.Show();
            }
        }

        private void MainForm1_SizeChanged(object sender, EventArgs e)
        {
            SortField();
        }
        private void Recolor()
        {
            BachelorGUI.Recolor.recolor(GenerateList(), getSiteID());
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

        private void SchoolBtn_Click(object sender, EventArgs e)
        {
            bool formcheck = false;
            FormCollection fc = Application.OpenForms;
            List<Form> closeList = new List<Form>();
            foreach (Form f in fc)
            {
                if (f.Name == "SiteForm")
                {
                    formcheck = true;
                    f.Focus();
                }
                if (f.Name == "ChangeForm")
                {
                    closeList.Add(f);

                }
                if (f.Name == "CreateForm")
                {
                    closeList.Add(f);
                }

            }
            foreach(Form f in closeList)
            {
                f.Close();
            }
            if (formcheck == false)
            {
                SiteForm siteForm = new SiteForm();
                siteForm.Show();
            }
        }

        public void ClearPanel()
        {
            foreach(RadioButton rb in GenerateList())
            {
                if(rb.Name != "baseBtn")
                {
                    this.panel1.Controls.Remove(rb);
                }
            }
        }

        public void UpdatePanel()
        {
            List<Node> temp = BachelorApp.View.ViewNodesList(getSiteID());
            foreach (Node n in temp)
            {
                if (n.Lingling != 1)
                {
                    RadioButton rBtn;
                    rBtn = BachelorGUI.Create.CreateRBtnWithOutDB(GenerateList(), n.ParentID, n.Lingling);
                    rBtn.CheckedChanged += new System.EventHandler(this.baseBtn_CheckedChanged);
                    this.panel1.Controls.Add(rBtn);
                    
                }
            }
            SortField();
        }

        private int getSiteID()
        {
            foreach (Site s in BachelorApp.SiteFunctions.GetSite())
            {
                if (s.SiteName == schoolCB.Text)
                {
                    return s.SiteId;
                }
            }
            return 1;
        }

        private void schoolCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearPanel();
            UpdatePanel();
        }
        public static void UpdateCB(ComboBox schoolCB)
        {
            schoolCB.Items.Clear();
            foreach (Site s in BachelorApp.SiteFunctions.GetSite())
            {
                schoolCB.Items.Add(s.SiteName);
            }
        }
    }
}
