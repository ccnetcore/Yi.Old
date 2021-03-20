using CC.Yi.IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private IstudentBll _studentBll;
        public StudentController(ILogger<StudentController> logger, IstudentBll studentBll)
        {
            _studentBll = studentBll;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Test()
        {
            var data = _studentBll.GetAllEntities().ToList();
            return Content(Common.JsonFactory.JsonToString(data));
        }
    }
}
