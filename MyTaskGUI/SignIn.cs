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
        private static readonly HttpClient _client = new HttpClient();
        public SignIn()
        {
            InitializeComponent();
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(inputUsername.Text) ||
                string.IsNullOrWhiteSpace(inputPassword.Text))
            {
                MessageBox.Show("Semua field harus diisi.");
                return;
            }

            // Membuat model untuk sign in
            var signInModel = new Account
            {
                userName = inputUsername.Text,
                password = inputPassword.Text
            };

            // Membuat validator dan melakukan validasi
            AccountValidator validator = new AccountValidator();
            var usernameCheck = validator.Validate(signInModel, "Username");
            if (!usernameCheck.IsValid)
            {
                var errorMessage = string.Join("\n", usernameCheck.Errors.Select(x => x.ErrorMessage));
                MessageBox.Show(errorMessage);
                return;
            }

            var passwordCheck = validator.Validate(signInModel, "Password");
            if (!passwordCheck.IsValid)
            {
                var errorMessage = string.Join("\n", passwordCheck.Errors.Select(x => x.ErrorMessage));
                MessageBox.Show(errorMessage);
                return;
            }

            // Serialisasi model ke JSON
            var json = JsonConvert.SerializeObject(signInModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // URL endpoint untuk sign in
                var url = "https://localhost:7116/MyTask/Account/SignIn";
                // Melakukan POST request ke API
                var response = await _client.PutAsync(url, data);

                // Membaca respons dari server
                string result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sign In berhasil!");
                    ReadTask form3 = new ReadTask();
                    form3.Show();
                    this.Hide();
                }
                else
                {
                    // Menangani error dengan menampilkan pesan dari server
                    MessageBox.Show("Gagal Sign In: " + result); // Sederhanakan penanganan error untuk contoh ini
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

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp register = new SignUp();
            register.Show();
            this.Hide();
        }
    }
}
