using FacilityFeedback.Data.Models;
using FacilityFeedback.Repository.IRepository;
using FacilityFeedback.Repository.Repository;
using FacilityFeedback.Service.IServices;
using FacilityFeedback.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<FacilityFeedbackContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddScoped<IFloorRepository, FloorRepository>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();  
builder.Services.AddScoped<IRoomRepository, RoomRepository>();  
builder.Services.AddScoped<ITaskProcessRepository, TaskProcessRepository>();  
builder.Services.AddScoped<IDeviceTypeRepository, DeviceTypeRepository>();  
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();  
builder.Services.AddScoped<IProblemRepository, ProblemRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<IFloorService, FloorService>();  
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();  
builder.Services.AddScoped<IRoomService, RoomService>();  
builder.Services.AddScoped<ITaskProcessService, TaskProcessService>();  
builder.Services.AddScoped<IDeviceTypeService, DeviceTypeService>();  
builder.Services.AddScoped<IDeviceService, DeviceService>();  
builder.Services.AddScoped<IProblemService, ProblemService>();  
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.UseAuthMiddleware();

app.MapRazorPages();

app.Run();
