namespace windowsBook
{
    partial class alterchangeuser_user
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
            this.change = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userpawd = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.userid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // change
            // 
            this.change.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.change.Location = new System.Drawing.Point(217, 416);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(199, 57);
            this.change.TabIndex = 3;
            this.change.Text = "确认修改";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userpawd);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Controls.Add(this.userid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(145, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 365);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "个人信息";
            // 
            // userpawd
            // 
            this.userpawd.Location = new System.Drawing.Point(72, 292);
            this.userpawd.Name = "userpawd";
            this.userpawd.Size = new System.Drawing.Size(199, 30);
            this.userpawd.TabIndex = 5;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(72, 190);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(199, 30);
            this.username.TabIndex = 4;
            // 
            // userid
            // 
            this.userid.Enabled = false;
            this.userid.Location = new System.Drawing.Point(72, 87);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(199, 30);
            this.userid.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "密  码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "账  号";
            // 
            // alterchangeuser_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 513);
            this.Controls.Add(this.change);
            this.Controls.Add(this.groupBox1);
            this.Name = "alterchangeuser_user";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改个人信息";
            this.Load += new System.EventHandler(this.alterchangeuser_user_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button change;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox userpawd;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox userid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}