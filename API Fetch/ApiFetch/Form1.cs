using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ApiFetch
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        // Load event
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadUsersFromApiAsync();
        }

        // Grid cell click event
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle row clicks here
        }

        // Fetch and display users
        private async Task LoadUsersFromApiAsync()
        {
            string url = "https://jsonplaceholder.typicode.com/users";
            try
            {
                string json = await httpClient.GetStringAsync(url);
                var users = JArray.Parse(json)
                    .Select(u => new User
                    {
                        Name = (string)u["name"],
                        Email = (string)u["email"],
                        Phone = (string)u["phone"]
                    }).ToList();

                // Build DataTable
                DataTable table = new DataTable();
                table.Columns.Add("Name");
                table.Columns.Add("Email");
                table.Columns.Add("Phone");

                foreach (var user in users)
                {
                    table.Rows.Add(user.Name, user.Email, user.Phone);
                }

                // Bind to DataGridView
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone{ get; set; }
    }
}
