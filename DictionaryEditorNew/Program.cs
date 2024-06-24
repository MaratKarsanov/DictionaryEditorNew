using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using DictionaryEditorDbNew;
using DictionaryEditorNew;
using DictionaryEditorDbNew.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("dictionary_json");


builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
builder.Services.AddTransient<DictionariesRepository>();
builder.Services.AddTransient<RussianWordsDbRepository>();
builder.Services.AddTransient<OssetianWordsDbRepository>();
builder.Services.AddTransient<ExamplesDbRepository>();
builder.Services.AddTransient<UserDbRepository>();
builder.Services.AddTransient<RoleDbRepository>();
builder.Services.AddTransient<RusWordsHashSet>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Loading}/{action=Index}/{id?}");

app.Run();
