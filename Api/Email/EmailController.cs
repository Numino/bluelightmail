using Microsoft.AspNetCore.Mvc;

namespace BlueLight.Api.Email
{
    [Route("api/email")]
    public class EmailController
    {

        [HttpPost]
        public void Post([FromBody] string request)
        {
           
        }
        
        [HttpGet]
        public string Get()
        {
            return "hi";
        }
    }
}