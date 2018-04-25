using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachelorGUI
{
    class NodeHasChildren
    {
        public static bool HasChild(List<RadioButton> listrb, int SiteID)
        {
            foreach (RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    if(BachelorApp.ViewSingleNodeChildren.ViewChildren(Convert.ToInt32(rb.Name), SiteID) == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
