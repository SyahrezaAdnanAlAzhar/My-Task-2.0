﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTaskGUI
{
    public partial class UpdateTask : Form
    {
        public UpdateTask(string judul)
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddTaskMenu_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            ReadTask readTask = new ReadTask();
            this.Hide();
            readTask.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
