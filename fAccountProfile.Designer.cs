namespace QuanLyQuanCafe
{
    partial class fAccountProfile
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
            panel2 = new Panel();
            txtUserName = new TextBox();
            lblUserName = new Label();
            panel1 = new Panel();
            txtDisplayName = new TextBox();
            lblDisplayName = new Label();
            panel3 = new Panel();
            txtPassword = new TextBox();
            lblPassword = new Label();
            panel4 = new Panel();
            textBox1 = new TextBox();
            lblNewPassword = new Label();
            panel5 = new Panel();
            textBox2 = new TextBox();
            lblRePassword = new Label();
            btnUpdate = new Button();
            btnExit = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txtUserName);
            panel2.Controls.Add(lblUserName);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(776, 63);
            panel2.TabIndex = 1;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(235, 23);
            txtUserName.Name = "txtUserName";
            txtUserName.ReadOnly = true;
            txtUserName.Size = new Size(527, 27);
            txtUserName.TabIndex = 1;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(14, 15);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(215, 35);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Tên đăng nhập:";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtDisplayName);
            panel1.Controls.Add(lblDisplayName);
            panel1.Location = new Point(12, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 63);
            panel1.TabIndex = 2;
            // 
            // txtDisplayName
            // 
            txtDisplayName.Location = new Point(235, 23);
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.Size = new Size(527, 27);
            txtDisplayName.TabIndex = 1;
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDisplayName.Location = new Point(14, 15);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(177, 35);
            lblDisplayName.TabIndex = 0;
            lblDisplayName.Text = "Tên hiển thị:";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtPassword);
            panel3.Controls.Add(lblPassword);
            panel3.Location = new Point(12, 150);
            panel3.Name = "panel3";
            panel3.Size = new Size(776, 63);
            panel3.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(235, 23);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(527, 27);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(14, 15);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(146, 35);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Mật khẩu:";
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(lblNewPassword);
            panel4.Location = new Point(12, 219);
            panel4.Name = "panel4";
            panel4.Size = new Size(776, 63);
            panel4.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(235, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(527, 27);
            textBox1.TabIndex = 1;
            textBox1.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNewPassword.Location = new Point(14, 15);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(203, 35);
            lblNewPassword.TabIndex = 0;
            lblNewPassword.Text = "Mật khẩu mới:";
            // 
            // panel5
            // 
            panel5.Controls.Add(textBox2);
            panel5.Controls.Add(lblRePassword);
            panel5.Location = new Point(12, 288);
            panel5.Name = "panel5";
            panel5.Size = new Size(776, 63);
            panel5.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(235, 23);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(527, 27);
            textBox2.TabIndex = 1;
            textBox2.UseSystemPasswordChar = true;
            // 
            // lblRePassword
            // 
            lblRePassword.AutoSize = true;
            lblRePassword.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRePassword.Location = new Point(14, 15);
            lblRePassword.Name = "lblRePassword";
            lblRePassword.Size = new Size(132, 35);
            lblRePassword.TabIndex = 0;
            lblRePassword.Text = "Nhập lại:";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(496, 370);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(109, 55);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(679, 370);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(109, 55);
            btnExit.TabIndex = 7;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // fAccountProfile
            // 
            AcceptButton = btnUpdate;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnUpdate);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "fAccountProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin cá nhân";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private TextBox txtUserName;
        private Label lblUserName;
        private Panel panel1;
        private TextBox txtDisplayName;
        private Label lblDisplayName;
        private Panel panel3;
        private TextBox txtPassword;
        private Label lblPassword;
        private Panel panel4;
        private TextBox textBox1;
        private Label lblNewPassword;
        private Panel panel5;
        private TextBox textBox2;
        private Label lblRePassword;
        private Button btnUpdate;
        private Button btnExit;
    }
}