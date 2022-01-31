using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Api.Controllers {
    
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller {
        protected ApplicationDbContext context;

        public BaseController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
    }
}