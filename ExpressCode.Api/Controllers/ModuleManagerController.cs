using ExpressCode.Services.Admin.Model;
using ExpressCode.Services.Admin.Model.Output;
using ExpressCode.Services.Admin.ModuleElement;
using ExpressCode.Services.Admin.ModuleElement.OutPut;
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
        private readonly IModuleElementService _moduleElementService;
        public ModuleManagerController(IModelService modelService, IModuleElementService moduleElementService)
        {
            _modelService = modelService;
            _moduleElementService = moduleElementService;
        }
        #region 功能模块显示
        /// <summary>
        /// 功能模块显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ModelShow()
        {
            List<ModelGetOutput> list = _modelService.GetModel();
            return Ok(new { 
                   code=200,
                   data=list,
                   msg="获取成功"
            });
        }

        #endregion

        #region 功能模块元素显示
        /// <summary>
        /// 功能模块元素显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ModuleElementShow(int pageIndex, int pageSize)
        {
            List<ModuleElementGetOutput> list = _moduleElementService.GetModuleElement();
            int count = list.Count;
            list = list.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
            return Ok(new
            {
                code = 200,
                data = list,
                count=count,
                msg = "获取成功"
            });
        }
        #endregion


        #region 模块递归树结点
        /// <summary>
        /// 递归树结点
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetModuleAll()
        {
            //查询所有数据
            List<ModelGetOutput> list = _modelService.GetModel();
            //查询第一级数据
            List<ModelGetOutput> list1 = list.Where(p => p.ParentId == null).ToList();


            List<Dictionary<string, object>> Getlist = new List<Dictionary<string, object>>();

            //循环获取字典值
            foreach (var item in list1)
            {
                Dictionary<string, object> json = new Dictionary<string, object>();
                json.Add("id", item.Id);
                json.Add("label", item.Name);
                //递归调用
                GetDictionary(list, json, item.Id);

                Getlist.Add(json);
            }

            return Ok(new
            {
                code = 200,
                data = Getlist
            });
        }
        private void GetDictionary(List<ModelGetOutput> list, Dictionary<string, object> json, string PId)
        {
            List<Dictionary<string, object>> Getlist = new List<Dictionary<string, object>>();
            //获取对应父级下的数据
            list = list.Where(p => p.ParentId == PId).ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    Dictionary<string, object> json1 = new Dictionary<string, object>();
                    json1.Add("id", item.Id);
                    json1.Add("label", item.Name);
                    //递归
                    GetDictionary(list, json1, item.Id);
                    Getlist.Add(json1);
                }
            }
            else
            {
                json.Add("children", null);
                return;
            }
            json.Add("children", Getlist);
        }
        #endregion

        /// <summary>
        /// 模板元素删除
        /// </summary>
        /// <param name="ModuleElementId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DelModuleElement(string ModuleElementId)
        {
            int IsDel = _moduleElementService.ModuleLementDel(ModuleElementId);
            return Ok(new
            {
                code = 200,
                data = IsDel,
                msg = "删除成功"
            }); ;
        }
    }
}
