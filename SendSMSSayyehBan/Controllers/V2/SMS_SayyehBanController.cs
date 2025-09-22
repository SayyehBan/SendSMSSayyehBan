using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SayehBanTools.Sender.Service.Interface;
using static SayehBanTools.Model.Entities.VM_SMS;

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
        /// <summary>
        /// محاسبه هزینه پیامک
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Calculate_SMS_PriceAsync([FromQuery] Calculate_SMS_Price_Parameters model)
        {

            try
            {
                var jsonResult = await _SMS.Calculate_SMS_PriceAsync(model);
                return new JsonResult(jsonResult);
            }
            catch
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        /// ارسال پیامک از طریق WebService
        /// </summary>
        /// <param name="model">پارامترهای کامل ارسال</param>
        /// <returns>نتیجه ارسال</returns>
        [HttpPost]
        public async Task<IActionResult> SendWebserviceSMSAsync([FromBody] SendWebserviceSMSParameters model)
        {
            try
            {
                var jsonResult = await _SMS.SendWebserviceSMSAsync(model);
                return new JsonResult(jsonResult);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// ارسال پیامک توسط فایل
        /// </summary>
        /// <param name="model">پارامترهای ارسال فایل</param>
        /// <returns>نتیجه ارسال</returns>
        [HttpPost]
        public async Task<IActionResult> SendFileSMSAsync([FromForm] SendFileSMSParameters model)
        {
            try
            {
                var jsonResult = await _SMS.SendFileSMSAsync(model);
                return new JsonResult(jsonResult);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// ارسال پیامک توسط Keyword
        /// </summary>
        /// <param name="model">پارامترهای ارسال Keyword</param>
        /// <returns>نتیجه ارسال</returns>
        [HttpPost]
        public async Task<IActionResult> SendKeywordSMSAsync([FromForm] SendKeywordSMSParameters model)
        {
            try
            {
                var jsonResult = await _SMS.SendKeywordSMSAsync(model);
                return new JsonResult(jsonResult);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// ارسال پیامک از طریق Pattern
        /// </summary>
        /// <param name="model">پارامترهای کامل ارسال</param>
        /// <returns>نتیجه ارسال</returns>
        [HttpPost]
        public async Task<IActionResult> SendPatternSMSAsync([FromBody] SendPatternSMSParameters model)
        {
            try
            {
                var jsonResult = await _SMS.SendPatternSMSAsync(model);
                return new JsonResult(jsonResult);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// ارسال پیامک Peer to Peer
        /// </summary>
        /// <param name="model">پارامترهای ارسال Peer to Peer</param>
        /// <returns>نتیجه ارسال</returns>
        [HttpPost]
        public async Task<IActionResult> SendPeerToPeerSMSAsync([FromBody] SendPeerToPeerSMSParameters model)
        {
            try
            {
                var jsonResult = await _SMS.SendPeerToPeerSMSAsync(model);
                return new JsonResult(jsonResult);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// ارسال پیامک Peer to Peer File
        /// </summary>
        /// <param name="model">پارامترهای ارسال Peer to Peer</param>
        /// <returns>نتیجه ارسال</returns>
        [HttpPost]
        public async Task<IActionResult> SendPeertoPeerbyFileAsync([FromForm] SendPeertoPeerbyFileParameters model)
        {
            try
            {
                var jsonResult = await _SMS.SendPeertoPeerbyFile(model);
                return new JsonResult(jsonResult);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
