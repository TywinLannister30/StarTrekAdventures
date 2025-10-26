using StarTrekAdventures.FrontEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<StarTrekApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:44389"); // backend port
});

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

app.MapBlazorHub();

app.MapGet("/", context =>
{
    context.Response.Redirect("/main");
    return Task.CompletedTask;
});

app.MapFallbackToPage("/_Host");

app.Run();
