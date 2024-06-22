namespace windowsBook
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.userid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.btn_enroll = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.lable_spit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.yanzhenma = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(158, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "账  号";
            // 
            // userid
            // 
            this.userid.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userid.Location = new System.Drawing.Point(285, 118);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(251, 38);
            this.userid.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(158, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "密  码";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password.Location = new System.Drawing.Point(285, 187);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(251, 38);
            this.password.TabIndex = 3;
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.SystemColors.Info;
            this.login_btn.FlatAppearance.BorderSize = 0;
            this.login_btn.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login_btn.Location = new System.Drawing.Point(285, 337);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(251, 50);
            this.login_btn.TabIndex = 4;
            this.login_btn.Text = "登录";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // btn_enroll
            // 
            this.btn_enroll.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btn_enroll.FlatAppearance.BorderSize = 0;
            this.btn_enroll.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_enroll.Location = new System.Drawing.Point(678, 441);
            this.btn_enroll.Name = "btn_enroll";
            this.btn_enroll.Size = new System.Drawing.Size(66, 28);
            this.btn_enroll.TabIndex = 5;
            this.btn_enroll.Text = "注册";
            this.btn_enroll.UseVisualStyleBackColor = false;
            this.btn_enroll.Click += new System.EventHandler(this.btn_enroll_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.Location = new System.Drawing.Point(174, 49);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(417, 40);
            this.title.TabIndex = 6;
            this.title.Text = "欢迎登录图书管理系统";
            // 
            // lable_spit
            // 
            this.lable_spit.AutoSize = true;
            this.lable_spit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable_spit.Location = new System.Drawing.Point(505, 446);
            this.lable_spit.Name = "lable_spit";
            this.lable_spit.Size = new System.Drawing.Size(152, 18);
            this.lable_spit.TabIndex = 7;
            this.lable_spit.Text = "没有账号？马上去";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(158, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "验证码";
            // 
            // pictureBoxCaptcha
            // 
            this.pictureBoxCaptcha.Location = new System.Drawing.Point(431, 244);
            this.pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            this.pictureBoxCaptcha.Size = new System.Drawing.Size(105, 52);
            this.pictureBoxCaptcha.TabIndex = 9;
            this.pictureBoxCaptcha.TabStop = false;
            this.pictureBoxCaptcha.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // yanzhenma
            // 
            this.yanzhenma.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yanzhenma.Location = new System.Drawing.Point(285, 252);
            this.yanzhenma.Name = "yanzhenma";
            this.yanzhenma.Size = new System.Drawing.Size(122, 38);
            this.yanzhenma.TabIndex = 10;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 517);
            this.Controls.Add(this.yanzhenma);
            this.Controls.Add(this.pictureBoxCaptcha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lable_spit);
            this.Controls.Add(this.title);
            this.Controls.Add(this.btn_enroll);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userid);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button btn_enroll;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label lable_spit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxCaptcha;
        private System.Windows.Forms.TextBox yanzhenma;
    }
}

