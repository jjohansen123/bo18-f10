using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BachelorModel;

namespace BachelorGUI
{
    class Sort
    {
        public static void SortField(List<RadioButton> listrb, int panelHeight, int PanelLocY, int bntHeight, int SiteID)
        {
            int start = 1;//top node
            recSort(start, panelHeight, PanelLocY, listrb, SiteID);
        }
        private static void recSort(int Parent, int rangeTop, int rangeBot, List<RadioButton> listrb, int SiteID)
        {
            List<Node> templist = BachelorApp.ViewSingleNodeChildren.ViewChildren(Parent, SiteID);
            if (templist == null)
            {
                foreach(RadioButton rb in listrb)
                {
                    if(rb.Name == Parent.ToString())
                    {
                        rb.Location = new Point(rb.Location.X, (rangeTop) + ((rangeBot - rangeTop)/2) - (rb.Height / 2));
                    }

                    else if(rb.Name == "baseBtn" && Parent == 1)
                    {
                        rb.Location = new Point(rb.Location.X, (rangeTop) + ((rangeBot - rangeTop) / 2) - (rb.Height / 2));
                    }
                }
            }
            

            else
            {
                int range = (rangeBot - rangeTop) /templist.Count;
                int i = 0;
                foreach (Node n in templist)
                {
                    recSort(n.Lingling, rangeTop+(range * i), rangeTop + (range * (i+1)), listrb, SiteID);
                    foreach (RadioButton rb in listrb)
                    {
                        if (rb.Name == Parent.ToString())
                        {
                            rb.Location = new Point(rb.Location.X, (rangeTop) + ((rangeBot - rangeTop) / 2) - (rb.Height / 2));
                        }

                        else if (rb.Name == "baseBtn" && Parent == 1)
                        {
                            rb.Location = new Point(rb.Location.X, (rangeTop) + ((rangeBot - rangeTop) / 2) - (rb.Height / 2));
                        }
                    }
                    i++;
                }
            }
        }
    }
}
