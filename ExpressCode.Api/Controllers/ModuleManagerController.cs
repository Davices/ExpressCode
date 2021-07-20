using ExpressCode.Services.Admin.Model;
using ExpressCode.Services.Admin.Model.Input;
using ExpressCode.Services.Admin.Model.Output;
using ExpressCode.Services.Admin.ModuleElement;
using ExpressCode.Services.Admin.ModuleElement.InPut;
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
        #region 功能模块 CRUD
        /// <summary>
        /// 功能模块显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ModelShow()
        {
            List<Dictionary<string, object>> Getlist = new List<Dictionary<string, object>>();
            List<ModelGetOutput> list = _modelService.GetModel();
            //查询第一级数据
            List<ModelGetOutput> list1 = list.Where(p => p.ParentId == null).ToList();

            //循环获取字典值
            foreach (var item in list1)
            {
                Dictionary<string, object> json = new Dictionary<string, object>();
                json.Add("id", item.Id);
                json.Add("label", item.Name);
                //递归调用
                GetDictionary22(list, json, item.Id);

                Getlist.Add(json);
            }
            return Ok(new { 
                   code=200,
                   data= Getlist,
                   msg="获取成功"
            });
        }
        //递归调用，获取树节点的值
        private void GetDictionary22(List<ModelGetOutput> list, Dictionary<string, object> json, string PId)
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
        /// <summary>
        /// 模板删除
        /// </summary>
        /// <param name="ModuleId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DelModule(string ModuleId)
        {
            int IsDel = _modelService.ModuleDel(ModuleId);
            return Ok(new
            {
                code = 200,
                data = IsDel,
                msg = "删除成功"
            }); 
        }
       
        /// <summary>
        /// 模板添加
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddModule(ModelPutInput me)
        {
            int IsAdd = _modelService.ModuleAdd(me);
            return Ok(new
            {
                code = 200,
                data = IsAdd,
                msg = "添加成功"
            }); 
        }
        /// <summary>
        /// 模块修改
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutModule(ModelPutInputPut me)
        {
            int Isput = _modelService.ModulePut(me);
            return Ok(new
            {
                code = 200,
                data = Isput,
                msg = "修改成功"
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

            List<Dictionary<string, object>> Getlist = new List<Dictionary<string, object>>();
            //查询所有数据
            List<ModelGetOutput> list = _modelService.GetModel();
            

            //循环获取字典值
            foreach (var item in list)
            {
                Dictionary<string, object> json = new Dictionary<string, object>();
                json.Add("Id", item.Id);
                json.Add("Name", item.Name);
                json.Add("Code", item.Code);
                json.Add("Url", item.Url);
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
        [HttpPost]
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
                    json1.Add("Id", item.Id);
                    json1.Add("Name", item.Name);
                    json1.Add("Code", item.Code);
                    json1.Add("Url", item.Url);
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

        
        #region 功能模块元素 CRUD
        /// <summary>
        /// 功能模块元素显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ModuleElementShow(int pageIndex, int pageSize,string name=null)
        {
            List<ModuleElementGetOutput> list = _moduleElementService.GetModuleElement();
            int count = list.Count;
            if (name!=null)
            {
                list = list.Where(p=>p.Name.Contains(name)).ToList();
            }
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return Ok(new
            {
                code = 200,
                data = list,
                count = count,
                msg = "获取成功"
            });
        }
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
            }); 
        }
        /// <summary>
        /// 模板元素添加
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddModuleElement(ModuleElementPutInPut me)
        {
            int IsAdd = _moduleElementService.ModuleLementAdd(me);
            return Ok(new
            {
                code = 200,
                data = IsAdd,
                msg = "添加成功"
            }); 
        }
        /// <summary>
        /// 模块元素修改
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutModuleElement(ModuleElementPutInPutPut me)
        {
            int Isput = _moduleElementService.ModuleLementPut(me);
            return Ok(new
            {
                code = 200,
                data = Isput,
                msg = "修改成功"
            }); 
        }
        #endregion
    }
}
