using static SendSMSSayyehBan.Model.ModelSMS2.VM_SMS;

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
}