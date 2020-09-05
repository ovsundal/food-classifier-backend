using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using what_am_i_eating.Services;

namespace what_am_i_eating.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageClassifierController : ControllerBase
    {

        private readonly IImageClassifierService _classifierService;
        private readonly IConfiguration _config;
        public ImageClassifierController(IImageClassifierService classifierService)
        {
            _classifierService = classifierService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            var result = await _classifierService.ClassifyImage();

            return Ok(result);
        }
    }
}
