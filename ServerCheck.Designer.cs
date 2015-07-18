using System.Windows.Forms;
namespace ServerCheck
{
    partial class ServerCheck
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mServerList = new System.Windows.Forms.GroupBox();
            this.CheckTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mServerList
            // 
            this.mServerList.Location = new System.Drawing.Point(12, 12);
            this.mServerList.Name = "mServerList";
            this.mServerList.Size = new System.Drawing.Size(812, 412);
            this.mServerList.TabIndex = 0;
            this.mServerList.TabStop = false;
            this.mServerList.Text = "服务器列表";
            // 
            // CheckTimer
            // 
            this.CheckTimer.Enabled = true;
            this.CheckTimer.Tick += new System.EventHandler(this.CheckTimer_Tick);
            // 
            // ServerCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 436);
            this.Controls.Add(this.mServerList);
            this.Name = "ServerCheck";
            this.Text = "服务器守护程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerCheck_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox mServerList;
        private Timer CheckTimer;

    }
}

