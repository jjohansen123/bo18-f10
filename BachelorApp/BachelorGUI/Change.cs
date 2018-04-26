using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachelorGUI
{
    class Change
    {
        public static void ChangeNode(List<RadioButton> listrb, string desc, int users, int SiteID)
        {
            int Lingling = 1;
            foreach (RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    if (rb.Name == "baseBtn")
                    {
                        break;
                    }
                    Lingling = Convert.ToInt32(rb.Name);
                    break;
                }
            }

            if (desc != BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(Lingling, SiteID))
            {
                BachelorApp.Updatenode.UpdateNodeDescription(Lingling, desc);
            }

            if (users != BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Lingling, SiteID))
            {
                BachelorApp.Updatenode.UpdateNodeUsers(Lingling, users);
            }
        }
    }
}
