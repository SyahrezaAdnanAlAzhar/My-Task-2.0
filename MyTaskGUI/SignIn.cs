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
            
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp register = new SignUp();
            register.Show();
            this.Hide();
        }
    }
}
