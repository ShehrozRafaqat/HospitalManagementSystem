using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.patient
{
    public partial class Bills : Form
    {
        public Bills()
        {
            InitializeComponent();
        }
        public static List<appointment> Appointments = new List<appointment>();
        static List<appointment> patientApp = new List<appointment>();
        static List<bill> bills = new List<bill>();
        static List<bill> patientBills = new List<bill>();
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Bills_Load(object sender, EventArgs e)
        {
            Appointments = crud.getAll<appointment>("/appointment/appointments");
            bills = crud.getAll<bill>("/bill/bills");
            foreach (appointment app in Appointments)
            {
                if (app.patient == Login_Page.user_id)
                    patientApp.Add(app);
            }
            foreach(bill b in bills)
            {
                foreach(appointment app in patientApp)
                {
                    if (b.appointment == app._Id)
                    {
                        patientBills.Add(b);
                        break;
                    }
                }
                
            }

            dataGridView1.DataSource = patientBills;
            dataGridView1.Columns.RemoveAt(0);
        }
    }
}
