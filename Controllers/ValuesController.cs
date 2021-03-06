﻿using System;
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

      _context.Database.EnsureCreated();

			if (_context.ValuesItems.Count() == 0)
			{
				_context.ValuesItems.Add(new ValuesItem { x = 42 });
				_context.SaveChanges();
			}
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

				[HttpGet]
				public IEnumerable<ValuesItem> GetAll()
				{
				    return _context.ValuesItems.ToList();
				}

				[HttpGet("single/{id}", Name = "GetValues")]
				public IActionResult GetById(long id) {
					var item = _context.ValuesItems.FirstOrDefault(t => t.Id == id);
					if (item == null)
					{
						return NotFound();
					}
					return new ObjectResult(item);
				}

        //esim. GET values/single?x=5&y=3
        [HttpGet("single")]
        public string GetByCoords(float x = 0, float y = 0)
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

				[HttpPost]
				public IActionResult Create([FromBody] ValuesItem item)
				{
					if (item == null)
					{
						return BadRequest();
					}

					_context.ValuesItems.Add(item);
					_context.SaveChanges();

					return CreatedAtRoute("GetValue", new { id = item.Id }, item);
				}
			}
}
