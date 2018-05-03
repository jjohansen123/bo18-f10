using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BachelorGUI;

namespace BachelorGUI
{
    class Create
    {
        public static RadioButton CreateRBtn(List<RadioButton> listrb, Int32 conU, string desc, int SiteID, int ModelID)
        {
           
            int increaseLength = 100;
            int ParentID = 1, maxLength = 1;
            foreach (RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    maxLength = (((rb.Location.X - 13) / (100 + increaseLength)) + 1);

                    if (rb.Name == "baseBtn")
                    {
                        break;
                    }
                    ParentID = int.Parse(rb.Name);
                    break;
                }
            }//HIVEMIND MARTIN, HIVEMIND!
            BachelorApp.Register.RegisterNode(desc, "SETT INN COMMENT HER MARTIN", ParentID, conU, SiteID, ModelID);
            return createBTN(listrb,ParentID,BachelorApp.Highestnode.GetHighest(SiteID));
        }

        public static RadioButton CreateRBtnWithOutDB(List<RadioButton> listrb, int parent, int name)
        {
            return createBTN(listrb, parent, name);
        }

        private static RadioButton createBTN(List<RadioButton> listrb, int parent, int name)
        {
            int increaseLength = 100;
            int maxLength = 1;
            foreach (RadioButton rb in listrb)
            {
                if (rb.Name == Convert.ToString(parent) || (rb.Name == "baseBtn" && parent == 1))
                {
                    maxLength = (((rb.Location.X - 13) / (100 + increaseLength)) + 1);
                }

            }
            RadioButton baseBtn = new RadioButton();
            foreach (RadioButton rb in listrb)
            {
                if (rb.Name == "baseBtn")
                {
                    baseBtn = rb;
                    break;
                }
            }

            RadioButton rBtn = new RadioButton();
            rBtn.TextAlign = ContentAlignment.MiddleCenter;
            rBtn.Appearance = Appearance.Button;
            rBtn.BackColor = baseBtn.BackColor;
            rBtn.FlatStyle = FlatStyle.Flat;
            rBtn.FlatAppearance.MouseOverBackColor = baseBtn.FlatAppearance.MouseOverBackColor;
            rBtn.FlatAppearance.CheckedBackColor = baseBtn.FlatAppearance.CheckedBackColor;
            rBtn.Name = Convert.ToString(name);
            rBtn.Location = new Point(baseBtn.Location.X + baseBtn.Width * maxLength + 20 * maxLength + (increaseLength * maxLength), baseBtn.Location.Y);
            rBtn.Size = baseBtn.Size;
            rBtn.TabStop = false;

            return rBtn;
        }
    }
}
