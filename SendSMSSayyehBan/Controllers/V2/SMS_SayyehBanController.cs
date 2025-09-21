using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SendSMSSayyehBan.Service.Interface;
using static SendSMSSayyehBan.Model.ModelSMS2.VM_SMS;

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
        private readonly I_SMS _SMS;

        /// <summary>
        /// کلاس سازنده
        /// </summary>
        /// <param name="sms">سرویس SMS</param>
        public SMS_SayyehBanController(I_SMS sms)
        {
            _SMS = sms ?? throw new ArgumentNullException(nameof(sms));

        }
        /// <summary>
        /// دریافت موجودی پیامک
        /// </summary>
        /// <returns>اطلاعات اعتبارات</returns>
        [HttpGet]
        public async Task<IActionResult> GetCreditAsync([FromQuery] DefaultValueParameters request)
        {

            try
            {
                var jsonResult = await _SMS.GetCreditAsync(request);
                return new JsonResult(jsonResult);
            }
            catch 
            {
               
                return StatusCode(500);
            }
        }
    }
}
