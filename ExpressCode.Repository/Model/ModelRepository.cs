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
            string sql = "select CascadeId,Name from Module";
            return dBFactory.GetBaseRepository().Query<ModelEntity>(sql);           
            //ModelEntity model = new ModelEntity();
            //model.CascadeId = "12";
            //model.Name = "张三";
            //model.HotKey = "男";
            //return model;
        }
    }
}
