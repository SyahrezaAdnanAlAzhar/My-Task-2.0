using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyTaskGUI.Program;

namespace MyTaskGUI
{
    public partial class ReadTask : Form
    {
        private readonly HttpClient _httpClient;
        public ReadTask()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5033/") };
            LoadJudulTasks();
        }

        private void LoadJudulTasks()
        {
            listBoxJudulTask.Items.Clear();
            try
            {
                // Kirim GET request ke endpoint GetAllJudulTask
                var response = _httpClient.GetAsync("GetAllJudulTask").Result;

                if (response.IsSuccessStatusCode)
                {
                    // Ambil data response sebagai List<string> dari judul-judul task
                    var judulTasks = response.Content.ReadAsStringAsync().Result;
                    var judulList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(judulTasks);

                    // Tambahkan judul-judul task ke listBoxJudulTask
                    foreach (var judul in judulList)
                    {
                        listBoxJudulTask.Items.Add(judul);
                    }
                }
                else
                {
                    // Tangani jika request tidak berhasil
                    MessageBox.Show($"Failed to retrieve tasks: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Tangani exception jika terjadi kesalahan
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteTask(string judul)
        {
            try
            {
                // Kirim DELETE request ke endpoint DeleteTask
                var response = _httpClient.DeleteAsync($"DeleteTask?judul={judul}").Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Task berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadJudulTasks(); // Refresh list setelah penghapusan
                }
                else
                {
                    string errorMessage = response.Content.ReadAsStringAsync().ToString();
                    MessageBox.Show($"Gagal menghapus task: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonShowDetail_Click(object sender, EventArgs e)
        {

        }

        private void listBoxJudulTask_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddTaskMenu_Click(object sender, EventArgs e)
        {
            CreateTask createTask = new CreateTask();
            this.Hide();
            createTask.Show();
        }

        private void buttonDeleteTask_Click(object sender, EventArgs e)
        {
            if (listBoxJudulTask.SelectedIndex != -1)
            {
                string selectedJudul = listBoxJudulTask.SelectedItem.ToString();

                // Panggil metode untuk menghapus task dengan judul yang terpilih
                deleteTask(selectedJudul);
            }
            else
            {
                MessageBox.Show("Pilih sebuah judul task untuk dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonUpdateTask_Click(object sender, EventArgs e)
        {
            if (listBoxJudulTask.SelectedIndex != -1)
            {
                string selectedJudul = listBoxJudulTask.SelectedItem.ToString();

                UpdateTask updateTask = new UpdateTask(selectedJudul);
                this.Hide();
                updateTask.Show();
                
            }
            else
            {
                MessageBox.Show("Pilih sebuah judul task untuk diupdate.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
