namespace MyTaskGUI
{
    partial class Form5
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelSideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(201)))), ((int)(((byte)(216)))));
            this.panel1.Controls.Add(this.buttonKeluar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panelSideBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 612);
            this.panel1.TabIndex = 0;
            // 
            // panelSideBar
            // 
            this.panelSideBar.AutoScroll = true;
            this.panelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
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
            this.panelSideBar.TabIndex = 24;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.label2.Location = new System.Drawing.Point(237, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 29);
            this.label2.TabIndex = 25;
            this.label2.Text = "SIGN OUT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(238, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 22);
            this.label1.TabIndex = 26;
            this.label1.Text = "Keluar dari akun yang digunakan";
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(68)))), ((int)(((byte)(102)))));
            this.buttonKeluar.FlatAppearance.BorderSize = 0;
            this.buttonKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeluar.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(242, 149);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(121, 38);
            this.buttonKeluar.TabIndex = 32;
            this.buttonKeluar.Text = "Keluar";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 612);
            this.Controls.Add(this.panel1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSideBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Button btnSignOutMenu;
        private System.Windows.Forms.Button btnUpProfileMenu;
        private System.Windows.Forms.Button btnDelAccountMenu;
        private System.Windows.Forms.Button btnViewTaskMenu;
        private System.Windows.Forms.Button btnAddTaskMenu;
        private System.Windows.Forms.Panel panelSideAtas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeluar;
    }
}