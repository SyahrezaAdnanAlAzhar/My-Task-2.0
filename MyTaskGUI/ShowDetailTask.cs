using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Task = MyTaskData.Task;

namespace MyTaskGUI
{
    public partial class ShowDetailTask : Form
    {
        private readonly HttpClient _httpClient;
        public ShowDetailTask(string judul)
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5033/") };
            loadInfoTask(judul);
        }

        private async void loadInfoTask(string judul)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"GetATask/{judul}");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Task task = JsonConvert.DeserializeObject<Task>(responseBody);

                    // Mengisi kontrol dengan nilai dari task yang diterima
                    labelDeskripsi.Text = task.deskripsi;
                    labelTanggalMulai.Text = task.tanggalMulai.ToString("D");
                    labelTanggalMulai.Text = task.tanggalSelesai.ToString("D");
                    labelJenisTugas.Text = task.jenisTugas.ToString();
                    labelJenisTugas.Text = task.namaPrioritas.ToString();
                    labelJenisTugas.Text = task.taskState.ToString();
                    labelJudul.Text = task.judul;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Task not found or does not belong to active account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Tutup form jika task tidak ditemukan
                }
                else
                {
                    MessageBox.Show($"Failed to retrieve task: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Tutup form jika gagal mengambil data task
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Tutup form jika terjadi kesalahan lainnya
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ReadTask readTask = new ReadTask();
            this.Hide();
            readTask.Show();
        }
    }
}
