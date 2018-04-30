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
                    rb.Text = Math.Round(((conu / tconu) * 100), 2).ToString() + "%";
                }
            }
        }
    }
}
