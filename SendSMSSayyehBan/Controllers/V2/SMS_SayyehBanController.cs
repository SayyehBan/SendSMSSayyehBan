using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SendSMSSayyehBan.Controllers.V2
{
    /// <summary>
    /// ارسال پیامک ورژن 2
    /// </summary>
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion=2}/[controller]/[action]")]
    [ApiController]
    public class SMS_SayyehBanController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is API v2");
        }
    }
}
