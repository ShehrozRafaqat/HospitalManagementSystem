using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS.Admin
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Login_Page.users;


            // Create a Button Column
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Delete";
            buttonColumn.Text = "Delete";
            buttonColumn.UseColumnTextForButtonValue = true;

            // Add the Button Column to the DataGridView
            dataGridView1.Columns.Add(buttonColumn);


        }

        private async Task DeleteUserAsync(string apiEndpoint, string idToDelete)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Login_Page.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"{apiEndpoint}/{idToDelete}");


                MessageBox.Show(Login_Page.BaseUrl+ $"{apiEndpoint}/{idToDelete}");
                if (response.IsSuccessStatusCode)
                {
                    // Object deleted successfully
                    MessageBox.Show($"Object with ID {idToDelete} deleted successfully.");
                }
                else
                {
                    MessageBox.Show($"Failed to delete object with ID {idToDelete}. Error: {response.StatusCode}");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[4].Index && e.RowIndex >= 0)
            {
                DeleteUserAsync("/user/delete",Login_Page.users[e.RowIndex]._Id);
            }
        }

        private void manageAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apppoint a = new apppoint();
            a.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bills b = new bills();
            b.Show();
        }
    }
}
