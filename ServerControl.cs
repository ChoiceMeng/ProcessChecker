using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerCheck
{
    public partial class ServerControl : UserControl
    {
        /// <summary>
        /// 进程信息
        /// </summary>
        private ProgramInfo info = null;

        /// <summary>
        /// 启动服务器的代理
        /// </summary>
        public delegate void Delegate_StartServer(ProgramInfo info);

        /// <summary>
        /// 启动服务器的回调
        /// </summary>
        private Delegate_StartServer mStartServer;

        /// <summary>
        /// 是否启动
        /// </summary>
        private bool bStart;

        public bool IsStart
        {
            get { return bStart; }
            set { bStart = value; }
        }

        public ServerControl()
        {
            InitializeComponent();
        }

        private void StartServer_Click(object sender, EventArgs e)
        {
            if (info == null || this.mStartServer == null)
                return;

            this.mStartServer(this.info);
        }

        /// <summary>
        /// 设置服务器启动状态
        /// </summary>
        /// <param name="bStart"></param>
        public void SetServerState(bool bStart)
        {
            this.IsStart = bStart;
            this.StartServer.Enabled = !bStart;
            this.StopServer.Enabled = bStart;
            this.ServerState.Text = bStart ? "服务器正常" : "服务器关闭";
        }

        /// <summary>
        /// 设置服务器信息
        /// </summary>
        public void SetServerInfo(ProgramInfo info, Delegate_StartServer StartServerCallBack)
        {
            this.info = info;
            this.mStartServer = StartServerCallBack;

            // 是否重启
            this.CheckRestart.Checked = this.info.mRestart;
            this.ServerPath.Text = this.info.sPath;
            this.StartParam.Text = this.info.sParam;
            this.ServerName.Text = this.info.sName;
            this.mWorkPath.Text = this.info.sWorkDir;
        }

        private void CheckRestart_CheckedChanged(object sender, EventArgs e)
        {
            if (this.info == null)
                return;

            this.info.mRestart = this.CheckRestart.Checked;
        }

        private void StopServer_Click(object sender, EventArgs e)
        {
            if (this.info == null || this.info.mProcess == null || this.info.mProcess.HasExited)
                return;

            DialogResult result = MessageBox.Show("确定要退出服务器吗？", "提示", MessageBoxButtons.OKCancel);
            if (result != DialogResult.OK)
                return;

            StopProcess();
        }

        public void StopProcess()
        {
            if (this.info.mProcess == null || this.info.mProcess.HasExited)
                return;

            this.info.mProcess.Kill();
            SetServerState(false);
        }
    }
}
