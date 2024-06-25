using FluentValidation.Results;
using MyTaskData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTaskGUI
{
    public partial class RegisterUI : Form
    {

        private static readonly HttpClient _client = new HttpClient();
        public RegisterUI()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(inputUsername.Text) ||
                string.IsNullOrWhiteSpace(inputName.Text) ||
                string.IsNullOrWhiteSpace(inputPassword.Text) ||
                string.IsNullOrWhiteSpace(inputEmail.Text))
            {
                MessageBox.Show("Semua field harus diisi.");
                return;
            }

            // Membuat model untuk sign up
            var signUpModel = new Account
            {
                userName = inputUsername.Text,
                name = inputName.Text,
                password = inputPassword.Text,
                email = inputEmail.Text
            };

            // Membuat validator dan melakukan validasi
            AccountValidator validator = new AccountValidator();
            var usernameCheck = validator.Validate(signUpModel, "Username");
            if (!usernameCheck.IsValid)
            {
                var errorMessage = string.Join("\n", usernameCheck.Errors.Select(x => x.ErrorMessage));
                MessageBox.Show(errorMessage);
                return;
            }

            var nameCheck = validator.Validate(signUpModel, "Nama");
            if (!nameCheck.IsValid)
            {
                var errorMessage = string.Join("\n", nameCheck.Errors.Select(x => x.ErrorMessage));
                MessageBox.Show(errorMessage);
                return;
            }

            var emailCheck = validator.Validate(signUpModel, "Email");
            if (!emailCheck.IsValid)
            {
                var errorMessage = string.Join("\n", emailCheck.Errors.Select(x => x.ErrorMessage));
                MessageBox.Show(errorMessage);
                return;
            }

            var passwordCheck = validator.Validate(signUpModel, "Password");
            if (!passwordCheck.IsValid)
            {
                var errorMessage = string.Join("\n", passwordCheck.Errors.Select(x => x.ErrorMessage));
                MessageBox.Show(errorMessage);
                return;
            }

            // Serialisasi model ke JSON
            var json = JsonConvert.SerializeObject(signUpModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // URL endpoint untuk sign up
                var url = "https://localhost:7116/MyTask/Account/SignUp";
                // Melakukan POST request ke API
                var response = await _client.PostAsync(url, data);

                // Membaca respons dari server
                string result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sign Up berhasil!");
                    Form6 form6 = new Form6();
                    form6.Show();
                    this.Hide();
                }
                else
                {
                    // Menangani error dengan menampilkan pesan dari server
                    MessageBox.Show("Gagal Sign Up: " + result); // Sederhanakan penanganan error untuk contoh ini
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            inputPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void inputPassword_TextChanged(object sender, EventArgs e)
        {
            inputPassword.PasswordChar = '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
    }
}
