using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddDbContext<ClubDataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
            );

            builder.Services.AddTransient<IClubDataRepository<AnnouncementModel>, AnnouncementsRepository>();
            builder.Services.AddTransient<IClubDataRepository<MemberModel>, MembersRepository>();
            builder.Services.AddTransient<IClubDataRepository<MembershipTypeModel>, MembershipTypesRepository>();
            builder.Services.AddTransient<IClubDataRepository<CodeSnippetModel>, CodeSnippetRepository>();
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}