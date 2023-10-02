using AppB2C2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppB2C2.Pages
{
	public class IndexModel : PageModel
	{
		/*private readonly AppDBContext _dbContext;
		public CollectionItemsModel(AppDBContext dBContext)
		{
			_dbContext = dBContext;
		} */

		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{

		}
	}
}