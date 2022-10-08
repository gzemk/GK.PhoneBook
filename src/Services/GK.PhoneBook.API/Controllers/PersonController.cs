using Microsoft.AspNetCore.Mvc;

namespace GK.PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
