using Microsoft.EntityFrameworkCore;
using AppB2C2.Models;
using AppB2C2.Data;
using Microsoft.AspNetCore.Mvc;

namespace AppB2C2
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<DjDbContext>(
				DbContextOptions =>
				DbContextOptions.UseSqlServer(
					builder.Configuration.GetConnectionString("DjDbConnectionString")));
		
			builder.Services.AddRazorPages();
			
			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler();
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
				name: "musicitems",
				pattern: "{controller=MusicItems}/{action=AllItems}/{id?}");

            app.MapControllerRoute(
				name: "musicitems",
				pattern: "{controller=MusicItems}/{action=Edit}/{id?}");

            app.MapControllerRoute(
				name: "musicitems_delete",
				pattern: "{controller=MusicItems}/{action=Delete}/{id?}"); 

			app.MapControllerRoute(
                name: "musicitems_deleteconfirmed",
                pattern: "{controller=MusicItems}/{action=DeleteConfirmed}/{id?}");

            app.MapControllerRoute(
				name: "musicitems_details",
				pattern: "{controller=MusicItems}/{action=DetailItem}/{id?}");

            app.MapControllerRoute(
                name: "admintags",
                pattern: "{controller=AdminTags}/{action=AllTags}/{id?}");
            
            app.MapFallbackToController("Index", "Home");

			app.Run();
		}
	}
}