using Microsoft.VisualBasic;
using static SayyehBanTools.Sender.SMS_System;

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
}
public class SendPattern : BaseModel
{    /// <summary>
     /// شماره ارسال کننده یعنی از چه شماری رار هستش ارسال بشه پیش فرض 983000505 هستش ولی باز عوض شد شماره دیگه بهش بدید
     /// </summary>
    public string FromNumber { get; set; } = "+983000505";
    /// <summary>
    /// این هم نام پترن کد هستش که قرار بر حسب کدام پترن ارسال انجام بشه.
    /// </summary>
    public string PatternCode { get; set; }
    /// <summary>
    /// این قسمت هم کسی که قرار هستش شماره دریافت کنه بهش بدید
    /// </summary>
    public string ToNumber { get; set; }
}
public class SendNormalSingleModel : BaseModel
{ 
    /// <summary>
     /// شماره ارسال کننده یعنی از چه شماری رار هستش ارسال بشه پیش فرض 983000505 هستش ولی باز عوض شد شماره دیگه بهش بدید
     /// </summary>
    public string FromNumber { get; set; } = "+983000505";
    /// <summary>
    /// این قسمت هم کسی که قرار هستش شماره دریافت کنه بهش پیام بدید به صورت آرایه
    /// </summary>
    public string[] ToNumber { get; set; }
    /// <summary>
    /// تعریف تاریخ و زمان ارسال که باید تاریخ و زمان ارسال به میلادی بدید
    /// </summary>
    public DateTime DateTimerSender { get; set; }
    /// <summary>
    /// متن ارسال پیامک
    /// </summary>
    public string Message { get; set; }
}
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

public class SendPeerToPeerRequest : BaseModel
{    /// <summary>
     ///  دریافت شماره مخاطب به صورت آرایه که به صورت ناهمزمان بهشون پیام ارسال بشه
     /// </summary>
    public List<List<string>> Recipients { get; set; }
    /// <summary>
    /// شماره ارسال کننده یعنی از چه شماری رار هستش ارسال بشه پیش فرض 983000505 هستش ولی باز عوض شد شماره دیگه بهش بدید
    /// </summary>
    public string FromNumber { get; set; } = "+983000505";
    /// <summary>
    /// ارسال متن به صورت ناهمزمان و آرایه برحسب شماره های ناهمزان که برحسب شماره ها متن پیام مختلف به هرکدام به چه صورت ارسال بشه
    /// </summary>
    public string[] Messages { get; set; }
}