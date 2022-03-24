using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_oneUp_webApi.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace senai_oneUp_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class uploadController : ControllerBase
    {
       
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {

            upload up = new upload();
            var arquivo = up.UploadFile(Request.Form.Files[0]);

            return Ok(arquivo);

        }
    }
}
