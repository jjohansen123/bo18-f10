using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachelorGUI
{
    class AddPercent
    {
        public static void addPercent(List<RadioButton> listrb, int SiteID)
        {
            foreach(RadioButton rb in listrb)
            {
                if(rb.Name != "baseBtn")
                {
                    double conu, tconu;
                    conu = BachelorApp.ViewSingleNodeTotalConnected.viewSingleNodeTotalConnected(Convert.ToInt32(rb.Name), SiteID);
                    tconu = BachelorApp.ViewSingleNodeTotalConnected.viewSingleNodeTotalConnected(BachelorApp.Viewsinglenodeparent.ViewSingleNodeParent(Convert.ToInt32(rb.Name), SiteID), SiteID) - BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(BachelorApp.Viewsinglenodeparent.ViewSingleNodeParent(Convert.ToInt32(rb.Name), SiteID), SiteID);
                    if(conu != 0 && tconu != 0)
                    {
                        rb.Text = BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name), SiteID) + "\n" + BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name), SiteID) + " Users" + "\n" + Math.Round(((conu / tconu) * 100), 2).ToString() + "%";
                    }
                    else
                    {
                        rb.Text = BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name), SiteID) + "\n" + BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name), SiteID) + " Users" + "\n" + "100%";
                    }
                    
                }
            }
        }
    }
}
