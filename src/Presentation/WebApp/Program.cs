
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebApp;
using WebApp.Services;
using WebMVC.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions()
    .Configure<AppSettings>(builder.Configuration)
    .AddSession()
    .AddDistributedMemoryCache();

AddHttpClientServices(builder);

builder.Services.AddHealthChecks()
       .AddCheck("self", () => HealthCheckResult.Healthy());

// Add services to the container.
builder.Services.AddRazorPages();
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

app.UseAuthorization();

app.MapRazorPages();

app.MapHealthChecks("/liveness", new HealthCheckOptions
{
    Predicate = r => r.Name.Contains("self")
});
app.MapHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

await app.RunAsync();



// Adds all Http client services
static void AddHttpClientServices(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    //register delegating handlers
    //builder.Services.AddTransient<HttpClientAuthorizationDelegatingHandler>()
    //    .AddTransient<HttpClientRequestIdDelegatingHandler>();

    //set 5 min as the lifetime for each HttpMessageHandler int the pool
    builder.Services.AddHttpClient("extendedhandlerlifetime").SetHandlerLifetime(TimeSpan.FromMinutes(5));

    //add http client services
    builder.Services.AddHttpClient<IProductService, ProductService>();
            //.SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Sample. Default lifetime is 2 minutes
            //.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //.AddHttpMessageHandler<HttpClientRequestIdDelegatingHandler>();

}