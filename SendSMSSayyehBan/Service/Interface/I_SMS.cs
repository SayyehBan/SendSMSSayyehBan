﻿using static SendSMSSayyehBan.Model.ModelSMS2.VM_SMS;


namespace SendSMSSayyehBan.Service.Interface;

/// <summary>
/// اینترفیس پیامک
/// </summary>
public interface I_SMS
{
    /// <summary>
    /// دریافت موجودی پیامک
    /// </summary>
    /// <param name="model">تنظیمات API</param>
    /// <returns>لیست اطلاعات اعتبارات به صورت string</returns>
    Task<object> GetCreditAsync(DefaultValueParameters model);
    /// <summary>
    /// محاسبه هزینه پیامک
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<object> Calculate_SMS_PriceAsync(Calculate_SMS_Price_Parameters model);
    /// <summary>
    /// ارسال پیامک به صورت وب سرویس
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<object> SendWebserviceSMSAsync(SendWebserviceSMSParameters model);
    /// <summary>
    /// ارسال پیامک توسط فایل
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<object> SendFileSMSAsync(SendFileSMSParameters model);
    /// <summary>
    /// ارسال پیامک توسط Keyword
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<object> SendKeywordSMSAsync(SendKeywordSMSParameters model);
    /// <summary>
    /// ارسال پیامک پترن
    /// </summary>
    /// <param name="model">پارامترهای ارسال پترن</param>
    /// <returns>نتیجه ارسال</returns>
    Task<object> SendPatternSMSAsync(SendPatternSMSParameters model);
}