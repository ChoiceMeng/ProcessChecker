using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace ServerCheck
{
    public partial class ServerCheck : Form
    {
        /// <summary>
        /// 检测的程序列表
        /// </summary>
        private List<ProgramInfo> m_ProgramList = new List<ProgramInfo>();

        /// <summary>
        /// 所有空间列表
        /// </summary>
        private List<ServerControl> m_ControlList = new List<ServerControl>();

        public ServerCheck()
        {
            InitializeComponent();

            LoadXml("Config\\Servers.xml");

            CreateTop();
        }

        /// <summary>
        /// 创建顶部
        /// </summary>
        protected void CreateTop()
        {
            int nIndex = 0;
            foreach (ProgramInfo mInfo in m_ProgramList)
            {
                ServerControl mControl = new ServerControl();
                mControl.SetServerInfo(mInfo, StartServer);
                mControl.SetServerState(false);
                mControl.Top = nIndex * (mControl.Bottom - mControl.Top);
                mControl.Left = (this.mServerList.Width - mControl.Width) / 2;
                this.mServerList.Controls.Add(mControl);

                m_ControlList.Add(mControl);

                ++nIndex;
            }
        }

        /// <summary>
        /// 启动进程的回调
        /// </summary>
        /// <param name="info"></param>
        protected void StartServer(ProgramInfo info)
        {
            try
            {
                ProcessStartInfo mStartInfo = new ProcessStartInfo(info.sPath, info.sParam);
                mStartInfo.WorkingDirectory = info.sWorkDir;
                info.mProcess = Process.Start(mStartInfo);
                this.m_ControlList[info.nIndex].SetServerState(true);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 读取XML配置文件
        /// </summary>
        /// <param name="strPath"></param>
        protected void LoadXml(string strPath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strPath);

                XmlNode rootNode = xmlDoc.GetElementsByTagName("Root")[0];
                if (rootNode == null)
                    return;
                for (int nIndex = 0; nIndex < rootNode.ChildNodes.Count; ++nIndex )
                {
                    XmlNode mProgram = rootNode.ChildNodes[nIndex];
                    if(mProgram == null)
                        continue;

                    ProgramInfo mInfo = new ProgramInfo();

                    for (int nCnt = 0; nCnt < mProgram.ChildNodes.Count; ++nCnt )
                    {
                        XmlNode mElement = mProgram.ChildNodes[nCnt];
                        if(mElement == null)
                            continue;

                        switch (mElement.Name)
                        {
                            case "Index":
                                mInfo.nIndex = int.Parse(mElement.InnerText);
                                break;
                            case "Name":
                                mInfo.sName = mElement.InnerText;
                                break;
                            case "Path":
                                mInfo.sPath = mElement.InnerText;
                                break;
                            case "Param":
                                mInfo.sParam = mElement.InnerText;
                                break;
                            case "Restart":
                                mInfo.mRestart = bool.Parse(mElement.InnerText);
                                break;
                            case "WorkDir":
                                mInfo.sWorkDir = mElement.InnerText;
                                break;
                        }
                    }

                    if (!Directory.Exists(mInfo.sWorkDir))
                    {
                        if (Directory.Exists(mInfo.sPath))
                            mInfo.sWorkDir = mInfo.sPath;
                        else if (File.Exists(mInfo.sPath))
                        {
                            int nFindPos = mInfo.sPath.LastIndexOf('\\');
                            if (nFindPos == -1)
                                nFindPos = mInfo.sPath.LastIndexOf('/');

                            if (nFindPos >= 0)
                            {
                                mInfo.sWorkDir = mInfo.sPath.Substring(0, nFindPos);
                            }
                        }
                    }

                    this.m_ProgramList.Add(mInfo);
                    this.m_ProgramList = this.m_ProgramList.OrderBy(s => s.nIndex).ToList<ProgramInfo>();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 检测服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            foreach (ProgramInfo mInfo in m_ProgramList)
            {
                if (mInfo.mProcess == null || mInfo.mProcess.HasExited)
                {
                    if (this.m_ControlList[mInfo.nIndex].IsStart)
                        this.m_ControlList[mInfo.nIndex].SetServerState(false);

                    if (mInfo.mRestart)
                        StartServer(mInfo);
                }
            }
        }

        /// <summary>
        /// 是否服务器正在运行
        /// </summary>
        /// <returns></returns>
        private bool IsServerRuning()
        {
            foreach (ProgramInfo mInfo in m_ProgramList)
            {
                if (mInfo.mProcess == null || mInfo.mProcess.HasExited)
                    continue;

                return true;
            }
            return false;
        }

        private void StopAllServer()
        {
            foreach (ServerControl mControl in this.m_ControlList)
            {
                mControl.StopProcess();
            }
        }

        private void WaitProcessQuit()
        {
            foreach (ProgramInfo mInfo in m_ProgramList)
            {
                if (mInfo.mProcess == null || mInfo.mProcess.HasExited)
                    continue;

                mInfo.mProcess.WaitForExit();
            }
        }

        private void ServerCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsServerRuning())
                return;

            DialogResult result = MessageBox.Show("有服务器在运行，关闭窗口将关闭这些服务器，确定要关闭窗口？", "提示", MessageBoxButtons.OKCancel);
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            StopAllServer();
            // 等待退出
            WaitProcessQuit();
        }
    }
}
