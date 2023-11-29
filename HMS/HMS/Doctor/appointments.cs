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
    public partial class appointments : Form
    {
        public static List<appointment> Appointments = new List<appointment>();
        static List<appointment> docApp = new List<appointment>();
        public appointments()
        {
            InitializeComponent();
        }

        private void appointments_Load(object sender, EventArgs e)
        {
            Appointments = crud.getAll<appointment>("/appointment/appointments");
            foreach (appointment app in Appointments)
            {
                if (app.doc == Login_Page.user_id)
                    docApp.Add(app);
            }
            dataGridView1.DataSource = docApp;
            dataGridView1.Columns.RemoveAt(0);
            // Create a Button Column
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Delete";
            buttonColumn.Text = "Delete";
            buttonColumn.UseColumnTextForButtonValue = true;

            // Add the Button Column to the DataGridView
            dataGridView1.Columns.Add(buttonColumn);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[3].Index && e.RowIndex >= 0)
            {
                crud.delete("/appointment/delete", docApp[e.RowIndex]._Id);
                docApp.RemoveAt(e.RowIndex);
                dataGridView1.Refresh();
            }
        }

        private void billsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBill b = new ViewBill();
            b.Show();
        }
    }
}
