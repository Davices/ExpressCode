using Autofac.Extras.DynamicProxy;
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
    [Intercept(typeof(AopTest))]
    public interface IModelService
    {
       List<ModelGetOutput> GetModel();
        int ModulePut(ModelPutInputPut me);
        int ModuleAdd(ModelPutInput me);
        int ModuleDel(string ModuleId);

    }
}
