﻿namespace MyTaskGUI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.btnSignOutMenu = new System.Windows.Forms.Button();
            this.btnUpProfileMenu = new System.Windows.Forms.Button();
            this.btnDelAccountMenu = new System.Windows.Forms.Button();
            this.btnViewTaskMenu = new System.Windows.Forms.Button();
            this.btnAddTaskMenu = new System.Windows.Forms.Button();
            this.panelSideAtas = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.comboPrioritasInput = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboJenisTugasInput = new System.Windows.Forms.ComboBox();
            this.dateEndInput = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateStartInput = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInputDeskripsi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputJudul = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDeleteAccountMenu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelSideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(201)))), ((int)(((byte)(216)))));
            this.panel1.Controls.Add(this.panelSideBar);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboPrioritasInput);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboJenisTugasInput);
            this.panel1.Controls.Add(this.dateEndInput);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateStartInput);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtInputDeskripsi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtInputJudul);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 612);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panelSideBar
            // 
            this.panelSideBar.AutoScroll = true;
            this.panelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.panelSideBar.Controls.Add(this.buttonDeleteAccountMenu);
            this.panelSideBar.Controls.Add(this.btnSignOutMenu);
            this.panelSideBar.Controls.Add(this.btnUpProfileMenu);
            this.panelSideBar.Controls.Add(this.btnDelAccountMenu);
            this.panelSideBar.Controls.Add(this.btnViewTaskMenu);
            this.panelSideBar.Controls.Add(this.btnAddTaskMenu);
            this.panelSideBar.Controls.Add(this.panelSideAtas);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Location = new System.Drawing.Point(0, 0);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(191, 612);
            this.panelSideBar.TabIndex = 31;
            // 
            // btnSignOutMenu
            // 
            this.btnSignOutMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSignOutMenu.FlatAppearance.BorderSize = 0;
            this.btnSignOutMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOutMenu.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOutMenu.ForeColor = System.Drawing.Color.White;
            this.btnSignOutMenu.Location = new System.Drawing.Point(0, 251);
            this.btnSignOutMenu.Name = "btnSignOutMenu";
            this.btnSignOutMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSignOutMenu.Size = new System.Drawing.Size(191, 45);
            this.btnSignOutMenu.TabIndex = 7;
            this.btnSignOutMenu.Text = "Sign Out";
            this.btnSignOutMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignOutMenu.UseVisualStyleBackColor = true;
            // 
            // btnUpProfileMenu
            // 
            this.btnUpProfileMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpProfileMenu.FlatAppearance.BorderSize = 0;
            this.btnUpProfileMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpProfileMenu.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpProfileMenu.ForeColor = System.Drawing.Color.White;
            this.btnUpProfileMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpProfileMenu.Location = new System.Drawing.Point(0, 206);
            this.btnUpProfileMenu.Name = "btnUpProfileMenu";
            this.btnUpProfileMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUpProfileMenu.Size = new System.Drawing.Size(191, 45);
            this.btnUpProfileMenu.TabIndex = 6;
            this.btnUpProfileMenu.Text = "Update Profile";
            this.btnUpProfileMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpProfileMenu.UseVisualStyleBackColor = true;
            // 
            // btnDelAccountMenu
            // 
            this.btnDelAccountMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelAccountMenu.FlatAppearance.BorderSize = 0;
            this.btnDelAccountMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelAccountMenu.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelAccountMenu.ForeColor = System.Drawing.Color.White;
            this.btnDelAccountMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelAccountMenu.Location = new System.Drawing.Point(0, 161);
            this.btnDelAccountMenu.Name = "btnDelAccountMenu";
            this.btnDelAccountMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDelAccountMenu.Size = new System.Drawing.Size(191, 45);
            this.btnDelAccountMenu.TabIndex = 5;
            this.btnDelAccountMenu.Text = "Delete Account";
            this.btnDelAccountMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelAccountMenu.UseVisualStyleBackColor = true;
            // 
            // btnViewTaskMenu
            // 
            this.btnViewTaskMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewTaskMenu.FlatAppearance.BorderSize = 0;
            this.btnViewTaskMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewTaskMenu.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewTaskMenu.ForeColor = System.Drawing.Color.White;
            this.btnViewTaskMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewTaskMenu.Location = new System.Drawing.Point(0, 116);
            this.btnViewTaskMenu.Name = "btnViewTaskMenu";
            this.btnViewTaskMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnViewTaskMenu.Size = new System.Drawing.Size(191, 45);
            this.btnViewTaskMenu.TabIndex = 3;
            this.btnViewTaskMenu.Text = "View Task";
            this.btnViewTaskMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewTaskMenu.UseVisualStyleBackColor = true;
            // 
            // btnAddTaskMenu
            // 
            this.btnAddTaskMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddTaskMenu.FlatAppearance.BorderSize = 0;
            this.btnAddTaskMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTaskMenu.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTaskMenu.ForeColor = System.Drawing.Color.White;
            this.btnAddTaskMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTaskMenu.Location = new System.Drawing.Point(0, 71);
            this.btnAddTaskMenu.Name = "btnAddTaskMenu";
            this.btnAddTaskMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAddTaskMenu.Size = new System.Drawing.Size(191, 45);
            this.btnAddTaskMenu.TabIndex = 1;
            this.btnAddTaskMenu.Text = "Add Task";
            this.btnAddTaskMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTaskMenu.UseVisualStyleBackColor = true;
            // 
            // panelSideAtas
            // 
            this.panelSideAtas.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSideAtas.Location = new System.Drawing.Point(0, 0);
            this.panelSideAtas.Name = "panelSideAtas";
            this.panelSideAtas.Size = new System.Drawing.Size(191, 71);
            this.panelSideAtas.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.label7.Location = new System.Drawing.Point(304, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 22);
            this.label7.TabIndex = 30;
            this.label7.Text = "Prioritas";
            // 
            // comboPrioritasInput
            // 
            this.comboPrioritasInput.FormattingEnabled = true;
            this.comboPrioritasInput.Items.AddRange(new object[] {
            "Highest",
            "High",
            "Medium",
            "Low",
            "Lowest"});
            this.comboPrioritasInput.Location = new System.Drawing.Point(397, 429);
            this.comboPrioritasInput.Name = "comboPrioritasInput";
            this.comboPrioritasInput.Size = new System.Drawing.Size(289, 21);
            this.comboPrioritasInput.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.label6.Location = new System.Drawing.Point(285, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 22);
            this.label6.TabIndex = 28;
            this.label6.Text = "Jenis Tugas";
            // 
            // comboJenisTugasInput
            // 
            this.comboJenisTugasInput.FormattingEnabled = true;
            this.comboJenisTugasInput.Items.AddRange(new object[] {
            "Video ",
            "Laporan",
            "Project",
            "Desain",
            "Proposal",
            "Slide Presentasi",
            "Observasi",
            "Quiz",
            "Forum Diskusi"});
            this.comboJenisTugasInput.Location = new System.Drawing.Point(397, 386);
            this.comboJenisTugasInput.Name = "comboJenisTugasInput";
            this.comboJenisTugasInput.Size = new System.Drawing.Size(289, 21);
            this.comboJenisTugasInput.TabIndex = 27;
            // 
            // dateEndInput
            // 
            this.dateEndInput.Location = new System.Drawing.Point(397, 339);
            this.dateEndInput.Name = "dateEndInput";
            this.dateEndInput.Size = new System.Drawing.Size(289, 20);
            this.dateEndInput.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.label5.Location = new System.Drawing.Point(251, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 22);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tanggal Selesai";
            // 
            // dateStartInput
            // 
            this.dateStartInput.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.dateStartInput.Location = new System.Drawing.Point(397, 296);
            this.dateStartInput.Name = "dateStartInput";
            this.dateStartInput.Size = new System.Drawing.Size(289, 20);
            this.dateStartInput.TabIndex = 24;
            this.dateStartInput.Value = new System.DateTime(2024, 6, 22, 10, 16, 51, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.label4.Location = new System.Drawing.Point(263, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 22);
            this.label4.TabIndex = 23;
            this.label4.Text = "Tanggal Mulai";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.label3.Location = new System.Drawing.Point(304, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 22;
            this.label3.Text = "Deskripsi";
            // 
            // txtInputDeskripsi
            // 
            this.txtInputDeskripsi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInputDeskripsi.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputDeskripsi.Location = new System.Drawing.Point(397, 138);
            this.txtInputDeskripsi.Multiline = true;
            this.txtInputDeskripsi.Name = "txtInputDeskripsi";
            this.txtInputDeskripsi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInputDeskripsi.Size = new System.Drawing.Size(398, 135);
            this.txtInputDeskripsi.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(335, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "Judul";
            // 
            // txtInputJudul
            // 
            this.txtInputJudul.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInputJudul.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputJudul.Location = new System.Drawing.Point(397, 95);
            this.txtInputJudul.Name = "txtInputJudul";
            this.txtInputJudul.Size = new System.Drawing.Size(398, 19);
            this.txtInputJudul.TabIndex = 19;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(397, 485);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(121, 38);
            this.buttonSave.TabIndex = 18;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.label2.Location = new System.Drawing.Point(243, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "UPDATE TASK";
            // 
            // buttonDeleteAccountMenu
            // 
            this.buttonDeleteAccountMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDeleteAccountMenu.FlatAppearance.BorderSize = 0;
            this.buttonDeleteAccountMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteAccountMenu.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteAccountMenu.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteAccountMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteAccountMenu.Location = new System.Drawing.Point(0, 296);
            this.buttonDeleteAccountMenu.Name = "buttonDeleteAccountMenu";
            this.buttonDeleteAccountMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonDeleteAccountMenu.Size = new System.Drawing.Size(191, 45);
            this.buttonDeleteAccountMenu.TabIndex = 9;
            this.buttonDeleteAccountMenu.Text = "Delete Account";
            this.buttonDeleteAccountMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteAccountMenu.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 612);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSideBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboPrioritasInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboJenisTugasInput;
        private System.Windows.Forms.DateTimePicker dateEndInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateStartInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInputDeskripsi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputJudul;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Button btnSignOutMenu;
        private System.Windows.Forms.Button btnUpProfileMenu;
        private System.Windows.Forms.Button btnDelAccountMenu;
        private System.Windows.Forms.Button btnViewTaskMenu;
        private System.Windows.Forms.Button btnAddTaskMenu;
        private System.Windows.Forms.Panel panelSideAtas;
        private System.Windows.Forms.Button buttonDeleteAccountMenu;
    }
}