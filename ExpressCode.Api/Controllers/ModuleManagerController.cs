using ExpressCode.Services.Admin.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressCode.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModuleManagerController : ControllerBase
    {
        //构造函数注入
        private readonly IModelService _modelService;
        public ModuleManagerController(IModelService modelService)
        {
            _modelService = modelService;
        }
        [HttpGet]
        public IActionResult Show()
        {
            return Ok(_modelService.GetUser());
        }
    }
}
