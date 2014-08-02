using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleCalendar
{
    public partial class Form_Main : Form
    {
        private bool IsFormBeingDragged = false;
        private int MouseDownX;
        private int MouseDownY;
        private db_SCContextDataContext db = new db_SCContextDataContext();

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDateNow.Text = DateTime.Now.ToString("MMMM dd yyyy" + Environment.NewLine + "dddd");
            lblDateNow.TextAlign = ContentAlignment.MiddleCenter;
            Graphics g = this.CreateGraphics();
            GlobalUsage.center_to_parent(lblDateNow, g);

            int timeUntilNextHour = (3600 - (int)DateTime.Now.TimeOfDay.TotalSeconds % 3600) * 1000;
            timer1.Interval = timeUntilNextHour;
            update_Events();
        }

        private void update_Events()
        {
            int current_pos = 65;

            int i = 0;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Event_Panel) { i++; }                
            }
            
            if (i > 0)
            {
                i = 0;
                for (i = this.Controls.Count - 1; i >= 0; i--)
                {
                    Control Ctrl = this.Controls[i];
                    if (Ctrl is Event_Panel)
                    {
                        this.Controls.Remove(Ctrl);
                    }
                }
            }

            var Items = (from Events in db.tbItems orderby Events.date ascending select Events).AsEnumerable();

            if (Items.Count() > 0)
            {
                foreach (var item in Items)
                {
                    DateTime CurrentDate = DateTime.Now;
                    int daysFromNow = (item.date.DayOfYear - CurrentDate.DayOfYear);

                    if (daysFromNow < 0)
                    {
                        db.tbItems.DeleteOnSubmit(item);
                        try { db.SubmitChanges(); }
                        catch (Exception e) { MessageBox.Show("Couldn't delete event: " + e.Message); }
                    }
                    else
                    {
                        Event_Panel Event = new Event_Panel(item.ID_Item, item.description, item.date, item.color);
                        this.Controls.Add(Event);
                        Event.Top = current_pos;
                        Event.Left += 10;
                        current_pos += 35;
                    }
                }
            }



            this.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form_AddItem Form = new Form_AddItem();
            Form.ShowDialog();
            this.Form1_Load(this, new EventArgs());
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                IsFormBeingDragged = true;
                MouseDownX = e.X;
                MouseDownY = e.Y;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsFormBeingDragged) {
                Point temp = new Point();

                temp.X = this.Location.X + (e.X - MouseDownX);
                temp.Y = this.Location.Y + (e.Y - MouseDownY);
                this.Location = temp;
                temp = Point.Empty;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                IsFormBeingDragged = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Event_Panel)
                {
                    Event_Panel p = (Event_Panel)ctrl;
                    if (p.Selected)
                    {
                        var Item = (from Items in db.tbItems where Items.ID_Item == p.EventID select Items).SingleOrDefault();
                        db.tbItems.DeleteOnSubmit(Item);
                    }
                }
            }
            try {
                db.SubmitChanges();
            } catch {
                MessageBox.Show("Couldn't delete selected events.");
            }

            update_Events();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            update_Events();
            timer1.Interval = 3600000;
        }
    }
}
