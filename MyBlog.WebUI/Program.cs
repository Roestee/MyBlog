using Autofac;
using Autofac.Extensions.DependencyInjection;
using MyBlog.Business.DependencyResolvers.Autofac;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterModule(new AutofacBusinessModule()));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Db Context
builder.Services.AddDbContext<MyBlogDbContext>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}");

app.Run();
