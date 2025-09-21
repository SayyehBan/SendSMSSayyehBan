using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SendSMSSayyehBan.Model.ModelSMS2;
/// <summary>
/// مدل پیامک
/// </summary>
public class VM_SMS
{
    /// <summary>
    /// مقادیر پیش فرض
    /// </summary>
    public class DefaultValueParameters
    {
        /// <summary>
        /// آدرس پایه https://edge.ippanel.com/v1 API
        /// </summary>
        public string BaseUrl { get; set; } = "https://edge.ippanel.com/v1";
        /// <summary>
        /// لینک API
        /// </summary>
        public string Api { get; set; } = string.Empty;
        /// <summary>
        /// کلید دسترسی
        /// </summary>
        public string API_Key { get; set; } = string.Empty;
    }
    /// <summary>
    /// محاسبه هزینه پیامک
    /// </summary>
    public class Calculate_SMS_Price_Parameters : DefaultValueParameters
    {
        /// <summary>
        /// شماره پیش فرض ارسال کننده پیام 983000505
        /// </summary>
        public string number { get; set; } = "983000505";
        /// <summary>
        /// متن پیام که عملیات محاسبه روش انجام میشه
        /// </summary>
        public string message { get; set; } = string.Empty;
    }
    /// <summary>
    /// وب سرویس پارامتر های ارسال
    /// </summary>
    public class SendWebserviceSMSParameters : DefaultValueParameters
    {
        /// <summary>
        /// نوع ارسال پیامک webservice
        /// </summary>
        [JsonPropertyName("sending_type")]
        public string SendingType { get; set; } = "webservice";

        /// <summary>
        /// ارسال از شماره ارسال کننده +983000505
        /// </summary>
        [JsonPropertyName("from_number")]
        public string FromNumber { get; set; } = "+983000505";

        /// <summary>
        /// متن پیام ارسال
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// زمان ارسال (فرمت: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [JsonPropertyName("send_time")]
        public DateTime SendTime { get; set; } = DateTime.Now.AddSeconds(30);

        /// <summary>
        /// پارامترهای JSON (داخلی - برای API)
        /// </summary>
        [JsonPropertyName("params")]
        public SMSParams Params { get; set; } = new();

        /// <summary>
        /// Constructor برای راحتی
        /// </summary>
        public SendWebserviceSMSParameters()
        {
            Params = new SMSParams();
        }

        /// <summary>
        ///  Helper method برای تنظیم Recipients
        /// </summary>
        /// <param name="recipients"></param>
        public void SetRecipients(List<string> recipients)
        {
            Params.Recipients = recipients ?? new List<string>();
        }
    }
    /// <summary>
    /// پارامتر گیرنده ها
    /// </summary>
    public class SMSParams
    {
        /// <summary>
        /// گیرندگان
        /// </summary>
        [JsonPropertyName("recipients")]
        public List<string> Recipients { get; set; } = new();
    }
    /// <summary>
    /// ارسال پیامک به صورت فایل
    /// </summary>
    public class SendFileSMSParameters : DefaultValueParameters
    {
        /// <summary>
        /// نوع ارسال پیامک file
        /// </summary>
        public string sending_type { get; set; } = "file";

        /// <summary>
        /// ارسال از شماره ارسال کننده +983000505
        /// </summary>
        [JsonPropertyName("from_number")]
        public string from_number { get; set; } = "+983000505";

        /// <summary>
        /// متن پیام ارسال
        /// </summary>
        public string message { get; set; } = string.Empty;

        /// <summary>
        /// فایل شماره ها
        /// </summary>
        public IFormFile[] files { get; set; } = null!;

        /// <summary>
        /// زمان ارسال (فرمت: yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public DateTime send_time { get; set; } = DateTime.Now.AddSeconds(30);
        /// <summary>
        /// ارسال پارامترهای پیامک
        /// </summary>
        public SendFileSMSParameters()
        {
            files = Array.Empty<IFormFile>();
        }
    }
}
