using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using order_api.Models;
using order_api.Models.Exceptions;

namespace order_api.Controllers.www.Home
{
    public class HomeController : Controller
    {
        private readonly PlotroomOrdersContext _db;

        public HomeController(PlotroomOrdersContext db)
        {
            _db = db;
        }
        [HttpGet("{*path}")]
        public async Task<IActionResult> Index(string path)
        {
            if (path.StartsWith("/admin") || path.StartsWith("admin"))
            {
                return await ResolveAdmin(path);
            }
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

        private async Task<IActionResult> ResolveAdmin(string path)
        {
            await MustBeAdmin();

            if (path == "/admin" || path == "admin")
            {
                return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin", "index.html"), "text/html");
            }
            else
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path.TrimStart('/'));
                if (!System.IO.File.Exists(filePath))
                {
                    return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin", "index.html"), "text/html");
                }
                return PhysicalFile(filePath, "text/html");
            }
        }

        private async Task MustBeAdmin()
        {
            var username = HttpContext.User?.Identity?.Name;
            bool isAdmin = await _db.OrderAdmins.AnyAsync(x => x.DomainUserName == username);
            if (!isAdmin) throw new EntityNotFoundException("Requested path does not exist");
        }
    }
}
