using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalendar
{
    public partial class Form_AddItem : Form
    {
        public Form_AddItem()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            db_SCContextDataContext db = new db_SCContextDataContext();
            var item = new tbItems
            {
                date = DateTimePicker1.Value,
                description = txtEvent.Text,
                color = btnColor.BackColor.ToArgb()
            };

            db.tbItems.InsertOnSubmit(item);
            try { db.SubmitChanges(); }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }

            this.Close();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cDialog = new ColorDialog();

            if (cDialog.ShowDialog() == DialogResult.OK) {
                btnColor.BackColor = cDialog.Color;
            }
        }
    }
}
