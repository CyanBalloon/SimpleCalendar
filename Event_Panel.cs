using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SimpleCalendar
{
    public class Event_Panel : Panel
    {
        private bool _Selected;
        private int _EventID;
        private DateTime _date;
        private Label lblEvent;
        private Label lblDate;

        public Event_Panel(int EventID, string description, DateTime date, int color)
            : base()
        {
            _date = date;

            this.EventID = EventID;
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
            this.Width = 149;
            this.Height = 30;
            this.BackColor = Color.Transparent;

            Font f = new Font("calibri", 9, FontStyle.Bold);
            Color c = System.Drawing.Color.FromArgb(color);

            lblEvent = new Label();
            lblEvent.Font = f;
            lblEvent.Text = description;
            lblEvent.ForeColor = Color.White;
            lblEvent.Width = this.Width;

            lblDate = new Label();
            lblDate.Font = f;
            lblDate.ForeColor = c;
            lblDate.Width = this.Width;

            this.Controls.Add(lblEvent);
            this.Controls.Add(lblDate);
            this.Cursor = Cursors.Hand;

            lblEvent.Top += 15;
            lblEvent.BringToFront();

            this.Click += new EventHandler(Event_Panel_Click);
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += new EventHandler(Event_Panel_Click);
            }

            update_date_text();
        }

        public void update_date_text() {
            DateTime CurrentDate = DateTime.Now;
            int daysFromNow = (this._date.DayOfYear - CurrentDate.DayOfYear);
            if (daysFromNow == 0)
            {
                lblDate.Text = "Today";
                lblDate.ForeColor = Color.Red;
            }
            else if (daysFromNow == 1)
            {
                lblDate.Text = "Tomorrow";
                lblDate.ForeColor = Color.Red;
            } 
            else if (daysFromNow <= 7) 
            {
                lblDate.Text = _date.ToString("dddd");
            }
            else
            {
                lblDate.Text = _date.ToString("dddd, MMMM d") + " (" + daysFromNow.ToString() + " days)";
            }
        }

        #region [Accessors]
        public bool Selected
        {
            get { return _Selected; }
            set { _Selected = value; }
        }

        public int EventID
        {
            get { return _EventID; }
            set { _EventID = value; }
        }
        #endregion

        #region [Events]
        public void Event_Panel_Click(object sender, EventArgs e)
        {
            Selected = !Selected;
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_Selected)
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                             Color.White, 1, ButtonBorderStyle.Solid,
                                             Color.White, 1, ButtonBorderStyle.Solid,
                                             Color.White, 1, ButtonBorderStyle.Solid,
                                             Color.White, 1, ButtonBorderStyle.Solid);
        }
        #endregion
    }
}
