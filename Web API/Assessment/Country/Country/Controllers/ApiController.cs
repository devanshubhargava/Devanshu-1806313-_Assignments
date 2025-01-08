using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Country.Data;
using Country.Models;

namespace Country.Controllers
{
    public class CountryController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CountryController()
        {
            _context = new ApplicationDbContext();
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        
        [HttpGet]
        public IHttpActionResult GetAllCountries()
        {
            var countries = _context.Countries.ToList();
            return Ok(countries);
        }

        
        [HttpGet]
        public IHttpActionResult GetCountryById(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

        
        [HttpPost]
        public IHttpActionResult AddCountry(Contry country)
        {
            if (country == null)
                return BadRequest("Invalid data.");

            _context.Countries.Add(country);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        
        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, Contry updatedCountry)
        {
            var country = _context.Countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;
            _context.SaveChanges();

            return Ok(country);
        }

        
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            _context.Countries.Remove(country);
            _context.SaveChanges();

            return Ok(country);
        }
    }
}
