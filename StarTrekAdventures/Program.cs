using StarTrekAdventures.Helpers;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Selectors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddTransient<StarTrekAdventures.Managers.Version1.ICharacterManager, StarTrekAdventures.Managers.Version1.CharacterManager>();
builder.Services.AddTransient<StarTrekAdventures.Managers.Version1.ISpeciesManager, StarTrekAdventures.Managers.Version1.SpeciesManager>();
builder.Services.AddTransient<StarTrekAdventures.Managers.Version1.ITechnobabbleManager, StarTrekAdventures.Managers.Version1.TechnobabbleManager>();

builder.Services.AddTransient<IAwardSelector, AwardSelector>();
builder.Services.AddTransient<ICareerEventSelector, CareerEventSelector>();
builder.Services.AddTransient<ICareerPathSelector, CareerPathSelector>();
builder.Services.AddTransient<IEnvironmentSelector, EnvironmentSelector>();
builder.Services.AddTransient<IExperienceSelector, ExperienceSelector>();
builder.Services.AddTransient<IMissionPodSelector, MissionPodSelector>();
builder.Services.AddTransient<IMissionProfileSelector, MissionProfileSelector>();
builder.Services.AddTransient<INpcSelector, NpcSelector>();
builder.Services.AddTransient<INpcSpecialRuleSelector, NpcSpecialRuleSelector>();
builder.Services.AddTransient<INpcStarshipSelector, NpcStarshipSelector>();
builder.Services.AddTransient<IRankSelector, RankSelector>();
builder.Services.AddTransient<IReprimandSelector, ReprimandSelector>();
builder.Services.AddTransient<IRoleSelector, RoleSelector>();
builder.Services.AddTransient<IServiceRecordSelector, ServiceRecordSelector>();
builder.Services.AddTransient<ISmallCraftSelector, SmallCraftSelector>();
builder.Services.AddTransient<ISpaceframeSelector, SpaceframeSelector>();
builder.Services.AddTransient<ISpeciesAbilitySelector, SpeciesAbilitySelector>();
builder.Services.AddTransient<ISpeciesSelector, SpeciesSelector>();
builder.Services.AddTransient<IStarshipSpecialRuleSelector, StarshipSpecialRuleSelector>();
builder.Services.AddTransient<IStarshipTalentSelector, StarshipTalentSelector>();
builder.Services.AddTransient<IStarshipWeaponSelector, StarshipWeaponSelector>();
builder.Services.AddTransient<ITalentSelector, TalentSelector>();
builder.Services.AddTransient<IUpbringingSelector, UpbringingSelector>();
builder.Services.AddTransient<IValueSelector, ValueSelector>();
builder.Services.AddTransient<IWeaponSelector, WeaponSelector>();

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

builder.Services.AddTransient<IRandomGenerator, MockRandomGenerator>();
builder.Services.AddTransient<IRandomGenerator, RandomGenerator>();

builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalBlazor", policy =>
        policy.WithOrigins("https://localhost:5001", "https://localhost:7186", "http://localhost:5042/") // your frontend ports
              .AllowAnyHeader()
              .AllowAnyMethod());
});

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
