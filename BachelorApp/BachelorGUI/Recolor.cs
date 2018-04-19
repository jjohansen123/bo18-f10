using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace BachelorGUI
{
    class Recolor
    {
        public static void recolor(List<RadioButton> listrb)
        {
            Color basebtn = ColorTranslator.FromHtml("#000000"), basecheck = ColorTranslator.FromHtml("#000000");

            foreach (RadioButton rb in listrb)
            {
                if (rb.Name == "baseBtn")
                {
                    basebtn = rb.BackColor;
                    basecheck = rb.FlatAppearance.CheckedBackColor;
                }
            }
                    foreach (RadioButton rb in listrb)
            {
                if(rb.Name != "baseBtn")
                {
                    if (BachelorApp.ViewSingleNodeChildren.ViewChildren(Convert.ToInt32(rb.Name)) == null)
                    {
                        int conu = BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name));
                        if (conu > 45)
                        {
                            rb.BackColor = ColorTranslator.FromHtml("#ff4d4d");
                            rb.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#e60000");
                            rb.FlatAppearance.CheckedBackColor = ColorTranslator.FromHtml("#e60000");
                        }
                        else if(conu > 30)
                        {
                            rb.BackColor = ColorTranslator.FromHtml("#ffe066");
                            rb.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#ffcc00");
                            rb.FlatAppearance.CheckedBackColor = ColorTranslator.FromHtml("#ffcc00");
                        }
                        else
                        {
                            rb.BackColor = ColorTranslator.FromHtml("#66ff66");
                            rb.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00ff00");
                            rb.FlatAppearance.CheckedBackColor = ColorTranslator.FromHtml("#00ff00");
                        }
                    }
                    else
                    {
                        rb.BackColor = basebtn;
                        rb.FlatAppearance.MouseOverBackColor = basecheck;
                        rb.FlatAppearance.CheckedBackColor = basecheck;
                    }
                }
            }
        }
    }
}
