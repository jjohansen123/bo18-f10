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
        public static void recolor(List<RadioButton> listrb, int SiteID)
        {
            foreach (RadioButton rb in listrb)
            {
                if(rb.Name != "baseBtn")
                {
                    int conu = BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name), SiteID);
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

                    else if(conu > 0)
                    {
                        rb.BackColor = ColorTranslator.FromHtml("#66ff66");
                        rb.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#00cc00");
                        rb.FlatAppearance.CheckedBackColor = ColorTranslator.FromHtml("#00cc00");
                    }

                    else
                    {
                        rb.BackColor = Color.Blue;
                        rb.FlatAppearance.MouseOverBackColor = Color.DarkBlue;
                        rb.FlatAppearance.CheckedBackColor = Color.DarkBlue;
                    }
                }
            }
        }
    }
}
