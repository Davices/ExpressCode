using ExpressCode.Repository.Model;
using ExpressCode.Services.Admin.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressCode.Services.Admin.Model
{
    public class ModelService:BaseService,IModelService
    {
        public IModelRepository Repository { get; set; }
        public List<ModelGetOutput> GetModel()
        {
            var da = Repository.ModelShow();
            var entityDto = Mapper.Map<List<ModelGetOutput>>(da);
            return entityDto;
        }

        
    }
}
