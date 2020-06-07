using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestApi.Providers;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase 
    {
        private readonly ILoggerManager logger;
        private readonly IReaderStore store;
        public ReadersController(IReaderStore store, ILoggerManager logger)
        {
            this.logger = logger;
            this.store = store;

            this.logger.LogInformation("On the ReadersController constructor");
        }

        [HttpGet]
        public IEnumerable<Reader> Get() 
        {
            this.logger.LogInformation($"Received Request: {this.Request.Path}");
            var res = store.Readers.ToList();
            this.logger.LogInformation($"{res.Count} records found. Returning to Response");
            return res;
        }
    }
}