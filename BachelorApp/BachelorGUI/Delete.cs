using BachelorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachelorGUI
{
    class Delete
    {
        public static RadioButton DeleteBtn(List<RadioButton> listrb, int SiteID)
        {
            foreach (RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    if (rb.Name == "baseBtn")
                    {
                        MessageBox.Show("Du kan ikke slette denne!");
                        return null;
                    }
                    BachelorApp.Deletenode.DeleteNode(Convert.ToInt32(rb.Name), SiteID);
                    return rb;
                }
            }
            MessageBox.Show("feil, fant ikke den du skulle slette");
            return null;
        }

        public static List<RadioButton> DeleteBtnRec(List<RadioButton> listrb, int SiteID)
        {
            List<RadioButton> deleteList = new List<RadioButton>();
            foreach(RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    return recDelete(Convert.ToInt32(rb.Name), listrb, deleteList, SiteID);
                }
            }
            return null;
        }

        private static List<RadioButton> recDelete(int Parent, List<RadioButton> listrb, List<RadioButton> endlist, int SiteID)
        {
            List<Node> templist = BachelorApp.ViewSingleNodeChildren.ViewChildren(Parent,SiteID);
            if (templist == null)
            {
                foreach (RadioButton rb in listrb)
                {
                    if (rb.Name == Parent.ToString())
                    {
                        BachelorApp.Deletenode.DeleteNode(Convert.ToInt32(rb.Name),SiteID);
                        endlist.Add(rb);
                        return endlist;
                    }
                }
            }


            else
            {
                foreach (Node n in templist)
                {
                    endlist.AddRange(recDelete(n.NodeID, listrb, endlist, SiteID));
                }

                foreach (RadioButton rb in listrb)
                {
                    if (rb.Name == Parent.ToString())
                    {
                        BachelorApp.Deletenode.DeleteNode(Convert.ToInt32(rb.Name), SiteID);
                        endlist.Add(rb);
                        return endlist;
                    }
                }
            }
            return null;
        }
    }
}
