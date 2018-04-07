using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachelorGUI
{
    class Sort
    {
        public static void SortField(List<RadioButton> listrb, int panelHeight, int PanelLocY, int bntHeight)
        {
            int maxLength = 0;
            foreach(RadioButton rb in listrb)
            {
                if (rb.Location.X > maxLength)
                    maxLength = rb.Location.X;
            }
            maxLength = (((maxLength - 13) / 100) + 1);

            for (int i = 0; i <= maxLength; i++)
            {
                List<RadioButton> temprb = new List<RadioButton>();
                int arrayint = 0;
                foreach (RadioButton rb in listrb)
                {
                    if (((rb.Location.X - 13) / 100) == i)
                    {
                        temprb.Add(rb);
                        arrayint++;
                    }
                }

                if (temprb.Count > 0)
                {
                    for (int j = 0; j < temprb.Count; j++)
                    {
                        int heigth = panelHeight / (temprb.Count + 1);
                        temprb[j].Location = new Point(temprb[j].Location.X, (PanelLocY / 2) + (heigth * (j + 1)) - (bntHeight / 2));
                    }
                }
            }
        }
    }
}
