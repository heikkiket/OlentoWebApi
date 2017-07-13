using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OlentoWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values?x=5&y=3
        [HttpGet]
        public IEnumerable<string> Get(uint x = 0, uint y = 0)
        {
			//lasketaan väri koordinaattien mukaan
			uint r = x;
			uint g = y;
			uint b = x + y;
			
			//värin rajatarkistus: r, g, b = {0...255}
			if(r > 255)	r = 255;
			if(g > 255)	g = 255;
			if(b > 255)	b = 255;
        
			//palautetaan väri json-muodossa
            return new string[] { "r:" + r.ToString(), "g:" + g.ToString(), "b:" + b.ToString() };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
