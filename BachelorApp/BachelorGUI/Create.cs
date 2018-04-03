﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BachelorGUI;

namespace WindowsFormsApp1
{
    class Create
    {
        public RadioButton Create(List<RadioButton> listrb, Int32 conU, string desc)
        {
            int id = 1, maxLength = 1;
            foreach (RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    maxLength = (((rb.Location.X - 13) / 100) + 1);

                    if (rb.Name == "baseBtn")
                    {
                        break;
                    }
                    id = int.Parse(rb.Name);
                    break;
                }

            }
            RadioButton baseBtn = new RadioButton();
            foreach (RadioButton rb in listrb)
            {
                if (rb.Name == "baseBtn")
                    baseBtn = rb;

            }
            if (conU<= 0)
            {
                BachelorApp.Program.Register(desc, id, conU);
                //btnCount++;

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
                //rBtn.CheckedChanged += new System.EventHandler(BachelorGUI.MainForm1.ActiveForm.Controls.baseBtn_CheckedChanged);

                return rBtn;
            }
            else
            {
                MessageBox.Show("feil på nummer");
                return null;
            }
        }
    }
}
