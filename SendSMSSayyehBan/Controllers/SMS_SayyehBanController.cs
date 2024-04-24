﻿using Microsoft.AspNetCore.Mvc;
using SayyehBanTools.Sender;
using Newtonsoft.Json;
using SendSMSSayyehBan.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Text;

namespace SendSMSSayyehBan.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SMS_SayyehBanController : ControllerBase
    {
        /// <summary>
        /// ارسال پیامک به صورت پترن
        /// </summary>
        /// <param name="sendPattern"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SendPattern([FromForm] SendPattern sendPattern)
        {

            Dictionary<string, object> dicDataSMS = new Dictionary<string, object>
            {
                ["DisposablePassword"] = "2583",
                ["Cemetery"] = "سایه بان",
            };
            var (response, responseContent) = await SendSmsPattern.SendPatternAsync(sendPattern.APILink, sendPattern.APIKey, dicDataSMS, sendPattern.PatternCode, sendPattern.FromNumber, sendPattern.ToNumber);
            if (response != null)
            {
                return new ContentResult
                {
                    Content = responseContent,
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            else
            {
                return NotFound(); // پیام خطا را انتقال دهید
            }
        }

    }
}