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
        //todo forandre verdier/bruk
        int maxLength = 1;
        int btnCount = 1;

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            int id = 1;
            foreach(RadioButton rb in panel1.Controls)
            {
                if (rb.Checked)
                {
                    maxLength = (((rb.Location.X - 13)/100) + 1);

                    if(rb.Name == "baseBtn")
                    {
                        break;
                    }
                    id =  int.Parse(rb.Name);
                    break;
                }
                
            }

            if (conUTB.Text.All(char.IsDigit))
            {
                //BachelorApp.Program.Register(descTB.Text, id, Convert.ToInt32(conUTB.Text));
                btnCount++;

                RadioButton rBtn = new RadioButton();
                rBtn.Appearance = Appearance.Button;
                rBtn.BackColor = baseBtn.BackColor;
                rBtn.FlatStyle = FlatStyle.Flat;
                rBtn.FlatAppearance.MouseOverBackColor = baseBtn.FlatAppearance.MouseOverBackColor;
                rBtn.FlatAppearance.CheckedBackColor = baseBtn.FlatAppearance.CheckedBackColor;
                rBtn.Name = btnCount.ToString();
                rBtn.Location = new Point(baseBtn.Location.X + baseBtn.Width * maxLength + 20 * maxLength, baseBtn.Location.Y);
                rBtn.Size = baseBtn.Size;
                rBtn.TabStop = false;
                rBtn.CheckedChanged += new System.EventHandler(this.baseBtn_CheckedChanged);

                panel1.Controls.Add(rBtn);
                SortField();
            }
            else
            {
                MessageBox.Show("feil på nummer");
            }
        }
        private void SortField()
        {//todo bedre sortering basert på parent
            for (int i = 1; i <= maxLength; i++)
            {
                List<RadioButton> temprb = new List<RadioButton>();
                int arrayint = 0;
                foreach (RadioButton rb in panel1.Controls)
                {
                    if (((rb.Location.X - 13) / 100) == i)
                    {
                        temprb.Add(rb);
                        arrayint++;
                    }
                }

                if (temprb.Count > 0)
                {
                    for (int j = 0; j < temprb.Count; j++)
                    {
                        int heigth = panel1.Height / (temprb.Count + 1);
                        temprb[j].Location = new Point(temprb[j].Location.X, (panel1.Location.Y / 2) + (heigth * (j + 1)) - (baseBtn.Height / 2));
                    }
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rb in panel1.Controls)
            {
                if (rb.Checked)
                {
                    if(rb.Name == "baseBtn")
                    {
                        MessageBox.Show("Du kan ikke slette denne!");
                        break;
                    }
                    //BachelorApp.Program.DeleteNode(Convert.ToInt32(idTB.Text));
                    panel1.Controls.Remove(rb);
                    break;
                }

            }
            SortField();
        }

        private void baseBtn_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RadioButton rb in panel1.Controls)
            {
                if (rb.Checked)
                {
                    if(rb.Name == "baseBtn")
                    {
                        int id = 1;
                        descTB.Text = BachelorApp.Program.ViewSingleNodeDescription(Convert.ToInt32(id));
                        conUTB.Text = BachelorApp.Program.ViewSingleNodeConnected(Convert.ToInt32(id)).ToString();
                        break;
                    }
                    descTB.Text = BachelorApp.Program.ViewSingleNodeDescription(Convert.ToInt32(rb.Name));
                    conUTB.Text = BachelorApp.Program.ViewSingleNodeConnected(Convert.ToInt32(rb.Name)).ToString();
                    break;
                }   
            }
        }
    }
}
