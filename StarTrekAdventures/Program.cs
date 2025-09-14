using StarTrekAdventures.Managers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddTransient<StarTrekAdventures.Managers.Version1.ICharacterManager, StarTrekAdventures.Managers.Version1.CharacterManager>();
builder.Services.AddTransient<StarTrekAdventures.Managers.Version1.ISpeciesManager, StarTrekAdventures.Managers.Version1.SpeciesManager>();
builder.Services.AddTransient<StarTrekAdventures.Managers.Version1.ITechnobabbleManager, StarTrekAdventures.Managers.Version1.TechnobabbleManager>();

builder.Services.AddTransient<IAwardManager, AwardManager>();
builder.Services.AddTransient<ICareerEventManager, CareerEventManager>();
builder.Services.AddTransient<ICareerPathManager, CareerPathManager>();
builder.Services.AddTransient<ICharacterManager, CharacterManager>();
builder.Services.AddTransient<IEnvironmentManager, EnvironmentManager>();
builder.Services.AddTransient<IExperienceManager, ExperienceManager>();
builder.Services.AddTransient<IMissionProfileManager, MissionProfileManager>();
builder.Services.AddTransient<INpcManager, NpcManager>();
builder.Services.AddTransient<INpcStarshipManager, NpcStarshipManager>();
builder.Services.AddTransient<IRankManager, RankManager>();
builder.Services.AddTransient<IReprimandManager, ReprimandManager>();
builder.Services.AddTransient<IRoleManager, RoleManager>();
builder.Services.AddTransient<IServiceRecordManager, ServiceRecordManager>();
builder.Services.AddTransient<ISmallCraftManager, SmallCraftManager>();
builder.Services.AddTransient<ISpaceframeManager, SpaceframeManager>();
builder.Services.AddTransient<ISpeciesManager, SpeciesManager>();
builder.Services.AddTransient<IStarshipManager, StarshipManager>();
builder.Services.AddTransient<IStarshipTalentManager, StarshipTalentManager>();
builder.Services.AddTransient<IStarshipWeaponManager, StarshipWeaponManager>();
builder.Services.AddTransient<ITalentManager, TalentManager>();
builder.Services.AddTransient<IUpbringingManager, UpbringingManager>();
builder.Services.AddTransient<IValueManager, ValueManager>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
