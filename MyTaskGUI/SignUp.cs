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
using System.Net.Http.Json;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = MyTaskData.Task;

namespace MyTaskGUI
{
    public partial class SignUp : Form
    {
        private readonly HttpClient _httpClient;

        private static readonly HttpClient _client = new HttpClient();
        public SignUp()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5033/") };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUpAccountAsync();
            SignIn form6 = new SignIn();
            form6.Show();
            this.Hide();
        }

        private async void SignUpAccountAsync()
        {
            try
            {
                // Membuat objek Account dari input form
                var account = new Account
                {
                    userName = textBoxUsername.Text,
                    name = textBoxName.Text,
                    email = textBoxEmail.Text,
                    password = textBoxPassword.Text
                };

                // Validasi menggunakan validator AccountValidator
                var validator = new AccountValidator();
                var validationResult = validator.Validate(account);

                // Jika validasi tidak berhasil, tampilkan pesan error dan return
                if (!validationResult.IsValid)
                {
                    string errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                    MessageBox.Show($"Invalid account data: {errors}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kirim data akun baru ke API menggunakan HttpClient
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("SignUpAccount", account);

                // Periksa apakah request berhasil
                response.EnsureSuccessStatusCode();

                // Tampilkan pesan sukses jika berhasil
                MessageBox.Show("Account created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kosongkan form input setelah berhasil
                ClearFormInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFormInputs()
        {
            // Mengosongkan input form setelah berhasil membuat akun
            textBoxUsername.Text = "";
            textBoxName.Text = "";
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void inputPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn form6 = new SignIn();
            form6.Show();
            this.Hide();
        }

        private void inputEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
