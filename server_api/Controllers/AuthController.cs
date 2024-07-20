using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Reflection;
using Newtonsoft.Json;


namespace rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        [HttpPost("token")]
        public IActionResult Post([FromBody] TokenRequest request)
        {
            
            if (request.grant_type != "password")
            {
                return BadRequest("Неверный тип авторизации.");
            }

            if (request.username == "correct_username" && request.password == "correct_password")
            {
                var token = Guid.NewGuid().ToString();

                var responseObject = new
                {
                    access_token = $"{token}",
                    token_type = "bearer",
                    expires_in = 86399,
                    refresh_token = Guid.NewGuid().ToString()
                };
                using (StreamWriter writer = new StreamWriter("a", false))
                {
                    writer.WriteLine(responseObject.access_token.ToString());
                }

                return Ok(responseObject);

            }
            else
            {
                return BadRequest("Неверный логин или пароль.");
            }
        }
        [HttpGet("/api/data/voc")]
        [CustomAuthorize]
        public IActionResult GetVoc()
        {
            var sensorData = new[]
            {
            new { code = 6, name = "Вес на крюке", unit = "т" },
            new { code = 7, name = "Момент на ключе", unit = "кН*м" }
            };

            return Ok(sensorData);
        }
        [HttpPost("/api/data/archive")]
        [CustomAuthorize]
        public IActionResult ArchiveData([FromBody] ArchiveDataRequest request)
        {
            if (request == null || request.Rig == 0 || request.Codes == null || request.Data == null)
            {
                return BadRequest("Invalid request parameters");
            }
            string dataString = JsonConvert.SerializeObject(request); 
            string filePath = "archive_data.txt";
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(dataString);
            }

            return Ok();
        }
        [HttpPost("/api/data/online")]
        [CustomAuthorize]
        public IActionResult OnlineData([FromBody] OnlineDataRequest request)
        {
            if (request == null || request.Rig == 0 || request.Codes == null || request.Values == null)
            {
                return BadRequest("Invalid request parameters");
            }
            string dataString = JsonConvert.SerializeObject(request); 
            string filePath = "online_data.txt";
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
              sw.WriteLine(dataString);
            }

            return Ok();
            }
        }
       
}

    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                if (string.IsNullOrEmpty(token) || IsValidToken(token))
                {
                    context.Result = new UnauthorizedResult();
                }
            }

            private bool IsValidToken(string token)
            {

                string tok;
                using (StreamReader reader = new StreamReader("a"))
                {
                    string line = reader.ReadToEnd();
                    tok = line;

                }

                return token == tok;
            }
        }
    
    public class OnlineDataRequest
    {
        public int Rig { get; set; }
        public int[] Codes { get; set; }
        public double[] Values { get; set; }
    }
    public class ArchiveDataRequest
    {
        public int Rig { get; set; }
        public int[] Codes { get; set; }
        public List<ArchiveDataEntry> Data { get; set; }
    }

    public class ArchiveDataEntry
    {
        public long Date { get; set; }
        public double[] Values { get; set; }
    }
    public class TokenRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
    }



