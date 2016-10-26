﻿namespace EmailAutoLogin
{
    partial class Form1
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnAddAcount = new System.Windows.Forms.Button();
            this.btnDelAccount = new System.Windows.Forms.Button();
            this.btnChangeAccountInfo = new System.Windows.Forms.Button();
            this.dgAccountBrowser = new System.Windows.Forms.DataGridView();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPasswd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountBrowser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(23, 25);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(91, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "打开网页登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnAddAcount
            // 
            this.btnAddAcount.Location = new System.Drawing.Point(23, 54);
            this.btnAddAcount.Name = "btnAddAcount";
            this.btnAddAcount.Size = new System.Drawing.Size(91, 23);
            this.btnAddAcount.TabIndex = 1;
            this.btnAddAcount.Text = "添加账号";
            this.btnAddAcount.UseVisualStyleBackColor = true;
            this.btnAddAcount.Click += new System.EventHandler(this.btnAddAcount_Click);
            // 
            // btnDelAccount
            // 
            this.btnDelAccount.Location = new System.Drawing.Point(23, 112);
            this.btnDelAccount.Name = "btnDelAccount";
            this.btnDelAccount.Size = new System.Drawing.Size(91, 23);
            this.btnDelAccount.TabIndex = 3;
            this.btnDelAccount.Text = "删除账号";
            this.btnDelAccount.UseVisualStyleBackColor = true;
            this.btnDelAccount.Click += new System.EventHandler(this.btnDelAccount_Click);
            // 
            // btnChangeAccountInfo
            // 
            this.btnChangeAccountInfo.Location = new System.Drawing.Point(23, 83);
            this.btnChangeAccountInfo.Name = "btnChangeAccountInfo";
            this.btnChangeAccountInfo.Size = new System.Drawing.Size(91, 23);
            this.btnChangeAccountInfo.TabIndex = 4;
            this.btnChangeAccountInfo.Text = "修改账号信息";
            this.btnChangeAccountInfo.UseVisualStyleBackColor = true;
            this.btnChangeAccountInfo.Click += new System.EventHandler(this.btnChangeAccountInfo_Click);
            // 
            // dgAccountBrowser
            // 
            this.dgAccountBrowser.AllowUserToAddRows = false;
            this.dgAccountBrowser.AllowUserToDeleteRows = false;
            this.dgAccountBrowser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccountBrowser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccount,
            this.colPasswd,
            this.type});
            this.dgAccountBrowser.Location = new System.Drawing.Point(184, 25);
            this.dgAccountBrowser.MultiSelect = false;
            this.dgAccountBrowser.Name = "dgAccountBrowser";
            this.dgAccountBrowser.ReadOnly = true;
            this.dgAccountBrowser.RowHeadersVisible = false;
            this.dgAccountBrowser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgAccountBrowser.RowTemplate.Height = 23;
            this.dgAccountBrowser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAccountBrowser.Size = new System.Drawing.Size(761, 290);
            this.dgAccountBrowser.TabIndex = 5;
            // 
            // colAccount
            // 
            this.colAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAccount.HeaderText = "邮箱账号";
            this.colAccount.Name = "colAccount";
            this.colAccount.ReadOnly = true;
            // 
            // colPasswd
            // 
            this.colPasswd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPasswd.HeaderText = "密码";
            this.colPasswd.Name = "colPasswd";
            this.colPasswd.ReadOnly = true;
            // 
            // type
            // 
            this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.type.HeaderText = "邮箱类型";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // btnSaveInfo
            // 
            this.btnSaveInfo.Location = new System.Drawing.Point(23, 141);
            this.btnSaveInfo.Name = "btnSaveInfo";
            this.btnSaveInfo.Size = new System.Drawing.Size(91, 23);
            this.btnSaveInfo.TabIndex = 7;
            this.btnSaveInfo.Text = "保存信息";
            this.btnSaveInfo.UseVisualStyleBackColor = true;
            this.btnSaveInfo.Click += new System.EventHandler(this.btnSaveInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 651);
            this.Controls.Add(this.btnSaveInfo);
            this.Controls.Add(this.dgAccountBrowser);
            this.Controls.Add(this.btnChangeAccountInfo);
            this.Controls.Add(this.btnDelAccount);
            this.Controls.Add(this.btnAddAcount);
            this.Controls.Add(this.btnLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccountBrowser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnAddAcount;
        private System.Windows.Forms.Button btnDelAccount;
        private System.Windows.Forms.Button btnChangeAccountInfo;
        private System.Windows.Forms.DataGridView dgAccountBrowser;
        private System.Windows.Forms.Button btnSaveInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPasswd;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
    }
}

