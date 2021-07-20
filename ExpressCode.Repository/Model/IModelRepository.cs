using Autofac.Extras.DynamicProxy;
using ExpressCode.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressCode.Repository.Model
{
    [Intercept(typeof(AopTest))]
    public interface IModelRepository
    {
       List<ModelEntity> ModelShow();
        int ModulePut(ModelEntity me);
        int ModuleAdd(ModelEntity me);
        int ModuleDel(string ModuleId);

    }
}
