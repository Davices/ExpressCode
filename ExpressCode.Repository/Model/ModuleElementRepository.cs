using ExpressCode.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressCode.Common;
namespace ExpressCode.Repository.Model
{
    public class ModuleElementRepository : IModuleElementRepository
    {
        DBFactory dBFactory = new DBFactory();
        public List<ModuleElementEntity> ModuleElementShow()
        {
            string sql = "select * from ModuleElement";
            return dBFactory.GetBaseRepository().Query<ModuleElementEntity>(sql);
        }

        public int ModuleLementDel(string ModuleElementId)
        {
            string sql = $"delete from ModuleElement where Id=@Id";
            return dBFactory.GetBaseRepository().Execute(sql,new {@Id=ModuleElementId });
        }
    }
}
