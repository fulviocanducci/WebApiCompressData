using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCompressData.Models;

namespace WebApiCompressData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public DatabaseContext DatabaseContext { get; }
        public PersonController(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        [HttpGet()]
        public async Task<IEnumerable<Person>> GetPerson()
        {
            return await DatabaseContext.Person.ToListAsync();
        }

        [HttpGet("load")]
        public async Task<object> LoadPerson()
        {
            for (int i = 0; i < 100; i++)
            {
                DatabaseContext.Person.Add(new Person { Name = Faker.Name.FullName() });
            }
            int count = await DatabaseContext.SaveChangesAsync();
            return Ok(new { status = count > 0, count });
        }

    }
}
