using StarTrekAdventures.Managers;

var builder = WebApplication.CreateBuilder(args);

// --- Configure Services ---
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddTransient<StarTrekAdventures.Managers.Version1.ICharacterManager, StarTrekAdventures.Managers.Version1.CharacterManager>();
builder.Services.AddTransient<StarTrekAdventures.Managers.Version1.ISpeciesManager, StarTrekAdventures.Managers.Version1.SpeciesManager>();
builder.Services.AddTransient<StarTrekAdventures.Managers.Version1.ITechnobabbleManager, StarTrekAdventures.Managers.Version1.TechnobabbleManager>();

builder.Services.AddTransient<ICharacterManager, CharacterManager>();
builder.Services.AddTransient<IStarshipManager, StarshipManager>();

// Add MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// --- Configure Middleware ---
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();
app.UseAuthorization();

// Map routes (use conventional routing)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
