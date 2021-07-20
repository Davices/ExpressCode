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
  public interface IModuleElementRepository
  {
       List<ModuleElementEntity> ModuleElementShow();

       int ModuleLementDel(string ModuleElementId);

       int ModuleLementAdd(ModuleElementEntity me);
       int ModuleLementPut(ModuleElementEntity me);
    }
}
