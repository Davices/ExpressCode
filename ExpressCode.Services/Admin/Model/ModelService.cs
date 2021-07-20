using ExpressCode.Model.Admin;
using ExpressCode.Repository.Model;
using ExpressCode.Services.Admin.Model.Input;
using ExpressCode.Services.Admin.Model.Output;
using ExpressCode.Services.Admin.ModuleElement.InPut;
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

        public int ModuleAdd(ModelPutInput me)
        {
            var entityDto = Mapper.Map<ModelEntity>(me);
            var da = Repository.ModuleAdd(entityDto);
            return da;
        }

        public int ModuleDel(string ModuleId)
        {
            var da = Repository.ModuleDel(ModuleId);

            return da;
        }

        public int ModulePut(ModelPutInputPut me)
        {
            var entityDto = Mapper.Map<ModelEntity>(me);
            var da = Repository.ModulePut(entityDto);
            return da;
        }


    }
}
