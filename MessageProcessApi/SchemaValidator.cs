using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace MessageProcessApi
{
    public class SchemaValidator
    {



       public static bool  Validate(string js)
        {


            string schemaJson = @"{
  'description': 'A person',
  'type': 'object',
  'maxProperties': 6,
  'properties': {
    'id': {'type': 'integer'},
    'from': {'type': 'string'},
    'to': {'type': 'string'},
    'type': {'type': 'string'},
    'text': {'type': 'string'},
    'sendTime': {'type': 'string'}
},
'additionalProperties': false
  }";

            JSchema schema = JSchema.Parse(schemaJson);

            JObject person = JObject.Parse(js);

            bool valid = person.IsValid(schema);

            return valid;


        }

    }


}
