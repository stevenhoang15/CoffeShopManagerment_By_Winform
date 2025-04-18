namespace QuanLyQuanCafe
{
    partial class fLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnExit = new Button();
            btnLogin = new Button();
            panel3 = new Panel();
            txtBoxUserPassword = new TextBox();
            labUserPassword = new Label();
            panel2 = new Panel();
            txtBoxUserName = new TextBox();
            labUserName = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(733, 279);
            panel1.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(529, 217);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(142, 29);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(349, 217);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(142, 29);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtBoxUserPassword);
            panel3.Controls.Add(labUserPassword);
            panel3.Location = new Point(9, 118);
            panel3.Name = "panel3";
            panel3.Size = new Size(716, 63);
            panel3.TabIndex = 1;
            // 
            // txtBoxUserPassword
            // 
            txtBoxUserPassword.Location = new Point(235, 23);
            txtBoxUserPassword.Name = "txtBoxUserPassword";
            txtBoxUserPassword.Size = new Size(438, 27);
            txtBoxUserPassword.TabIndex = 1;
            txtBoxUserPassword.Text = "123";
            txtBoxUserPassword.UseSystemPasswordChar = true;
            // 
            // labUserPassword
            // 
            labUserPassword.AutoSize = true;
            labUserPassword.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labUserPassword.Location = new Point(14, 15);
            labUserPassword.Name = "labUserPassword";
            labUserPassword.Size = new Size(146, 35);
            labUserPassword.TabIndex = 0;
            labUserPassword.Text = "Mật khẩu:";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtBoxUserName);
            panel2.Controls.Add(labUserName);
            panel2.Location = new Point(9, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(716, 63);
            panel2.TabIndex = 0;
            // 
            // txtBoxUserName
            // 
            txtBoxUserName.Location = new Point(235, 23);
            txtBoxUserName.Name = "txtBoxUserName";
            txtBoxUserName.Size = new Size(438, 27);
            txtBoxUserName.TabIndex = 1;
            txtBoxUserName.Text = "admin";
            txtBoxUserName.TextChanged += textBox1_TextChanged;
            // 
            // labUserName
            // 
            labUserName.AutoSize = true;
            labUserName.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labUserName.Location = new Point(14, 15);
            labUserName.Name = "labUserName";
            labUserName.Size = new Size(215, 35);
            labUserName.TabIndex = 0;
            labUserName.Text = "Tên đăng nhập:";
            // 
            // fLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(738, 286);
            Controls.Add(panel1);
            Name = "fLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            FormClosing += fLogin_FormClosing;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label labUserName;
        private TextBox txtBoxUserName;
        private Panel panel3;
        private TextBox txtBoxUserPassword;
        private Label labUserPassword;
        private Button btnExit;
        private Button btnLogin;
    }
}
