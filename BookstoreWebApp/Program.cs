using AutoMapper;
using BookstoreSdk.Clients;
using BookstoreSdk.Clients.Interface;
using BookstoreWebApp.MappingProfiles;
using BookstoreSdk.Services.Interfaces;
using BookstoreSdk.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IUserClient, UserClient>();
builder.Services.AddScoped<IBookClient, BookClient>();

// USE THE LINK THAT YOUR VISUAL STUDIO WILL PRODUCE LOCALLY FOR YOUR API
// FOR MY CASE IT WAS THIS - https://localhost:44388 OR IF YOU RUN THE API FROM DOCKER BUT
// THE WEB APP FROM LOCAL USE THIS LINK INSTEAD http://localhost:8080
builder.Services.AddScoped<IClientBookService>(provider => new ClientBookService("http://bookstoreapi:80"));
builder.Services.AddScoped<IClientUserService>(provider => new ClientUserService("http://bookstoreapi:80"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();