using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi3.Models;

namespace WebApi3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        UsersContext db;

        public UsersController(UsersContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.ID == id);
            if (user == null) return NotFound();
            return new ObjectResult(user);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> Post(User user)
        {
            if (user == null) return BadRequest();
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
