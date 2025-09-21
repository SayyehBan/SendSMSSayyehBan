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
        /// آدرس پایه API
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
}
