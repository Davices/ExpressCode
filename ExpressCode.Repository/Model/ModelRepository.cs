using ExpressCode.Common;
using ExpressCode.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressCode.Repository.Model
{
    public class ModelRepository:IModelRepository
    {
        DBFactory dBFactory = new DBFactory();

        public List<ModelEntity> ModelShow()
        {
            string sql = "select * from Module";
            return dBFactory.GetBaseRepository().Query<ModelEntity>(sql);           
        }
        /// <summary>
        /// 模块删除
        /// </summary>
        /// <param name="ModuleId"></param>
        /// <returns></returns>
        public int ModuleDel(string ModuleId)
        {
            string sql = $"delete from Module where Id=@Id";
            return dBFactory.GetBaseRepository().Execute(sql, new { @Id = ModuleId });
        }
        /// <summary>
        /// 模块添加
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public int ModuleAdd(ModelEntity me)
        {
            string sql = $"insert into Module values('{me.Id}' ,'','{me.Name}' ,'{me.Url}','' ,'{me.IsLeaf}','{me.IsAutoExpand}','{me.IconName}',{me.Status},'{me.ParentName}','','{me.SortNo}','{me.ParentId}','{me.Code}','{me.IsSys}')";
            return dBFactory.GetBaseRepository().Execute(sql);
        }
        /// <summary>
        /// 模块元素修改
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public int ModulePut(ModelEntity me)
        {
            string sql = $"update  Module set Name= '{me.Name}' ,Url='{me.Url}',IsLeaf='{me.IsLeaf}',IsAutoExpand='{me.IsAutoExpand}',IconName='{me.IconName}',Status='{me.Status}',ParentName='{me.ParentName}',SortNo='{me.SortNo}',ParentId='{me.ParentId}',Code='{me.Code}',IsSys='{me.IsSys}' where Id='{me.Id}'";
            return dBFactory.GetBaseRepository().Execute(sql);
        }
    }
}
