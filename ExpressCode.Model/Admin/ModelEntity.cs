using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressCode.Model.Admin
{
    public class ModelEntity:BaseEntity
    {
        public string CascadeId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string HotKey { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsAutoExpand { get; set; }
        public string IconName { get; set; }
        public int Status { get; set; }
        public string ParentName { get; set; }
        public string Vector { get; set; }
        public int SortNo { get; set; }
        public string ParentId { get; set; }
        public string Code { get; set; }
        public bool IsSys { get; set; }
        //--功能模块流水号	
        //--节点语义Id	
        //--功能模块名称	
        //--主页面URL	
        //--热键	
        //--是否叶子节点	
        //--是否自动展开	
        //--节点图标文件名称
        //--当前状态	
        //--父节点名称	
        //--矢量坐标	
        //--排序号	
        //--父节点流水号	
        //--	
        //--是否为系统模板
    }
}
