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
    public partial class bills : Form
    {
        public bills()
        {
            InitializeComponent();
        }
        static List<bill> bill = new List<bill>();

        private void bills_Load(object sender, EventArgs e)
        {
            bill = crud.getAll<bill>("/bill/bills");
            
            

            dataGridView1.DataSource = bill;
            dataGridView1.Columns.RemoveAt(0);
        }
    }
}
