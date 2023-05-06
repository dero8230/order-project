using Microsoft.AspNetCore.Mvc;

namespace order_api.Controllers.www.Home
{
    public class HomeController : Controller
    {
        [HttpGet("{*path}")]
        public IActionResult Index(string path)
        {
            if (string.IsNullOrEmpty(path) || path == "/")
            {
                return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
            }
            else
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path.TrimStart('/'));
                if (!System.IO.File.Exists(filePath))
                {
                    return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/html");
                }
                return PhysicalFile(filePath, "text/html");
            }
        }
    }
}
