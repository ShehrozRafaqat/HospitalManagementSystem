using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Newtonsoft.Json;
using System.Net.Http;
using System.Windows.Forms;

namespace HMS.patient
{
    public partial class addAppointment : Form
    {
        public addAppointment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Data = new
            {
                type = type.SelectedItem.ToString(),
                date_time = dateTimePicker1.Value.ToString(),
                doc = "",
                patient = Login_Page.user_id
                // Add other properties as needed
            };
            crud.add("/appointment/add",Data);
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addAppointment_Load(object sender, EventArgs e)
        {

        }

        private void billsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bills b = new Bills();
            b.Show();
        }
    }
}
