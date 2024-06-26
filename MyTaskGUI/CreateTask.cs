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
using Task = MyTaskData.Task;
using static MyTaskData.Task;

namespace MyTaskGUI
{
    public partial class CreateTask : Form
    {
        private readonly HttpClient _httpClient;
        public CreateTask()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5033/") };
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
            try
            {
                // Read input values
                string judul = textBoxJudul.Text.Trim();
                string deskripsi = textBoxDeskripsi.Text.Trim();
                string jenisTugas = comboJenisTugasInput.SelectedItem.ToString();
                string prioritas = comboPrioritasInput.SelectedItem.ToString();
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

                // Call method to create task
                addTask(task);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addTask(Task task)
        {
            try
            {
                // Serialize Task object to JSON
                string jsonTask = JsonConvert.SerializeObject(task);

                // Send HTTP POST request to CreateTask endpoint
                var content = new StringContent(jsonTask, System.Text.Encoding.UTF8, "application/json");
                var response = _httpClient.PostAsync("CreateTask", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Task created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset input fields
                    ResetInputFields();
                }
                else
                {
                    MessageBox.Show($"Failed to create task: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetInputFields()
        {
            textBoxJudul.Text = "";
            textBoxDeskripsi.Text = "";
            comboJenisTugasInput.SelectedIndex = -1;
            comboPrioritasInput.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            dateStartInput.Value = DateTime.Now;
            dateEndInput.Value = DateTime.Now;
        }

        private void btnViewTaskMenu_Click(object sender, EventArgs e)
        {
            ReadTask readTask = new ReadTask();
            this.Hide();
            readTask.Show();
        }
    }
}
