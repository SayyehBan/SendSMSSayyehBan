using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Localization;
using SayehBanTools.Sender.Service.Interface;
using SayehBanTools.Sender.Service.Repository;
using SendSMSSayyehBan.Config;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// ثبت سرویس SMS بدون وابستگی - همه تنظیمات از درخواست می‌آید
builder.Services.AddScoped<I_SMS, R_SMS>();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
    options.RequestCultureProviders = new List<IRequestCultureProvider>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOurSwagger();

// تنظیم ورژن‌بندی API - سازگار با Asp.Versioning 8.1.0
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;

    // فقط از URL segment استفاده کن (بدون header یا query parameter)
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader()
    );
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // به‌صورت خودکار ورژن‌ها رو از IApiVersionDescriptionProvider بگیر
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                $"سایه بان الگو ارسال پیامک - {description.GroupName.ToUpperInvariant()}");
        }
        c.RoutePrefix = string.Empty;
        c.DocExpansion(DocExpansion.None);
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();