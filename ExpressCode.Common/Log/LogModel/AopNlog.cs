using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressCode.Common
{
    /// <summary>
    /// Aop日志表
    /// </summary>
    public class AopNlog
    {
        public string MethodName { get; set; }      //方法名
        public string ReturnType { get; set; }      //返回类型
        public string ReturnUrl { get; set; }       //返回路径
        public string ReturnResult { get; set; }    //返回结果 
        public DateTime ReturnTime { get; set; }    //返回时间
    }
}
