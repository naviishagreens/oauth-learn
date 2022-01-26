using AuthorizationServer.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHostedService<TestData>();

// Add authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/account/login";
    });

builder.Services.AddDbContext<DbContext>(context =>
{
    context.UseInMemoryDatabase(nameof(DbContext));
    context.UseOpenIddict();
});

builder.Services.AddOpenIddict()
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore()
        .UseDbContext<DbContext>();
    })
    .AddServer(options =>
    {
        options.AllowAuthorizationCodeFlow().RequireProofKeyForCodeExchange();
        //options.AllowClientCredentialsFlow();
        options.SetTokenEndpointUris("/connect/token");

        options.AddEphemeralEncryptionKey()
        .AddEphemeralSigningKey()
        .DisableAccessTokenEncryption();  // should be able to decode token in jwt.io

        options.RegisterScopes("api");

        options.UseAspNetCore()
        .EnableTokenEndpointPassthrough()
        .EnableAuthorizationEndpointPassthrough();

    });
    //.AddServer();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints => {
    endpoints.MapDefaultControllerRoute();
});

app.Run();
