using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5000/api/alive");
                return Ok(await response.Content.ReadAsStringAsync());
            }
        }
    }
}