using Microsoft.EntityFrameworkCore;
using AppB2C2.Models;

namespace AppB2C2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<AppDBContext>(
				DbContextOptions =>
				DbContextOptions.UseSqlServer(
					builder.Configuration.GetConnectionString("name=DjDb:DefaultConnection")));
		
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

			app.MapRazorPages();
			app.MapFallbackToPage("/Index");

			/*app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
                endpoints.MapFallbackToPage("Index.cshtml");
			}); */

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}