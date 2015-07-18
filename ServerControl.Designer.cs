namespace ServerCheck
{
    partial class ServerControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CheckRestart = new System.Windows.Forms.CheckBox();
            this.StartServer = new System.Windows.Forms.Button();
            this.ServerPath = new System.Windows.Forms.TextBox();
            this.StartParam = new System.Windows.Forms.TextBox();
            this.ServerState = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerName = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mWorkPath = new System.Windows.Forms.TextBox();
            this.StopServer = new System.Windows.Forms.Button();
            this.ServerName.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckRestart
            // 
            this.CheckRestart.AutoSize = true;
            this.CheckRestart.Location = new System.Drawing.Point(23, 29);
            this.CheckRestart.Name = "CheckRestart";
            this.CheckRestart.Size = new System.Drawing.Size(132, 16);
            this.CheckRestart.TabIndex = 0;
            this.CheckRestart.Text = "是否自动重启服务器";
            this.CheckRestart.UseVisualStyleBackColor = true;
            this.CheckRestart.CheckedChanged += new System.EventHandler(this.CheckRestart_CheckedChanged);
            // 
            // StartServer
            // 
            this.StartServer.Location = new System.Drawing.Point(23, 51);
            this.StartServer.Name = "StartServer";
            this.StartServer.Size = new System.Drawing.Size(75, 23);
            this.StartServer.TabIndex = 1;
            this.StartServer.Text = "启动服务器";
            this.StartServer.UseVisualStyleBackColor = true;
            this.StartServer.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // ServerPath
            // 
            this.ServerPath.Location = new System.Drawing.Point(253, 24);
            this.ServerPath.Name = "ServerPath";
            this.ServerPath.Size = new System.Drawing.Size(421, 21);
            this.ServerPath.TabIndex = 2;
            // 
            // StartParam
            // 
            this.StartParam.Location = new System.Drawing.Point(253, 54);
            this.StartParam.Name = "StartParam";
            this.StartParam.Size = new System.Drawing.Size(421, 21);
            this.StartParam.TabIndex = 3;
            // 
            // ServerState
            // 
            this.ServerState.AutoSize = true;
            this.ServerState.ForeColor = System.Drawing.Color.Red;
            this.ServerState.Location = new System.Drawing.Point(716, 56);
            this.ServerState.Name = "ServerState";
            this.ServerState.Size = new System.Drawing.Size(65, 12);
            this.ServerState.TabIndex = 4;
            this.ServerState.Text = "服务器状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "服务器路径:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "启动参数:";
            // 
            // ServerName
            // 
            this.ServerName.Controls.Add(this.StopServer);
            this.ServerName.Controls.Add(this.mWorkPath);
            this.ServerName.Controls.Add(this.label1);
            this.ServerName.Controls.Add(this.CheckRestart);
            this.ServerName.Controls.Add(this.label3);
            this.ServerName.Controls.Add(this.StartServer);
            this.ServerName.Controls.Add(this.label2);
            this.ServerName.Controls.Add(this.ServerPath);
            this.ServerName.Controls.Add(this.ServerState);
            this.ServerName.Controls.Add(this.StartParam);
            this.ServerName.Location = new System.Drawing.Point(3, 3);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(798, 117);
            this.ServerName.TabIndex = 7;
            this.ServerName.TabStop = false;
            this.ServerName.Text = "服务器名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "工作目录:";
            // 
            // mWorkPath
            // 
            this.mWorkPath.Location = new System.Drawing.Point(253, 84);
            this.mWorkPath.Name = "mWorkPath";
            this.mWorkPath.Size = new System.Drawing.Size(421, 21);
            this.mWorkPath.TabIndex = 8;
            // 
            // StopServer
            // 
            this.StopServer.Location = new System.Drawing.Point(23, 81);
            this.StopServer.Name = "StopServer";
            this.StopServer.Size = new System.Drawing.Size(75, 23);
            this.StopServer.TabIndex = 9;
            this.StopServer.Text = "停止服务器";
            this.StopServer.UseVisualStyleBackColor = true;
            this.StopServer.Click += new System.EventHandler(this.StopServer_Click);
            // 
            // ServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ServerName);
            this.Name = "ServerControl";
            this.Size = new System.Drawing.Size(804, 128);
            this.ServerName.ResumeLayout(false);
            this.ServerName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckRestart;
        private System.Windows.Forms.Button StartServer;
        private System.Windows.Forms.TextBox ServerPath;
        private System.Windows.Forms.TextBox StartParam;
        private System.Windows.Forms.Label ServerState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox ServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mWorkPath;
        private System.Windows.Forms.Button StopServer;
    }
}
