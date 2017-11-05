using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlentoWebApi.Models;


namespace OlentoWebApi.Controllers
{
	
    [Route("[controller]")]
    public class ValuesController : Controller
    {

		private readonly ValuesContext _context;

		public ValuesController(ValuesContext context)
		{
			_context = context;

			//if (_context.ValuesItems.Count() == 0)
			//{
			//	_context.ValuesItems.Add(new ValuesItem { x = 0 });
			//	_context.SaveChanges();
			//}
		}

        //tee väristä JSON-objekti
        string rgbAsJSON(uint r, uint g, uint b) {
            return(
                "{"
                + "\"r\":" + r.ToString() + ", "
                + "\"g\":" + g.ToString() + ", "
                + "\"b\":" + b.ToString()
                + "}"
                );
        }
        
        
        //esim. GET values?x=5&y=3
        [HttpGet]
        public string Get(float x = 0, float y = 0)
        {
            //lasketaan väri koordinaattien mukaan
            uint r = (uint)x;
            uint g = (uint)y;
            uint b = r + g;
            
            //värin rajatarkistus: r, g, b = {0...255}
            if(r > 255)	r = 255;
            if(g > 255)	g = 255;
            if(b > 255)	b = 255;

            //palautetaan väri json-muodossa
            return rgbAsJSON(r,g,b);
        }
    }
}
