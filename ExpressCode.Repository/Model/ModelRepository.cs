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
    }
}
