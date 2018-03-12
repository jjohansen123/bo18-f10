using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class mainForm1 : Form
    {
        public mainForm1()
        {
            InitializeComponent();
        }
        int temp = 1;
        private void button1_Click(object sender, EventArgs e)
        {

            foreach(RadioButton rb in panel1.Controls)
            {
                if (rb.Checked)
                {
                    temp = (((rb.Location.X - 13)/100) + 1);
                    break;
                }
                
            }
            
            RadioButton rBtn = new RadioButton();
            rBtn.Appearance = Appearance.Button;
            rBtn.BackColor = baseBtn.BackColor;
            rBtn.FlatStyle = FlatStyle.Flat;
            rBtn.FlatAppearance.MouseOverBackColor = baseBtn.FlatAppearance.MouseOverBackColor;
            rBtn.FlatAppearance.CheckedBackColor = baseBtn.FlatAppearance.CheckedBackColor;
            rBtn.Name = "temp";
            rBtn.Location = new Point(baseBtn.Location.X + baseBtn.Width*temp + 20*temp, baseBtn.Location.Y);
            rBtn.Size = baseBtn.Size;
            rBtn.TabStop = false;
            panel1.Controls.Add(rBtn);
            sortField();
        }
        private void sortField()
        {
            for (int i = 1; i <= temp; i++)
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rb in panel1.Controls)
            {
                if (rb.Checked)
                {
                    panel1.Controls.Remove(rb);
                    break;
                }

            }
            sortField();
        }
    }
}
