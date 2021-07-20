using Autofac.Extras.DynamicProxy;
using ExpressCode.Services.Admin.ModuleElement.InPut;
using ExpressCode.Services.Admin.ModuleElement.OutPut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressCode.Services.Admin.ModuleElement
{
    [Intercept(typeof(AopTest))]
    public interface IModuleElementService
    {
        List<ModuleElementGetOutput> GetModuleElement();

        int ModuleLementDel(string ModuleElementId);
        int ModuleLementPut(ModuleElementPutInPutPut me);
        int ModuleLementAdd(ModuleElementPutInPut me);
    }
}
