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
        public static RadioButton CreateRBtn(List<RadioButton> listrb, Int32 conU, string desc)
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
            if (conU >= 0)
            {
                BachelorApp.Register.RegisterNode(desc, id, conU);

                RadioButton rBtn = new RadioButton();
                rBtn.Appearance = Appearance.Button;
                rBtn.BackColor = baseBtn.BackColor;
                rBtn.FlatStyle = FlatStyle.Flat;
                rBtn.FlatAppearance.MouseOverBackColor = baseBtn.FlatAppearance.MouseOverBackColor;
                rBtn.FlatAppearance.CheckedBackColor = baseBtn.FlatAppearance.CheckedBackColor;
                rBtn.Name = BachelorApp.Highestnode.GetHighest(1).ToString();
                /*
                 *
                 * 
                 *
                 MARTIN FIKS DETTE!!!!!!
                 * todo
                 *
                 *
                 *
                 */
                rBtn.Location = new Point(baseBtn.Location.X + baseBtn.Width * maxLength + 20 * maxLength, baseBtn.Location.Y);
                rBtn.Size = baseBtn.Size;
                rBtn.TabStop = false;
               

                return rBtn;
            }
            else
            {
                MessageBox.Show("feil på nummer");
                return null;
            }
        }

        public static RadioButton CreateRBtnWithOutDB(List<RadioButton> listrb, int parent, int name)
        {
            int id = 1, maxLength = 1;
            foreach (RadioButton rb in listrb)
            {
                if(rb.Name == Convert.ToString(parent) || (rb.Name == "baseBtn" && parent == 1))
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

            RadioButton rBtn = new RadioButton();
            rBtn.Appearance = Appearance.Button;
            rBtn.BackColor = baseBtn.BackColor;
            rBtn.FlatStyle = FlatStyle.Flat;
            rBtn.FlatAppearance.MouseOverBackColor = baseBtn.FlatAppearance.MouseOverBackColor;
            rBtn.FlatAppearance.CheckedBackColor = baseBtn.FlatAppearance.CheckedBackColor;
            rBtn.Name = Convert.ToString(name);
            rBtn.Location = new Point(baseBtn.Location.X + baseBtn.Width * maxLength + 20 * maxLength, baseBtn.Location.Y);
            rBtn.Size = baseBtn.Size;
            rBtn.TabStop = false;

            return rBtn;
        }
        //todo private void create btn
    }
}
