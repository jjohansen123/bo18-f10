using System;
using System.Collections.Generic;
using System.Drawing;
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
                    string name = BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(Convert.ToInt32(rb.Name), SiteID);

                    if(TextRenderer.MeasureText(name, rb.Font).Width >= (rb.Width - 15))
                    {
                        for(int i = 0; i < name.Length; i++)
                        {
                            string TempName = new string(name.Take(name.Length - i).ToArray());
                            if(TextRenderer.MeasureText(TempName,rb.Font).Width < (rb.Width - 15))
                            {
                                name = TempName + "...";
                                break;
                            }
                        }
                    }

                    if (conu != 0 && tconu != 0)
                    {
                        rb.Text = name + "\n" + BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name), SiteID) + " Users" + "\n" + Math.Round(((conu / tconu) * 100), 2).ToString() + "%";
                    }

                    else
                    {
                        rb.Text = name + "\n" + BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(Convert.ToInt32(rb.Name), SiteID) + " Users" + "\n" + "100%";
                    }
                    
                }
            }
        }
    }
}
