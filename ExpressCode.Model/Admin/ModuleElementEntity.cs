using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressCode.Model.Admin
{
    public class ModuleElementEntity:BaseEntity
    {
        public string DomId	 { get; set; }
        public string Name	 { get; set; }
        public string Attr	 { get; set; }
        public string Script	 { get; set; }
        public string Icon	 { get; set; }
        public string Class	 { get; set; }
        public string Remark	 { get; set; }
        public int Sort	 { get; set; }
        public string ModuleId { get; set; }
        public string TypeName { get; set; }
        public string TypeId { get; set; }	
        //--DOM ID	
        //--名称	
        //--元素附加属性
        //--元素调用脚本
        //--元素图标	
        //--元素样式	
        //--备注	
        //--排序字段	
        //--功能模块Id	
        //--分类名称	
        //--分类Id
    }
}
