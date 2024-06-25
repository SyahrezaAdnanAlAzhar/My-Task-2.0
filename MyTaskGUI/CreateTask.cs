using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Json;
using MyTaskData;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyTaskGUI.Program;
using System.Net.Http;

namespace MyTaskGUI
{
    public partial class CreateTask : Form
    {
        private static readonly HttpClient _client = new HttpClient();
        public CreateTask()
        {
            InitializeComponent();
        }

        private void panelSideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtInputJudul_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateStartInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtInputDeskripsi_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnCreateTask_Click(object sender, EventArgs e)
        {
           
        }

        private async void buttonAddTask_Click(object sender, EventArgs e)
        {
            // Konversi nilai dari ComboBox ke enum JenisTugas
            if (Enum.TryParse(comboJenisTugasInput.SelectedItem.ToString(), out MyTaskData.Task.JenisTugas jenisTugas) &&
                Enum.TryParse(comboPrioritasInput.SelectedItem.ToString(), out MyTaskData.Task.Prioritas prioritas))
            {
                var task = new MyTaskData.Task
                {
                    judul = txtInputJudul.Text,
                    deskripsi = txtInputDeskripsi.Text,
                    tanggalMulai = dateStartInput.Value,
                    tanggalSelesai = dateEndInput.Value,
                    jenisTugas = jenisTugas, 
                    namaPrioritas = prioritas 
                };

                TaskValidator validator = new TaskValidator();
                var judulCheck = validator.Validate(task, "Judul");
                if (!judulCheck.IsValid)
                {
                    var errorMessage = string.Join("\n", judulCheck.Errors.Select(x => x.ErrorMessage));
                    MessageBox.Show(errorMessage);
                    return;
                }
                var deskripsiCheck = validator.Validate(task, "Deskripsi");
                if (!deskripsiCheck.IsValid)
                {
                    var errorMessage = string.Join("\n", deskripsiCheck.Errors.Select(x => x.ErrorMessage));
                    MessageBox.Show(errorMessage);
                    return;
                }
                var tanggalMulai = validator.Validate(task, "TanggalMulai");
                if (!tanggalMulai.IsValid)
                {
                    var errorMessage = string.Join("\n", tanggalMulai.Errors.Select(x => x.ErrorMessage));
                    MessageBox.Show(errorMessage);
                    return;
                }
                var tanggalSelesai = validator.Validate(task, "TanggalSelesai");
                if (!tanggalSelesai.IsValid)
                {
                    var errorMessage = string.Join("\n", tanggalSelesai.Errors.Select(x => x.ErrorMessage));
                    MessageBox.Show(errorMessage);
                    return;
                }
                var jenisTugasCheck = validator.Validate(task, "JenisTugas");
                if (!jenisTugasCheck.IsValid)
                {
                    var errorMessage = string.Join("\n", jenisTugasCheck.Errors.Select(x => x.ErrorMessage));
                    MessageBox.Show(errorMessage);
                    return;
                }
                var prioritasCheck = validator.Validate(task, "Prioritas");
                if (!prioritasCheck.IsValid)
                {
                    var errorMessage = string.Join("\n", prioritasCheck.Errors.Select(x => x.ErrorMessage));
                    MessageBox.Show(errorMessage);
                    return;
                }

                var json = JsonConvert.SerializeObject(task);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // URL endpoint untuk sign up
                    var url = "https://localhost:7116/MyTask/Task/CreateTask";
                    // Melakukan POST request ke API
                    var response = await _client.PostAsync(url, data);

                    // Membaca respons dari server
                    string result = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Sign Up berhasil!");
                        SignIn form6 = new SignIn();
                        form6.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Menangani error dengan menampilkan pesan dari server
                        MessageBox.Show("Gagal Sign Up: " + result); 
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    // Menangani kesalahan jaringan atau server
                    MessageBox.Show($"Error dalam menghubungi API: {httpEx.Message}");
                }
                catch (Exception ex)
                {
                    // Menangani kesalahan lainnya
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Jenis tugas atau prioritas tidak valid.");
            }
        }
    }
}
