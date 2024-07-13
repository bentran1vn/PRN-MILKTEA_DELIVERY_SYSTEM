using BusinessObject;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Repositories.FeedBacks;
using Repositories.Orders;
using Repositories.OrderDetails;
using Repositories.Products;
using Repositories.SignalR;
using Repositories.UploadFileService;
using Repositories.Voucher;
using BusinessObject.Entities;
using Repositories.Users;


var builder = WebApplication.CreateBuilder(args);
var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
        options.LoginPath = "/Account/Login"; // Set the path to your login page
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnly", policy =>
        policy.RequireRole("1"));
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("2"));
    options.AddPolicy("ShipperOnly", policy =>
        policy.RequireRole("3"));
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MilkTeaDeliveryDBContext>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR(options =>
{
    // Setting the keep-alive interval (defaults to 15 seconds)
    options.KeepAliveInterval = TimeSpan.FromSeconds(10); // Customize as needed
    // Setting the client timeout (defaults to 30 seconds)
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(20); // Customize as needed
});

builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
builder.Services.AddScoped<IFeedBackRepository, FeedBackRepository>();
builder.Services.AddScoped <IImageUploadService, CloudinaryImageUploadService> ();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy(cookiePolicyOptions);
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endp =>
{
    endp.MapRazorPages();
    endp.MapHub<SignalrServer>("/signalrServer");
});

await app.RunAsync();
