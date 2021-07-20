using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressCode.Model;
using ExpressCode.Model.Admin;
using ExpressCode.Services.Admin.Model.Output;
using ExpressCode.Services.Admin.Model.Input;

namespace ExpressCode.Services.Admin.Model
{
    public class _MapConfigM: Profile
    {
        public _MapConfigM()
        {
            //查询
            CreateMap<ModelEntity, ModelGetOutput>();

            //添加
            CreateMap<ModelPutInput,ModelEntity>();
            //修改
            CreateMap<ModelPutInputPut,ModelEntity>();
        }
    }
}
