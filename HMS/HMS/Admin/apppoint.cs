using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Admin
{
    public partial class apppoint : Form
    {
        public static List<appointment> Appointments;

        public apppoint()
        {
            InitializeComponent();
        }

        static List<User> doctors = new List<User>();

        private void apppoint_Load(object sender, EventArgs e)
        {
            Appointments = crud.getAll<appointment>("/appointment/appointments");
            dataGridView1.DataSource = Appointments;

            dataGridView1.Columns.RemoveAt(1);

            DataGridViewComboBoxColumn doc = new DataGridViewComboBoxColumn();
            doc.HeaderText = "Doctor";
            foreach(User u in Login_Page.users)
            {
                if (u.Role == 3)
                {
                    doc.Items.Add(u.Username);
                    doctors.Add(u);
                }
                    
            }


            dataGridView1.Columns.Add(doc);

            DataGridViewTextBoxColumn price = new DataGridViewTextBoxColumn();
            price.HeaderText = "Amount";

            dataGridView1.Columns.Add(price);
            // Create a Button Column
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Appoint";
            buttonColumn.Text = "Appoint";
            buttonColumn.UseColumnTextForButtonValue = true;

            // Add the Button Column to the DataGridView
            dataGridView1.Columns.Add(buttonColumn);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewComboBoxCell comboBoxCell = dataGridView1.Rows[e.RowIndex].Cells[4] as DataGridViewComboBoxCell;
            string doc="";
            if (comboBoxCell != null)
            {
                doc = doctors[comboBoxCell.Items.IndexOf(comboBoxCell.Value)]._Id;
            }
            var Data = new
            {
                patient = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                type = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                date_time = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                doc = doc
                // Add other properties as needed
            };

            if (e.ColumnIndex == dataGridView1.Columns[6].Index && e.RowIndex >= 0)
            {
                crud.update($"/appointment/update/{Appointments[e.RowIndex]._Id}",Data);
                crud.add("/bill/add",new {appointment = Appointments[e.RowIndex]._Id,amount = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() });
            }
        }
    }
}
