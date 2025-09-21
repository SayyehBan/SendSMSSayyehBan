using RestSharp;
using SendSMSSayyehBan.Service.Interface;
using System.Text.Json;
using static SendSMSSayyehBan.Model.ModelSMS2.VM_SMS;

namespace SendSMSSayyehBan.Service.Repository;

/// <summary>
/// ریپازیتوری پیامک - سورس کمکی
/// </summary>
public class R_SMS : I_SMS
{
    /// <summary>
    /// دریافت موجودی پیامک - فقط JSON اصلی
    /// </summary>
    /// <param name="model">تنظیمات API کامل از درخواست</param>
    /// <returns>لیست اطلاعات اعتبارات</returns>
    public async Task<object> GetCreditAsync(DefaultValueParameters model)
    {
        var options = new RestClientOptions(model.BaseUrl);
        var client = new RestClient(options);
        var request = new RestRequest(model.Api, Method.Get);
        request.AddHeader("Authorization", model.API_Key);

        RestResponse response = await client.ExecuteAsync(request);

        if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
        {
            var jsonDocument = JsonDocument.Parse(response.Content);
            var result = JsonSerializer.Deserialize<object>(jsonDocument.RootElement.GetRawText());

            // Null check اضافه شده
            return result ?? new { error = "خطا در deserialize اطلاعات" };
        }

        return new { error = "خطا در دریافت اطلاعات" };
    }
}