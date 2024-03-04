using Microsoft.EntityFrameworkCore;
using TradeCompanyApp.Models;
using Microsoft.Extensions.DependencyInjection;
using TradeCompanyApp.Data;

namespace TradeCompanyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TradeCompanyAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TradeCompanyAppContext") ?? throw new InvalidOperationException("Connection string 'TradeCompanyAppContext' not found.")));

            //builder.Services.AddDbContext<CrmContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

            app.Run();
        }
    }
}