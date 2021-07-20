using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressCode.Model;
using ExpressCode.Model.Admin;
using ExpressCode.Services.Admin.Model.Output;
using ExpressCode.Services.Admin.ModuleElement.OutPut;
using ExpressCode.Services.Admin.ModuleElement.InPut;

namespace ExpressCode.Services.Admin.ModuleElement
{
    public class _MapConfigME: Profile
    {
        public _MapConfigME()
        {
            //查询
            CreateMap<ModuleElementEntity, ModuleElementGetOutput>();

            //添加
           CreateMap <ModuleElementPutInPut, ModuleElementEntity> ();

            //修改
            CreateMap<ModuleElementPutInPutPut, ModuleElementEntity>();
        }
    }
}
