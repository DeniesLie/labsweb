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
    [Route("api/abonents")]
    public class AbonentsController : ControllerBase
    {
        private readonly PhoneBookContext context;

        public AbonentsController(PhoneBookContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IEnumerable<Abonent>> GetAllAbonents()
        {
            return await context.Abonents.Include(a=>a.PhoneNumbers)
                .Include(a=>a.City)
                    .ThenInclude(c=>c.Region)
                .ToListAsync();
        }

        [HttpGet]
        [Route("searchByName/{searchRequest}/{desc}")]
        public async Task<IEnumerable<Abonent>> SearchAbonentsByName(string searchRequest, bool desc)
        {
            var result = context.Abonents.Include(a=>a.PhoneNumbers)
                .Include(a=>a.City)
                    .ThenInclude(c=>c.Region)
                .Where(a=>a.FullName.Contains(searchRequest));

            if (desc == true)
                result = result.OrderByDescending(a=>a.FullName);
            else
                result = result.OrderBy(a=>a.FullName);

            return await result.ToListAsync();
        }
    
        [HttpPost]
        [Route("addAbonent")]
        public async Task<Abonent> AddAbonent([FromBody] Abonent newAbonent)
        {
            context.Add(newAbonent);
            await context.SaveChangesAsync();
            return newAbonent;
        }
    }
}
