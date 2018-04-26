using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BachelorModel;

namespace BachelorGUI
{
    class Drawing
    {
        public static void drawLines(List<RadioButton> listrb, Graphics g, Pen p, int siteID)
        {
            foreach(RadioButton rb in listrb)
            {
                if(rb.Name == "baseBtn")
                {
                    temprec(rb, listrb, g, p, siteID);
                    break;
                }
            }
        }
        private static void temprec(RadioButton prb, List<RadioButton> listrb, Graphics g, Pen p, int siteID)
        {
            List<Node> templist;
            if (prb.Name == "baseBtn")
            {
                templist = BachelorApp.ViewSingleNodeChildren.ViewChildren(1, siteID);
            }
            else
            {
                templist = BachelorApp.ViewSingleNodeChildren.ViewChildren(Convert.ToInt32(prb.Name), siteID);
            }
            
            if (templist != null)
            {            
                foreach(Node n in templist)
                {
                    foreach(RadioButton rb in listrb)
                    {
                        string temp = rb.Name;
                        if (rb.Name == "baseBtn")
                            temp = "1";
                        if(n.LocalID == Convert.ToInt32(temp) && n.SiteId == siteID)
                        {
                            temprec(rb, listrb, g, p, siteID);
                            g.DrawLine(p, prb.Location, rb.Location);
                            break;
                        }
                    }
                }
            }
        }
    }
}
