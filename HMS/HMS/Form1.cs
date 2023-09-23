using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HMS
{
    public partial class Login_Page : Form
    {
        public Login_Page()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void Login_Page_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void lgn_Click(object sender, EventArgs e)
        {
            con = Configuration.getInstance().getConnection();
            // Create a SQL command
            using (cmd = new SqlCommand("SELECT * FROM Users", con))
            {
                // Execute the query and get the result
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<User> userList = new List<User>();

                    // Read each row from the result set
                    while (reader.Read())
                    {
                        User user = new User
                        {
                            Role = (int)reader["role"],
                            Username = (string)reader["username"],
                            Password = (string)reader["password"]
                        };

                        userList.Add(user);
                    }

                    // Close the reader
                    reader.Close();

                    foreach(User u in userList)
                    {
                        if(u.Username == user.Text && u.Password == pwd.Text && u.Role == GetUser())
                        {
                            Admin.Admin a = new Admin.Admin();
                            Hide();
                            a.Show();
                            return;
                        } 
                    }
                    MessageBox.Show("Invalid username or password, try registering");
                }
                
            }

           
        }

        private void reg_Click(object sender, EventArgs e)
        {
            con = Configuration.getInstance().getConnection();
            cmd = new SqlCommand(" Insert into Users values (@role,@username,@password)", con);
            //cmd.Parameters.AddWithValue("@Id", int.Parse(Id_txt.Text));

            if(Admin_op.Checked)
                cmd.Parameters.AddWithValue("@role", 1);

            if (patientOp.Checked)
                cmd.Parameters.AddWithValue("@role", 2);

            if (doctorOp.Checked)
                cmd.Parameters.AddWithValue("@role", 3);

            if (staffOp.Checked)
                cmd.Parameters.AddWithValue("@role", 4);

            cmd.Parameters.AddWithValue("@username", user.Text);
            cmd.Parameters.AddWithValue("@password", (pwd.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");

            Admin.Admin a = new Admin.Admin();
            Hide();
            a.Show();
        }

        private void Admin_op_CheckedChanged(object sender, EventArgs e)
        {
        }

        int GetUser()
        {
            if (Admin_op.Checked)
                return 1;

            if (patientOp.Checked)
                return 2;

            if (doctorOp.Checked)
                return 3;

            if (staffOp.Checked)
                return 4;
            return 0;
        }
    }
}
