using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services;

namespace ConvertorAPI.Controllers
{
    
   
    public class HistoryController : Controller
    {
        private readonly IConvertService _convertService;
        public HistoryController(IConvertService convertService)
        {
            _convertService = convertService;
        }
        [HttpGet]
        [Route("history")]
        public IActionResult Index()
        {
            return Ok((_convertService.GetCurrencies(), _convertService.GetHistory()));
        }
        [HttpGet]
        [Route("returnjson")]
        public IActionResult GetJson()
        {
            return Ok(_convertService.ReturnRoot());
        }
        [HttpPost]
        [Route("newitem")]
        public IActionResult AddNew([FromBody]HistoryConvert model)
        {
            return Ok(_convertService.AddItemHistory(model));
        }

    }
}