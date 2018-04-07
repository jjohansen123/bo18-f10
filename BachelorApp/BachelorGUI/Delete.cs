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
        public static RadioButton DeleteBtn(List<RadioButton> listrb)
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
                    BachelorApp.Deletenode.DeleteNode(Convert.ToInt32(rb.Name));
                    return rb;
                }
            }
            MessageBox.Show("feil, fant ikke den du skulle slette");
            return null;
        }
    }
}
