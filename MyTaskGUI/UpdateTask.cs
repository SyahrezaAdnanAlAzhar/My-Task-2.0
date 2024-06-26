using MyTaskData;
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
using static MyTaskData.Task;
using Task = MyTaskData.Task;

namespace MyTaskGUI
{
    public partial class UpdateTask : Form
    {
        private readonly HttpClient _httpClient;
        public UpdateTask(string judul)
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
                    textBoxDeskripsi.Text = task.deskripsi;
                    dateStartInput.Value = task.tanggalMulai;
                    dateEndInput.Value = task.tanggalSelesai;
                    comboJenisTugas.SelectedIndex = (int)task.jenisTugas;
                    comboPrioritas.SelectedIndex = (int)task.namaPrioritas;
                    comboBoxStatus.SelectedIndex = (int)task.taskState;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddTaskMenu_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Read input values
                string judul = labelJudul.Text.Trim();
                string deskripsi = textBoxDeskripsi.Text.Trim();
                string jenisTugas = comboJenisTugas.SelectedItem.ToString();
                string prioritas = comboPrioritas.SelectedItem.ToString();
                string status = comboBoxStatus.SelectedItem.ToString();
                DateTime tanggalMulai = dateStartInput.Value;
                DateTime tanggalSelesai = dateEndInput.Value;

                // Convert string values to enum
                JenisTugas jenisTugasEnum;
                Enum.TryParse(jenisTugas, out jenisTugasEnum);

                Prioritas prioritasEnum;
                Enum.TryParse(prioritas, out prioritasEnum);

                TaskState statusEnum;
                Enum.TryParse(status, out statusEnum);

                // Create Task object
                var task = new Task
                {
                    judul = judul,
                    deskripsi = deskripsi,
                    jenisTugas = jenisTugasEnum,
                    namaPrioritas = prioritasEnum,
                    tanggalMulai = tanggalMulai,
                    tanggalSelesai = tanggalSelesai,
                    taskState = statusEnum
                };

                // Call method to update task
                updateTask(task);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            ReadTask readTask = new ReadTask();
            this.Hide();
            readTask.Show();
        }

        private void updateTask(Task task)
        {
            try
            {
                // Serialize Task object to JSON
                string jsonTask = JsonConvert.SerializeObject(task);

                // Send HTTP PUT request to UpdateTask endpoint
                var content = new StringContent(jsonTask, System.Text.Encoding.UTF8, "application/json");
                var response = _httpClient.PutAsync("UpdateTask", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Failed to update task: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
