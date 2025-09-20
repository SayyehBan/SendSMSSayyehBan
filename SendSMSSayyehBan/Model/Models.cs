using Microsoft.VisualBasic;
using static SayehBanTools.Sender.SMS_System;

namespace SendSMSSayyehBan.Model;
/// <summary>
/// اطلاعات پایه
/// </summary>
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
    public string APIKey { get; set; } = string.Empty;
}
/// <summary>
/// ارسال پترن
/// </summary>
public class SendPattern : BaseModel
{    /// <summary>
     /// شماره ارسال کننده یعنی از چه شماری رار هستش ارسال بشه پیش فرض 983000505 هستش ولی باز عوض شد شماره دیگه بهش بدید
     /// </summary>
    public string FromNumber { get; set; } = "+983000505";
    /// <summary>
    /// این هم نام پترن کد هستش که قرار بر حسب کدام پترن ارسال انجام بشه.
    /// </summary>
    public string PatternCode { get; set; } = string.Empty;
    /// <summary>
    /// این قسمت هم کسی که قرار هستش شماره دریافت کنه بهش بدید
    /// </summary>
    public string ToNumber { get; set; } = string.Empty;
    /// <summary>
    /// تعریف تاریخ و زمان ارسال که باید تاریخ و زمان ارسال به میلادی بدید
    /// اگر تاریخ و زمان به میلادی پیش فرض ندید سیستم به صورت پیش تاریخ و زمان جاری ست میکنه ولی برحسب Utceثبت میشه تا ارسال انجام بشه
    /// </summary>
    public DateTime? DateTimerSender { get; set; }
}
/// <summary>
/// ارسال معمولی تک
/// </summary>
public class SendNormalSingleModel : BaseModel
{
    /// <summary>
    /// شماره ارسال کننده یعنی از چه شماری رار هستش ارسال بشه پیش فرض 983000505 هستش ولی باز عوض شد شماره دیگه بهش بدید
    /// </summary>
    public string FromNumber { get; set; } = "+983000505";
    /// <summary>
    /// این قسمت هم کسی که قرار هستش شماره دریافت کنه بهش پیام بدید به صورت آرایه
    /// </summary>
    public string[] ToNumber { get; set; } = [];
    /// <summary>
    /// تعریف تاریخ و زمان ارسال که باید تاریخ و زمان ارسال به میلادی بدید
    /// اگر تاریخ و زمان به میلادی پیش فرض ندید سیستم به صورت پیش تاریخ و زمان جاری ست میکنه ولی برحسب Utceثبت میشه تا ارسال انجام بشه
    /// </summary>
    public DateTime? DateTimerSender { get; set; }
    /// <summary>
    /// متن ارسال پیامک
    /// </summary>
    public string Message { get; set; } = string.Empty;
}
/// <summary>
/// ارسال معمولی به صورت فایل
/// </summary>
public class SendNormalFileModel : BaseModel
{
    /// <summary>
    /// شماره ارسال کننده یعنی از چه شماری رار هستش ارسال بشه پیش فرض 983000505 هستش ولی باز عوض شد شماره دیگه بهش بدید
    /// </summary>
    public string Sender { get; set; } = "+983000505";
    /// <summary>
    /// این قسمت هم کسی که قرار هستش شماره دریافت کنه بهش پیام بدید به صورت آرایه
    /// </summary>
    public IFormFile To { get; set; } = null!;
    /// <summary>
    /// متن ارسال پیامک
    /// </summary>
    public string Message { get; set; } = string.Empty;
}
/// <summary>
/// دریافت لیست مدل
/// </summary>
public class GetSendListModel : BaseModel
{
    /// <summary>
    /// دریافت شماره صفحه جاری
    /// </summary>
    public int page { get; set; } = 1;
    /// <summary>
    /// نمایش تعداد صفحه مورد نظر
    /// </summary>
    public int per_page { get; set; } = 10;
}
/// <summary>
/// ارسال نظر به نظیر
/// </summary>
public class SendPeerToPeerRequest : BaseModel
{    /// <summary>
     ///  دریافت شماره مخاطب به صورت آرایه که به صورت همزمان بهشون پیام ارسال بشه
     /// </summary>
    public List<List<string>> Recipients { get; set; } = new List<List<string>>();
    /// <summary>
    /// شماره ارسال کننده یعنی از چه شماری رار هستش ارسال بشه پیش فرض 983000505 هستش ولی باز عوض شد شماره دیگه بهش بدید
    /// </summary>
    public string FromNumber { get; set; } = "+983000505";
    /// <summary>
    /// ارسال متن به صورت همزمان و آرایه برحسب شماره های همزمان که برحسب شماره ها متن پیام مختلف به هرکدام به چه صورت ارسال بشه
    /// </summary>
    public string[] Messages { get; set; } = [];
}
/// <summary>
/// ارسال نظر به نظیر
/// </summary>
public class SendPeerToPeerFileRequest : BaseModel
{    /// <summary>
     /// شماره ارسال کننده یعنی از چه شماری رار هستش ارسال بشه پیش فرض 983000505 هستش ولی باز عوض شد شماره دیگه بهش بدید
     /// </summary>
    public string FromNumber { get; set; } = "+983000505";
    /// <summary>
    /// ارسال فایل اکسل برای ارسال همزمان
    /// </summary>
    public IFormFile File { get; set; } = null!;
}