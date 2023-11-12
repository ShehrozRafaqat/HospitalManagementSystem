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

using Newtonsoft.Json;
using System.Net.Http;
namespace HMS
{
    public partial class Login_Page : Form
    {
        List<User> users;
        private const string BaseUrl = "http://localhost:3000"; // Replace with your actual backend URL

        public Login_Page()
        {
            InitializeComponent();
        }

        private void Login_Page_Load(object sender, EventArgs e)
        {
            users =  getUsers();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void lgn_Click(object sender, EventArgs e)
        {
            foreach(User u in users)
            {
                if (u.Username == user.Text && u.Password == pwd.Text && u.Role ==GetUser())
                {
                    openForm();
                    return;
                }    
            }
            MessageBox.Show("Invalid username or password");
        }

        private void reg_Click(object sender, EventArgs e)
        {
            // Replace "/user/add" with your actual API endpoint
            string apiEndpoint = "/user/add";

            int role = GetUser();
            // Replace this with your actual user data
            var userData = new
            {
                username = user.Text,
                password = pwd.Text,
                role = role
                // Add other properties as needed
            };

            string jsonUserData = JsonConvert.SerializeObject(userData);
            HttpContent content = new StringContent(jsonUserData, Encoding.UTF8, "application/json");

            try
            {
                AddUserAsync(apiEndpoint, content);
                MessageBox.Show("User added successfully.");
                openForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}");
            }
        }

        private List<User> getUsers()
        {
            // Replace "/user/getAll" with your actual API endpoint for getting all users
            string getAllUsersEndpoint = "/user/users";

            try
            {
                Task<List<User>> users =  GetUsersAsync(getAllUsersEndpoint);
                return users.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting users: {ex.Message}");
            }
            return null;
        }
        private async Task <List<User>> GetUsersAsync(string apiEndpoint)
        {
            List<User> users = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string responseContent  = await client.GetStringAsync(apiEndpoint).ConfigureAwait(false);
                    
                    // Assuming Newtonsoft.Json.JsonConvert for deserialization
                    users = JsonConvert.DeserializeObject<List<User>>(responseContent);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return users;
            }
        }


        private async Task AddUserAsync(string apiEndpoint, HttpContent data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsync(apiEndpoint, data);

                response.EnsureSuccessStatusCode();
            }
        }

        private void Admin_op_CheckedChanged(object sender, EventArgs e)
        {
        }

        void openForm()
        {
            if (GetUser() == 1)
            {
                Hide();
                Admin.Admin a = new Admin.Admin();
                a.Show();
            }
                
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
