using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using MessageProcessApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace MessageProcessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly MessageDbContext _db;

        public MessageController(MessageDbContext db)

        {
            _db = db;
        }

        [HttpPost]
        public ActionResult Post([FromBody]JsonElement msgFormatA)
        {

           


            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(msgFormatA);

                var isValid=SchemaValidator.Validate(json);
                if (!isValid)
                {
                    return BadRequest("hey please check ur request");

                }
                else {
                    var item = JsonConvert.DeserializeObject<MsgFormatA>(json);
                    _db.Add(item);
                    _db.SaveChanges();

                    return Ok();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
          
        }

        [HttpGet]
        public ActionResult<IList<MsgFormatA>> Get()
        {
            var messageFormatA =  _db.MsgFormatA.ToList();
            return messageFormatA;


        }


    }
}
