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
    public partial class SignUp : Form
    {

        private static readonly HttpClient _client = new HttpClient();
        public SignUp()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
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
            SignIn form6 = new SignIn();
            form6.Show();
            this.Hide();
        }
    }
}
