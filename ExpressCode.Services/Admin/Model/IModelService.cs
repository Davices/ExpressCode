using Autofac.Extras.DynamicProxy;
using ExpressCode.Services.Admin.Model.Output;
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
        ModelGetOutput GetUser();
    }
}
