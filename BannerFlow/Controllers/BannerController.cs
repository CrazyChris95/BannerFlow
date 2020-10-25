using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BannerFlow.Model;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using HtmlAgilityPack;

namespace BannerFlow.Controllers
{
    [Route("api/Banners")]
    public class BannerController : Controller
    {
        private readonly DB _database;
        private int id = 0;


        public BannerController(DB database)
        {
            _database = database;
        }


        
        [HttpGet]
        public IEnumerable<Banner> ReadAll()
        {
            return _database.Banners.ToList();            
        }


        [Route("{id:int}", Name = "GetBanner")]
        [HttpGet]
        public IActionResult Read(int id)
        {
            Banner banner = _database.Banners
                    .Where(b => b.id == id)
                    .FirstOrDefault();

            if (banner == null)
            {
                return NotFound();
            }

            if (!validHtml(banner.Html))
            {
                return BadRequest();
            }
            return Ok(banner); ;
        }

        [HttpGet("html/{id:int}")]
        public IActionResult HtmlView(int id)
        {
            Banner banner = _database.Banners
                    .Where(b => b.id == id)
                    .FirstOrDefault();

            if (banner == null)
            {
                return NotFound();
            }

          
            return base.Content(banner.Html, "text/html"); ;
        }


        [HttpPost]
        public IActionResult Create([FromBody] Banner banner)
        {
            Console.WriteLine(banner);

            if (banner == null)
            {
                return BadRequest();
            }

            banner.Created = DateTime.Now;
            banner.id = id;
            id++;


            if (!validHtml(banner.Html))
            {
                return BadRequest();
            }

            _database.Banners.Add(banner);
            _database.SaveChanges();


            return CreatedAtRoute("GetBanner", new {id = banner.id }, banner);
        }


        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Banner update)
        {
           Banner banner_db = _database.Banners
                    .Where(b => b.id == id)
                    .FirstOrDefault();

            if (banner_db == null)
            {
                return NotFound();
            } 
            else if (!validHtml(update.Html))
            {
                return BadRequest();

            }

            banner_db.Html = update.Html;
            banner_db.Modified = DateTime.Now;

            _database.Banners.Update(banner_db);
            _database.SaveChanges();

            return Ok(banner_db);

        }



        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Banner banner = _database.Banners
                    .Where(b => b.id == id)
                    .FirstOrDefault();

            if (banner == null) {
                return NotFound();
            }

            _database.Banners.Remove(banner);
            _database.SaveChanges();


            return Ok(banner);
                
        }


        private Boolean validHtml(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            if (doc.ParseErrors.Count() > 0)
            {
                System.Diagnostics.Debug.WriteLine("Not valid html");
                return false;
            }
            return true;
        }



    }
}
