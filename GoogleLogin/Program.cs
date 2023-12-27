using GoogleLogin.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<YouTubeApiClient>(client => 
{
    client.BaseAddress = new Uri("https://www.googleapis.com/youtube/v3/");

});
builder.Services.AddAuthentication(options =>
{
    //GoogleDefaults.AuthenticationScheme google �n kimlik dogrulama  sevisi 
    // scheme kimlik do�rulama ve yetkilendirme s�re�lerini belirten, yap�land�ran ve y�neten bir kavramd�r
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; //DefaultScheme uygulama kullan�c�s�n�n kimlik bilgilerini depolamak i�in kullan�lacak varsay�lan �emay� belirtio
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme; //DefaultChallengeScheme kullan�c�y� do�rulama gerekirse y�nlendirece�iniz �emay� belirtiyo
}).AddCookie().AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
{
    options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
    options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
});
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
