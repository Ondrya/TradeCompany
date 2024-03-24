using DataServiceWCF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TradeCompanyApp.DataClients;
using TradeCompanyApp.Domain.Interfaces;
using TradeCompanyApp.RepositoryEF;

namespace TradeCompanyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var cn = builder.Configuration.GetConnectionString("TradeCompanyAppContext");


            //builder.Services.AddSingleton<IDataService>(new DataService(cn));
            builder.Services.AddSingleton(new DataServiceClient());
            builder.Services.AddSingleton<Domain.Interfaces.IDataService, DataServiceWCFProvider>();


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