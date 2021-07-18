using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressCode.Model;
using ExpressCode.Model.Admin;
using ExpressCode.Services.Admin.Model.Output;

namespace ExpressCode.Services.Admin.User
{
    public class _MapConfigM: Profile
    {
        public _MapConfigM()
        {
            //查询
            CreateMap<ModelEntity, ModelGetOutput>();

            //添加
            //CreateMap<, UserEntity>();

        }
    }
}
