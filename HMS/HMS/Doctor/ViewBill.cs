using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Doctor
{
    public partial class ViewBill : Form
    {
        public ViewBill()
        {
            InitializeComponent();
        }

        public static List<appointment> Appointments = new List<appointment>();
        static List<appointment> doctorApp = new List<appointment>();
        static List<bill> bills = new List<bill>();
        static List<bill> doctorBills = new List<bill>();

        private void ViewBill_Load(object sender, EventArgs e)
        {
            Appointments = crud.getAll<appointment>("/appointment/appointments");
            bills = crud.getAll<bill>("/bill/bills");
            foreach (appointment app in Appointments)
            {
                if (app.doc == Login_Page.user_id)
                    doctorApp.Add(app);
            }
            foreach (bill b in bills)
            {
                foreach (appointment app in doctorApp)
                {
                    if (b.appointment == app._Id)
                    {
                        doctorBills.Add(b);
                        break;
                    }
                }

            }

            dataGridView1.DataSource = doctorBills;
            dataGridView1.Columns.RemoveAt(0);
        }
    }
}
