using Microsoft.AspNetCore.Mvc;
using SayyehBanTools.Sender;
using SendSMSSayyehBan.Model;
using System.Net;

namespace SendSMSSayyehBan.Controllers;

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
        var (response, responseContent) = await SMS_System.SendPatternAsync(sendPattern.APILink, sendPattern.APIKey, dicDataSMS, sendPattern.PatternCode, sendPattern.FromNumber, sendPattern.ToNumber);
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
    /// <summary>
    /// ارسال پیامک به صورت سینگل یا آرایه از شماره ها
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SendNormalSingle([FromForm] SendNormalSingleModel model)
    {
        if (model == null)
        {
            return BadRequest("Invalid request body");
        }

        var (response, responseContent) = await SMS_System.SendNormalSingleAsync(model.APILink,model.APIKey,model.FromNumber,model.ToNumber,model.Message,model.DateTimerSender);

        if (response != null)
        {
            return new ContentResult
            {
                Content = responseContent,
                ContentType = "application/json",
                StatusCode = (int)response.StatusCode
            };
        }
        else
        {
            return BadRequest("Error sending SMS: " + responseContent);
        }
    }    /// <summary>
    /// ارسال پیامک به صورت نا همزمان
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SendPeerToPeerAsync(SendPeerToPeerRequest model)
    {
        if (model == null)
        {
            return BadRequest("Invalid request body");
        }

        var (response, responseContent) = await SMS_System.SendPeerToPeerAsync(model.APILink,model.APIKey,model.Recipients,model.FromNumber,model.Messages);

        if (response != null)
        {
            return new ContentResult
            {
                Content = response,
                ContentType = "application/json",
            };
        }
        else
        {
            return BadRequest("Error sending SMS: " + responseContent);
        }
    }
    /// <summary>
    /// نمایش موجودی شارژ پانل
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetCredit([FromQuery] BaseModel model)
    {
        if (model == null)
        {
            return BadRequest("Invalid request body");
        }
        var (response, responseContent) = await SMS_System.GetCreditAsync(model.APILink, model.APIKey);

        if (response != null)
        {
            return new ContentResult
            {
                Content = response,
                ContentType = "application/json",
            };
        }
        else
        {
            return BadRequest("GetCredit: " + response);
        }
    }
    /// <summary>
    /// نمایش پیام های ارسال شده
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetSendList([FromQuery] GetSendListModel model)
    {
        if (model == null)
        {
            return BadRequest("Invalid request body");
        }
        var (response, responseContent) = await SMS_System.GetSendListAsync(model.APILink, model.APIKey,model.page,model.per_page);

        if (response != null)
        {
            return new ContentResult
            {
                Content = response,
                ContentType = "application/json",
            };
        }
        else
        {
            return BadRequest("GetCredit: " + response);
        }
    }
}
