using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SimpleCalendar
{
    public static class GlobalUsage
    {
        public static System.Drawing.Font Global_Font = new System.Drawing.Font("Calibri", 10F);

        static GlobalUsage() { }

        public static void center_to_parent(Control control, Graphics g) {
            control.Left = control.Parent.Width / 2;
            control.Left -= Convert.ToInt32(g.MeasureString(control.Text, control.Font).Width / 2);
            control.Top = control.Parent.Height / 2;
            control.Top -= Convert.ToInt32(g.MeasureString(control.Text, control.Font).Height / 2);
        }
    }
}
