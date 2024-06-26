using MyTaskData;
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

namespace MyTaskGUI
{
    public partial class SignIn : Form
    {
        private readonly HttpClient _httpClient;
        public SignIn()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5033/") };
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            // Ambil nilai dari textbox
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            // Validasi input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Panggil metode SignInAccount secara langsung
            SignInAccount(username, password);
        }

        private void SignInAccount(string username, string password)
        {
            try
            {
                // Kirim request PUT secara langsung
                var response = _httpClient.PutAsync($"SignInAccount?username={username}&password={password}", null).Result;

                // Periksa status response
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sign in successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Bersihkan textbox setelah login berhasil
                    textBoxUsername.Text = "";
                    textBoxPassword.Text = "";
                }
                else
                {
                    // Tangani kesalahan jika gagal sign in
                    string errorMessage = response.Content.ReadAsStringAsync().Result;
                    MessageBox.Show($"Sign in failed: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Tangani exception jika terjadi kesalahan
                MessageBox.Show($"Error signing in: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormInputs()
        {
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp register = new SignUp();
            register.Show();
            this.Hide();
        }
    }
}
