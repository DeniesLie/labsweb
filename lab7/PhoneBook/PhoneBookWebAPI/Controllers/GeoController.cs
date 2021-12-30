using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("api/geo")]
    public class GeoController : ControllerBase
    {
        private readonly PhoneBookContext context;
        public GeoController(PhoneBookContext context)
        {
            this.context = context;
        }    


        [HttpGet]
        [Route("regions")]
        public async Task<IEnumerable<Region>> GetAllRegions()
        {
            return await context.Regions.ToListAsync();
        } 

        [HttpGet]
        [Route("cities/{region}")]
        public async Task<IEnumerable<City>> GetAllCitiesForRegion(string region)
        {
            return await context.Cities
                .Where(c => c.Region.Name == region)
                .ToListAsync();
        } 
    }
}