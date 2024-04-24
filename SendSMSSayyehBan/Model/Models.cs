namespace SendSMSSayyehBan.Model;

public class BaseModel
{
    /// <summary>
    /// این قسمت اختیاری هستش اگر نیاز به بروزرسانی باشه
    /// درون package
    /// https://www.nuget.org/packages/SayyehBanTools
    /// بروز میشه اگر نشد باز شما آدرس جدید ارسال با API
    /// قرار میدید تا کارتون پیش بره
    /// </summary>
    public string? APILink { get; set; }
    /// <summary>
    /// این قسمت 
    /// APIKey
    /// هستش که از سامانه دریافت میکنید من به صورت 
    /// Header
    /// در نیاوردم چون قرار نیست سامانه پیامکی بنویسید بلکه قرار هستش به کاربران خودبون از درون سورس هامون ارسال پیامک انجام بدیم
    /// </summary>
    public string APIKey { get; set; }
    /// <summary>
    /// شماره ارسال کننده یعنی از چه شماری رار هستش ارسال بشه پیش فرض 983000505هستش ولی باز عوض شد شماره دیگه بهش بدید
    /// </summary>
    public string FromNumber { get; set; } = "+983000505";
    /// <summary>
    /// این قسمت هم کسی که قرار هستش شماره دریافت کنه بهش بدید
    /// </summary>
    public string ToNumber { get; set; }
   
}
public class SendPattern : BaseModel
{
    /// <summary>
    /// این هم نام پترن کد هستش که قرار بر حسب کدام پترن ارسال انجام بشه.
    /// </summary>
    public string PatternCode { get; set; }
}
public class ResponseModel
{
    public string status { get; set; }
    public int code { get; set; }
    public string error_message { get; set; }
    public DataModel data { get; set; }
}

public class DataModel
{
    public int message_id { get; set; }
}
