using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BachelorApp;
using BachelorModel;

namespace BachelorGUI
{
    public partial class MainForm1 : Form
    {
        bool loaded = false;
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

        private int getSiteID()
        {
            foreach (Site s in BachelorApp.SiteFunctions.GetSite())
            {
                if (s.SiteName == siteCB.Text)
                {
                    return s.SiteId;
                }
            }
            return 1;
        }

        private void UpdateCB()
        {
            int tempIndex = siteCB.SelectedIndex;
            siteCB.Items.Clear();
            foreach (Site s in BachelorApp.SiteFunctions.GetSite())
            {
                siteCB.Items.Add(s.SiteName);
            }
            siteCB.SelectedIndex = tempIndex;
        }

        public void ClearPanel()
        {
            foreach (RadioButton rb in GenerateList())
            {
                if (rb.Name != "baseBtn")
                {
                    this.panel1.Controls.Remove(rb);
                    rb.Dispose();
                }
            }
        } 

        private void draw()
        {
            this.Invalidate();
            panel1.Refresh();
            Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
            Pen myPen = new Pen(Color.Black);
            myPen.Width = 2;
            Graphics formGraphics;
            formGraphics = Graphics.FromImage(bitmap);
            BachelorGUI.Drawing.drawLines(GenerateList(), formGraphics, myPen, getSiteID());
            panel1.BackgroundImage = bitmap;
            myPen.Dispose();
            formGraphics.Dispose();
        }

        private void Recolor()
        {
            BachelorGUI.Recolor.recolor(GenerateList(), getSiteID());
        }

        private void SortField()
        {
            BachelorGUI.Sort.SortField(GenerateList(), panel1.Height,panel1.Location.Y,baseBtn.Height, getSiteID());
            Recolor();
            draw();

        }

        private void addText()
        {
            BachelorGUI.AddPercent.addPercent(GenerateList(), getSiteID());
        }

        public void UpdatePanel()
        {
            loaded = false;
            List<Node> temp = BachelorApp.View.ViewNodesList(getSiteID());
            foreach (Node n in temp)
            {
                if (n.LocalID != 1)
                {
                    RadioButton rBtn;
                    rBtn = BachelorGUI.Create.CreateRBtnWithOutDB(GenerateList(), n.ParentID, n.LocalID);
                    rBtn.CheckedChanged += new System.EventHandler(this.baseBtn_CheckedChanged);
                    this.panel1.Controls.Add(rBtn);
                }
            }
            loaded = true;
            SortField();
            addText();
        }

        public void giveDClick(RadioButton rb)
        {
            MethodInfo m = typeof(RadioButton).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
            if (m != null)
            {
                m.Invoke(rb, new object[] { ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true });
            }
            rb.MouseDoubleClick -= this.changeBTN_Click;
            rb.MouseDoubleClick += this.changeBTN_Click;
        }

        private void MainForm1_Load(object sender, EventArgs e)
        {
            UpdateCB();
            siteCB.SelectedIndex = 0;
            UpdatePanel();
            giveDClick(baseBtn);

            int id = 1;
            descTB.Text = BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(id, getSiteID());
            conUTB.Text = BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(id, getSiteID()).ToString();
            TConUTB.Text = BachelorApp.ViewSingleNodeTotalConnected.viewSingleNodeTotalConnected(id, getSiteID()).ToString();
            idTB.Text = Convert.ToString(id);
            commentRTB.Text = BachelorApp.ViewSingleNodeComment.ViewSingleNodeChildren(id, getSiteID()).ToString();
        }

        private void MainForm1_Shown(object sender, EventArgs e)
        {
            draw();
        }

        private void panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            foreach (RadioButton rb in GenerateList())
            {
                rb.CheckedChanged -= this.baseBtn_CheckedChanged;
                rb.CheckedChanged += this.baseBtn_CheckedChanged;
                giveDClick(rb);
            }
            if (loaded)
            {
                SortField();
            }
            addText();
        }

        private void MainForm1_SizeChanged(object sender, EventArgs e)
        {
            SortField();
        }

        private void DeviceBTN_Click(object sender, EventArgs e)
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
                    MessageBox.Show("You have to close the \"Site\" window to continue");
                    break;
                }
                if (f.Name == "ChangeForm")
                {
                    closeList.Add(f);

                }
                if (f.Name == "CreateForm")
                {
                    closeList.Add(f);

                }
                if (f.Name == "DeviceForm")
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
                DeviceForm DeviceForm = new DeviceForm(GenerateList(), getSiteID());
                DeviceForm.Show();
            }
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
                    MessageBox.Show("You have to close the \"Site\" window to continue");
                    break;
                }
                if (f.Name == "ChangeForm")
                {
                    closeList.Add(f);

                }
                if (f.Name == "DeviceForm")
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
            else
            {
                MessageBox.Show("You can't delete the gateway node!");
            }

            SortField();
            Updatetotal.RunUpdate(getSiteID());
            addText();
        }

        private void changeBTN_Click(object sender, EventArgs e)
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
                    MessageBox.Show("You have to close the \"Site\" window to continue");
                    break;
                }
                if (f.Name == "CreateForm")
                {
                    closeList.Add(f);

                }
                if (f.Name == "DeviceForm")
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
                ChangeForm ChangeForm = new ChangeForm(GenerateList(), getSiteID(), commentRTB);
                ChangeForm.Show();
            }
        }
        private void SiteBtn_Click(object sender, EventArgs e)
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
                if (f.Name == "DeviceForm")
                {
                    closeList.Add(f);

                }
                if (f.Name == "CreateForm")
                {
                    closeList.Add(f);
                }

            }
            foreach (Form f in closeList)
            {
                f.Close();
            }
            if (formcheck == false)
            {
                SiteForm siteForm = new SiteForm(siteCB);
                siteForm.Show();
            }
        }

        public void baseBtn_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RadioButton rb in panel1.Controls)
            {
                if (rb.Checked)
                {
                    if (rb.Name == "baseBtn")
                    {
                        int id = 1;
                        descTB.Text = BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(id, getSiteID());
                        conUTB.Text = BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(id, getSiteID()).ToString();
                        TConUTB.Text = BachelorApp.ViewSingleNodeTotalConnected.viewSingleNodeTotalConnected(id, getSiteID()).ToString();
                        idTB.Text = Convert.ToString(id);
                        commentRTB.Text = BachelorApp.ViewSingleNodeComment.ViewSingleNodeChildren(id, getSiteID()).ToString();
                        break;
                    }

                    descTB.Text = BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name), getSiteID());
                    conUTB.Text = BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name), getSiteID()).ToString();
                    TConUTB.Text = BachelorApp.ViewSingleNodeTotalConnected.viewSingleNodeTotalConnected(Convert.ToInt32(rb.Name), getSiteID()).ToString();
                    idTB.Text = rb.Name;
                    commentRTB.Text = BachelorApp.ViewSingleNodeComment.ViewSingleNodeChildren(Convert.ToInt32(rb.Name), getSiteID()).ToString();
                    break;
                }
            }
        }

        private void siteCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearPanel();
            UpdatePanel();
            SortField();

            if (baseBtn.Checked)
            {
                baseBtn.Checked = false;
            }
            baseBtn.Checked = true;

            FormCollection fc = Application.OpenForms;
            List<Form> closeList = new List<Form>();
            foreach (Form f in fc)
            {
                if (f.Name != "MainForm1")
                {
                    closeList.Add(f);
                }
            }
            foreach (Form f in closeList)
            {
                f.Close();
            }
        }
    }
}
