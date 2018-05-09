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

        /// <summary>
        /// Generates the list.
        /// </summary>
        /// <returns></returns>
        private List<RadioButton> GenerateList()
        {
            List<RadioButton> temprb = new List<RadioButton>();
            foreach (RadioButton rb in panel1.Controls)
            {
                temprb.Add(rb);
            }
            return temprb;
        }

        /// <summary>
        /// Gets the site identifier.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Updates the cb.
        /// </summary>
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

        /// <summary>
        /// Clears the panel.
        /// </summary>
        private void ClearPanel()
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

        /// <summary>
        /// Draws lines for the panel.
        /// </summary>
        private void draw()
        {
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

        /// <summary>
        /// Recolors the buttons;
        /// </summary>
        private void Recolor()
        {
            BachelorGUI.Recolor.recolor(GenerateList(), getSiteID());
        }

        /// <summary>
        /// Sorts the field.
        /// </summary>
        private void SortField()
        {
            BachelorGUI.Sort.SortField(GenerateList(), panel1.Height,panel1.Location.Y, getSiteID());
            Recolor();
            draw();

        }

        /// <summary>
        /// Adds the text.
        /// </summary>
        private void addText()
        {
            BachelorGUI.AddPercent.addPercent(GenerateList(), getSiteID());
        }

        /// <summary>
        /// Updates the panel.
        /// </summary>
        private void UpdatePanel()
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

        /// <summary>
        /// Gives the dclick event to radio button.
        /// </summary>
        /// <param name="rb">The rb.</param>
        private void giveDClick(RadioButton rb)
        {
            MethodInfo m = typeof(RadioButton).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
            if (m != null)
            {
                m.Invoke(rb, new object[] { ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true });
            }
            rb.MouseDoubleClick -= this.changeBTN_Click;
            rb.MouseDoubleClick += this.changeBTN_Click;
        }

        /// <summary>
        /// Handles the Load event of the MainForm1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm1_Load(object sender, EventArgs e)
        {
            UpdateCB();
            siteCB.SelectedIndex = 0;
            UpdatePanel();
            giveDClick(baseBtn);

            int id = 1;
            descTB.Text = BachelorApp.ViewSingleNodeDescription.ViewSingleDescription(id, getSiteID());
            conUTB.Text = BachelorApp.ViewSingleNodeConnected.ViewSingleConnected(id, getSiteID()).ToString();
            TConUTB.Text = BachelorApp.ViewSingleNodeTotalConnected.viewSingleNodeTotalConnected(id, getSiteID()).ToString();
            idTB.Text = Convert.ToString(id);
            commentRTB.Text = BachelorApp.ViewSingleNodeComment.ViewSingleComment(id, getSiteID()).ToString();
        }

        /// <summary>
        /// Handles the Shown event of the MainForm1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm1_Shown(object sender, EventArgs e)
        {
            draw();
        }

        /// <summary>
        /// Handles the ControlAdded event of the panel1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SizeChanged event of the MainForm1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm1_SizeChanged(object sender, EventArgs e)
        {
            SortField();
        }

        /// <summary>
        /// Handles the Click event of the DeviceBTN control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the CreateBTN control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the DeleteBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            List<Form> closeList = new List<Form>();
            foreach (Form f in fc)
            {
                if (f.Name == "SiteForm")
                {
                    
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
                    closeList.Add(f);
                }
            }
            foreach (Form f in closeList)
            {
                f.Close();
            }

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
            baseBtn.Checked = true;
        }

        /// <summary>
        /// Handles the Click event of the changeBTN control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the SiteBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the CheckedChanged event of the baseBtn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void baseBtn_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RadioButton rb in panel1.Controls)
            {
                if (rb.Checked)
                {
                    if (rb.Name == "baseBtn")
                    {
                        int id = 1;
                        descTB.Text = BachelorApp.ViewSingleNodeDescription.ViewSingleDescription(id, getSiteID());
                        conUTB.Text = BachelorApp.ViewSingleNodeConnected.ViewSingleConnected(id, getSiteID()).ToString();
                        TConUTB.Text = BachelorApp.ViewSingleNodeTotalConnected.viewSingleNodeTotalConnected(id, getSiteID()).ToString();
                        idTB.Text = Convert.ToString(id);
                        commentRTB.Text = BachelorApp.ViewSingleNodeComment.ViewSingleComment(id, getSiteID()).ToString();
                        break;
                    }

                    descTB.Text = BachelorApp.ViewSingleNodeDescription.ViewSingleDescription(Convert.ToInt32(rb.Name), getSiteID());
                    conUTB.Text = BachelorApp.ViewSingleNodeConnected.ViewSingleConnected(Convert.ToInt32(rb.Name), getSiteID()).ToString();
                    TConUTB.Text = BachelorApp.ViewSingleNodeTotalConnected.viewSingleNodeTotalConnected(Convert.ToInt32(rb.Name), getSiteID()).ToString();
                    idTB.Text = rb.Name;
                    commentRTB.Text = BachelorApp.ViewSingleNodeComment.ViewSingleComment(Convert.ToInt32(rb.Name), getSiteID()).ToString();
                    break;
                }
            }
        }

        /// <summary>
        /// Handles the SelectionChangeCommitted event of the siteCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
