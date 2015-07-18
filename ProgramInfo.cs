using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ServerCheck
{
    public class ProgramInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int nIndex;

        /// <summary>
        /// 名称
        /// </summary>
        public string sName;

        /// <summary>
        /// 路径
        /// </summary>
        public string sPath;

        /// <summary>
        /// 参数
        /// </summary>
        public string sParam;

        /// <summary>
        /// 进程
        /// </summary>
        public Process mProcess;

        /// <summary>
        /// 是否重启
        /// </summary>
        public bool mRestart;

        /// <summary>
        /// 工作目录
        /// </summary>
        public string sWorkDir;
    }
}
