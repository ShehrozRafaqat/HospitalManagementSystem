using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows.Forms;

namespace HMS
{
    class crud
    {
        public static void add(string apiEndpoint,object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            AddDataAsync(apiEndpoint,content);
        }

        public static void delete(string apiEndpoint, string idToDelete)
        {
            DeleteAsync(apiEndpoint, idToDelete);
        }

        public static void update(string apiEndpoint,object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            UpdateDataAsync(apiEndpoint, content);
        }
        private static async Task DeleteAsync(string apiEndpoint, string idToDelete)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Login_Page.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"{apiEndpoint}/{idToDelete}");


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

        public static List<T> getAll<T>(string apiEndpoint)
        {
            return GetAllDataAsync<T>(apiEndpoint).Result;
        }

        private static async Task UpdateDataAsync(string apiEndpoint, HttpContent data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Login_Page.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Assuming you are using the PUT method for updates. Modify this according to your API's requirements.
                HttpResponseMessage response = await client.PutAsync(apiEndpoint, data);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Data updated successfully.");
                }
                else
                {
                    MessageBox.Show($"Error updating data");
                }
            }
        }


        private static async Task AddDataAsync(string apiEndpoint, HttpContent data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Login_Page.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsync(apiEndpoint, data);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Data added successfully.");
                }
                else
                {
                    MessageBox.Show($"Error adding data");
                }
            }
        }

        private static async Task<List<T>> GetAllDataAsync<T>(string apiEndpoint)
        {
            List<T> data = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Login_Page.BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string responseContent = await client.GetStringAsync(apiEndpoint).ConfigureAwait(false);

                    // Assuming Newtonsoft.Json.JsonConvert for deserialization
                    data = JsonConvert.DeserializeObject<List<T>>(responseContent);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return data;
            }
        }
    }
}
